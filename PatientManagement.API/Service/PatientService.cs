using AutoMapper;
using PatientManagement.API.DTOs;
using PatientManagement.API.Models;
using PatientManagement.API.Repository.Interface;
using PatientManagement.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepository;
        private IMapper _mapper;

        public PatientService(IPatientRepo patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<CreatePatientResDto> CreateUpdatePatientDetails(CreatePatientReqDto patientReqDto)
        {
            if(string.IsNullOrEmpty(patientReqDto.PatientUHID))
                patientReqDto.PatientUHID = await GetNewPatientUHID();
            return await _patientRepository.PatientRegistration(patientReqDto);
        }

        public async Task<AppointmentResDto> SchedulePatientApointment(AppointmentReqDto appointmentDto)
        {
            Patient patientDetails = await _patientRepository.GetPatientDetailsByFilter(appointmentDto.PatientUHID, appointmentDto.ContactNo);
            if (patientDetails != null)
            {
                appointmentDto.PatientUHID = patientDetails.PatientUHID;
                appointmentDto.PatientGuid = patientDetails.ID;
            }
                
            PatientAppointment appointmentDetails = _mapper.Map<PatientAppointment>(appointmentDto);
            var appointmentResponse = await _patientRepository.SchedulePatientAppointment(appointmentDetails);
            return _mapper.Map<AppointmentResDto>(appointmentResponse);
        }

        public async Task<AppointmentResDto> CancelScheduledAppointment(string contactNo, string action)
        {
            var appointmentResponse = await _patientRepository.CancelScheduledPatientAppointment(contactNo, action);
            return _mapper.Map<AppointmentResDto>(appointmentResponse);
        }

        private async Task<string> GetNewPatientUHID()
        {
            string newUHID = "UHID";
            string existingUHID = await _patientRepository.GetLatestPatientUHID();
            if (string.IsNullOrEmpty(existingUHID))
                newUHID = newUHID + "00001";
            else
            {
                int numericValue = Convert.ToInt32(existingUHID.Replace("UHID", string.Empty)) + 1;
                if (Math.Floor(Math.Log10(numericValue) + 1) == 1)
                    newUHID = newUHID + "0000" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 2)
                    newUHID = newUHID + "000" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 3)
                    newUHID = newUHID + "00" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 3)
                    newUHID = newUHID + "0" + Convert.ToString(numericValue);
                else
                    newUHID = newUHID + Convert.ToString(numericValue);
            }
            return newUHID;
        }

        public async Task<AppointmentResDto> UpdateScheduledPatientAppointment(string contactNo, string nextAppointmentDate, string appointmentSlot)
        {
            PatientAppointment appointment = await _patientRepository.UpdateScheduledPatientAppointment(contactNo, nextAppointmentDate, appointmentSlot);
            return _mapper.Map<AppointmentResDto>(appointment);
        }
    }
}
