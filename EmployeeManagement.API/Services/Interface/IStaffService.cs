using EmployeeManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Services.Interface
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffDetailsResDto>> GetAllStaffDetails();
        Task<IEnumerable<StaffDetailsResDto>> GetAllStaffDetailsByRoles(int roleId);
        Task<StaffDetailsResDto> GetAllStaffDetailsByFilter(string staffId, string contactNo, string patientUHID);
        Task<StaffDetailsResDto> CreateStaffDetails(CreateStaffReqDto createStaffReqDto);
        Task<StaffDetailsResDto> UpdateStaffDetails(UpdateStaffReqDto updateStaffReqDto);
        Task<bool> DeleteStaff(Guid staffGuid);

    }
}
