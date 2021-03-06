using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.API.DTOs;
using PatientManagement.API.Middleware;
using PatientManagement.API.Repository.Interface;
using PatientManagement.API.Service;
using PatientManagement.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace PatientManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepo _patientRepositry;
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;

        public PatientController(IPatientRepo patientRepository, IMapper mapper, IPatientService patientService)
        {
            _patientRepositry = patientRepository;
            _mapper = mapper;
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatientDetails()
        {
            var patientResponse = await _patientRepositry.GetAllPatient();
            //return Ok(patientResponse);
            return Ok(new ApiResponse<IEnumerable<CreatePatientResDto>>(patientResponse, true, "Success"));
        }
        [HttpGet("UHID/{uhid}", Name = "GetPatientByUHID")]
        public async Task<IActionResult> GetAllPatientDetailsByUHID(string uhid)
        {
            //also need to include billing details and discharge summary if patient is IPD
            var patientRes = await _patientRepositry.GetPatientDetailsByUHID(uhid);
            if (patientRes == null)
                return Ok(new ApiResponse<CreatePatientResDto>(patientRes, false, "No Data"));
            return Ok(new ApiResponse<CreatePatientResDto>(patientRes, true, "Success"));
        }
        [HttpGet("ContactNo/{contactNo}", Name = "GetPatientByContactNo")]
        public async Task<IActionResult> GetAllPatientDetailsByMobileNo(string contactNo)
        {
            //also need to include billing details and discharge summary if patient is IPD
            CreatePatientResDto patientRes = await _patientRepositry.GetPatientDetailsContactNo(contactNo);
            if(patientRes == null)
            {
                throw new KeyNotFoundException();
            }
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatePatientResDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SavePatienDetails(CreatePatientReqDto patientReqDto)
        {
            CreatePatientResDto patientRes = await _patientService.CreateUpdatePatientDetails(patientReqDto);
            
            return Ok(patientRes);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePatienDetails(CreatePatientReqDto patientReqDto)
        {
            CreatePatientResDto patientRes = await _patientService.CreateUpdatePatientDetails(patientReqDto);

            return Ok(patientRes);
        }
        [HttpDelete]
        public async Task<bool> DeletePatienDetails(int patientId, string patientUHID, string ContactNo)
        {
            await _patientRepositry.DeletePatientDetails(patientUHID);
            return true;
        }

        [HttpGet("GetAppointmentSchdule")]
        [ProducesResponseType(typeof(AppointmentResDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPatientAppointment(string patientUHID = "", string contactNo = "")
        {
            AppointmentResDto responseDto = await _patientRepositry.GetPatientAppointmentScheduleDetails(patientUHID, contactNo);
            return Ok(responseDto);
        }
        [HttpPost("ScheduleAppointment")]
        [ProducesResponseType(typeof(AppointmentResDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ScheduleAppointment(AppointmentReqDto appointmentRequestDto)
        {
            AppointmentResDto responseDto = await _patientService.SchedulePatientApointment(appointmentRequestDto);
            return Ok(responseDto);
        }
        [HttpPatch("CancelOrCompleteAppointment")]
        public async Task<IActionResult> CancelScheduledAppointment(string contactNo, string action)
        {
            AppointmentResDto resDto = await _patientService.CancelScheduledAppointment(contactNo, action);
            return Ok();
        }
        [HttpPatch("UpdateAppointmentDetails")]
        [ProducesResponseType(typeof(AppointmentResDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateScheduledAppointmentDetails(string contactNo, string newAppointmentDate, string newAppointmentTimeSlot)
        {
            AppointmentResDto appointmentResDto = await _patientService.UpdateScheduledPatientAppointment(contactNo, newAppointmentDate, newAppointmentTimeSlot);
            return Ok();
        }

        [HttpGet("GetLabReport")]
        [ProducesResponseType(typeof(AppointmentResDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLabReportByUHIDOrContactNo(string UHID, string contactNo)
        {
            //this action will call report generation microservice.
            return Ok();
        }

        [HttpGet("GetPatientAppointmentDetails")]
        [ProducesResponseType(typeof(AppointmentResDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAppointmentByStaffId(string staffId)
        {
            var patientAppointmentDetails = await _patientRepositry.GetPatientAppointmentsByStaffId(string.Empty);
            return Ok(new ApiResponse<IEnumerable<AppointmentResDto>>(patientAppointmentDetails, true, "Success"));
        }
    }
}
