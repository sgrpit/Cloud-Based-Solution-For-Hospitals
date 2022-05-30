using EmployeeManagement.API.DTOs;
using EmployeeManagement.API.Repos.Interface;
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
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentRepo _departmentRepo;
        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaffDetails()
        {
            IEnumerable<DepartmentResDto> departmentRes = await _departmentRepo.GetDepartmentDetails();
            return Ok(departmentRes);
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdateDepartment(AddDepartmentReqDto addDepartmentReqDto)
        {
            DepartmentResDto deptDetailsResDto = await _departmentRepo.UpsertDepartment(addDepartmentReqDto);
            return Ok(deptDetailsResDto);
        }
    }
}
