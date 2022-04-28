using EmployeeManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repos.Interface
{
    public interface IStaffRepository
    {
        Task<StaffDetailsResDto> GetStaffDetailsByFilter(string staffId, string ContactNo);
        Task<IEnumerable<StaffDetailsResDto>> GetAllStaffDetails();
        Task<StaffDetailsResDto> CreateStaff(CreateStaffReqDto createStaffReqDto, string staffId);
        Task<StaffDetailsResDto> UpdateStaffDetails(UpdateStaffReqDto updateStaffReqDto);
        Task<bool> DeleteStaffDetails(Guid staffGuid);
        Task<IEnumerable<StaffDetailsResDto>> GetStaffDetailsByRole(int roleId);
        Task<IEnumerable<StaffDetailsResDto>> GetStaffDetailsByPatientUHID(string staffId, string ContactNo);
        Task<string> GetLatestStaffId();

    }
}
