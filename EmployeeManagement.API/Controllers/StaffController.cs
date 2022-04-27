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
            IEnumerable<CreateStaffResDto> createStaffResDto = await _staffService.GetAllStaffDetails();
            return Ok(createStaffResDto);
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetStaffDetailsByRoleId(int roleId)
        {
            IEnumerable<CreateStaffResDto> createStaffResDto = await _staffService.GetAllStaffDetails();
            return Ok(createStaffResDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdateStaffDetails(CreateStaffReqDto createStaffReqDto)
        {
            CreateStaffResDto createStaffResDto = await _staffService.CreateUpdateStaffDetails(createStaffReqDto);
            return Ok(createStaffResDto);
        }
        [HttpDelete("{action}")]
        public async Task<IActionResult> DeleteorDisableStaff(string action, CreateStaffReqDto createStaffReqDto)
        {
            CreateStaffResDto createStaffResDto = await _staffService.DeleteOrDisableStaff(action, createStaffReqDto);
            return Ok(createStaffResDto);
        }

    }
}
