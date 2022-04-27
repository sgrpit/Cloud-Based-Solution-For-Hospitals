using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientManagement.API.Data;
using PatientManagement.API.DTOs;
using PatientManagement.API.Models;
using PatientManagement.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Repository
{
    public class PatientRepo: IPatientRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PatientRepo(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> DeletePatientDetails(string patientUHID)
        {
            try
            {
                Patient patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.PatientUHID == patientUHID);
                if (patient == null)
                    return false;
                _dbContext.Patients.Remove(patient);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<CreatePatientResDto>> GetAllPatient()
        {
            List<Patient> patients = await _dbContext.Patients.ToListAsync();
            return _mapper.Map<IEnumerable<CreatePatientResDto>>(patients);
        }

        public async Task<string> GetLatestPatientUHID()
        {
            Patient patient = await _dbContext.Patients.OrderByDescending(p => p.PatientUHID).FirstOrDefaultAsync();
            return patient.PatientUHID;
        }

        public async Task<AppointmentResDto> GetPatientAppointmentScheduleDetails(string PatientUHID, string contactNo)
        {
            PatientAppointmentHistory patientAppointment = await _dbContext.PatientAppointmentHistory.FirstOrDefaultAsync(a => a.PatientUHID == PatientUHID);
            return _mapper.Map<AppointmentResDto>(patientAppointment);
        }

        public async Task<Patient> GetPatientDetailsByFilter(string UHID, string contactNo, string emailId = "")
        {
            
            return await _dbContext.Patients.FirstOrDefaultAsync(a => a.PatientUHID == UHID || a.ContactNo == contactNo || a.EmailId == emailId);
        }

        public async Task<CreatePatientResDto> GetPatientDetailsByUHID(string patientUHID)
        {
            Patient patientsDetail = await _dbContext.Patients.FirstOrDefaultAsync(p => p.PatientUHID == patientUHID);
            return _mapper.Map<CreatePatientResDto>(patientsDetail);
        }

        public async Task<CreatePatientResDto> GetPatientDetailsContactNo(string contactNo)
        {
            Patient patientsDetail = await _dbContext.Patients.FirstOrDefaultAsync(p => p.ContactNo == contactNo);
            return _mapper.Map<CreatePatientResDto>(patientsDetail);
        }

        public async Task<CreatePatientResDto> PatientRegistration(CreatePatientReqDto patientReqDto)
        {
            Patient patientsDetails = _mapper.Map<Patient>(patientReqDto);
            _dbContext.Patients.Add(patientsDetails);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CreatePatientResDto>(patientsDetails);
        }

        public async Task<PatientAppointmentHistory> SchedulePatientAppointment(PatientAppointmentHistory appointmentDetails)
        {
            _dbContext.PatientAppointmentHistory.Add(appointmentDetails);
            await _dbContext.SaveChangesAsync();
            return appointmentDetails;
        }

        public async Task<CreatePatientResDto> UpdatePatientDetails(CreatePatientReqDto patientReqDto)
        {
            Patient patientsDetails = _mapper.Map<Patient>(patientReqDto);
            _dbContext.Patients.Update(patientsDetails);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CreatePatientResDto>(patientsDetails);
        }
    }
}
