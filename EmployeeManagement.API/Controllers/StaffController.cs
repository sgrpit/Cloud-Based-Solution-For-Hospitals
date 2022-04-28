using EmployeeManagement.API.DTOs;
using EmployeeManagement.API.Repos.Interface;
using EmployeeManagement.API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaffDetails()
        {
            IEnumerable<StaffDetailsResDto> StaffDetailsResDto = await _staffService.GetAllStaffDetails();
            return Ok(StaffDetailsResDto);
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetStaffDetailsByRoleId(int roleId)
        {
            IEnumerable<StaffDetailsResDto> StaffDetailsResDto = await _staffService.GetAllStaffDetails();
            return Ok(StaffDetailsResDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaffDetails(CreateStaffReqDto createStaffReqDto)
        {
            StaffDetailsResDto StaffDetailsResDto = await _staffService.CreateStaffDetails(createStaffReqDto);
            return Ok(StaffDetailsResDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaffDetails(UpdateStaffReqDto updateStaffReqDto)
        {
            StaffDetailsResDto StaffDetailsResDto = await _staffService.UpdateStaffDetails(updateStaffReqDto);
            return Ok(StaffDetailsResDto);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStaff(Guid staffGuid)
        {
            bool result = await _staffService.DeleteStaff(staffGuid);
            return Ok(result);
        }

    }
}
