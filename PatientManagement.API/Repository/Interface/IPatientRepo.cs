using PatientManagement.API.DTOs;
using PatientManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Repository.Interface
{
    public interface IPatientRepo
    {
        Task<IEnumerable<CreatePatientResDto>> GetAllPatient();
        Task<CreatePatientResDto> GetPatientDetailsByUHID(string patientUHID);
        Task<CreatePatientResDto> GetPatientDetailsContactNo(string contactNo);
        Task<CreatePatientResDto> PatientRegistration(CreatePatientReqDto patientReqDto);
        Task<CreatePatientResDto> UpdatePatientDetails(CreatePatientReqDto patientReqDto);
        Task<bool> DeletePatientDetails(string patientUHID);
        Task<string> GetLatestPatientUHID();
        Task<Patient> GetPatientDetailsByFilter(string UHID, string contactNo, string emailId = "");
        Task<PatientAppointment> SchedulePatientAppointment(PatientAppointment appointmentDetails);
        Task<AppointmentResDto> GetPatientAppointmentScheduleDetails(string PatientUHID, string contactNo);
        Task<PatientAppointment> CancelScheduledPatientAppointment(string contactNo, string action);
        Task<PatientAppointment> UpdateScheduledPatientAppointment(string contactNo, string nextAppointmentDate, string appointmentSlot);
        Task<IEnumerable<AppointmentResDto>> GetPatientAppointmentsByStaffId(string staffId);
    }
}
