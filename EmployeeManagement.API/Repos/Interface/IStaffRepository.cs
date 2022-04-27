using EmployeeManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repos.Interface
{
    public interface IStaffRepository
    {
        Task<CreateStaffResDto> GetStaffDetailsByFilter(string staffId, string ContactNo);
        Task<IEnumerable<CreateStaffResDto>> GetAllStaffDetails();
        Task<CreateStaffResDto> CreateUpdateStaff(CreateStaffReqDto createStaffReqDto);
        Task<CreateStaffResDto> DeleteOrDsiableStaffDetails(string action, CreateStaffReqDto createStaffReqDto);
        Task<IEnumerable<CreateStaffResDto>> GetStaffDetailsByRole(int roleId);
        Task<IEnumerable<CreateStaffResDto>> GetStaffDetailsByPatientUHID(string staffId, string ContactNo);

    }
}
