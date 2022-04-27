using PatientManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Service.Interface
{
    public interface IPatientService
    {
        Task<CreatePatientResDto> CreateUpdatePatientDetails(CreatePatientReqDto patientReqDto);
        Task<AppointmentResDto> SchedulePatientApointment(AppointmentReqDto appointmentDto);
    }
}
