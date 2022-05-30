using EmployeeManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repos.Interface
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<DepartmentResDto>> GetDepartmentDetails();
        Task<DepartmentResDto> UpsertDepartment(AddDepartmentReqDto addDepartmentReqDto);

    }
}
