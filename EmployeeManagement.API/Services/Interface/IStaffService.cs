using EmployeeManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Services.Interface
{
    public interface IStaffService
    {
        Task<IEnumerable<CreateStaffResDto>> GetAllStaffDetails();
        Task<IEnumerable<CreateStaffResDto>> GetAllStaffDetailsByRoles(int roleId);
        Task<CreateStaffResDto> GetAllStaffDetailsByFilter(string staffId, string contactNo, string patientUHID);
        Task<CreateStaffResDto> CreateUpdateStaffDetails(CreateStaffReqDto createStaffReqDto);
        Task<CreateStaffResDto> DeleteOrDisableStaff(string action, CreateStaffReqDto createStaffReqDto);

    }
}
