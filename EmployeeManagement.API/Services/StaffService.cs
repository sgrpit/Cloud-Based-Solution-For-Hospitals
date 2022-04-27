using EmployeeManagement.API.DTOs;
using EmployeeManagement.API.Repos;
using EmployeeManagement.API.Repos.Interface;
using EmployeeManagement.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Services
{
    public class StaffService: IStaffService
    {
        private readonly IStaffRepository _staffRespository;
        public StaffService(IStaffRepository staffRespository)
        {
            _staffRespository = staffRespository;
        }

        public async Task<CreateStaffResDto> CreateUpdateStaffDetails(CreateStaffReqDto createStaffReqDto)
        {
            return await _staffRespository.CreateUpdateStaff(createStaffReqDto);
        }

        public async Task<CreateStaffResDto> DeleteOrDisableStaff(string action, CreateStaffReqDto createStaffReqDto)
        {
            return await _staffRespository.DeleteOrDsiableStaffDetails(action, createStaffReqDto);
        }

        public async Task<IEnumerable<CreateStaffResDto>> GetAllStaffDetails()
        {
            return await _staffRespository.GetAllStaffDetails();
        }

        public async Task<CreateStaffResDto> GetAllStaffDetailsByFilter(string staffId, string contactNo, string patientUHID)
        {
            return await _staffRespository.GetStaffDetailsByFilter(staffId, contactNo);
        }

        public async Task<IEnumerable<CreateStaffResDto>> GetAllStaffDetailsByRoles(int roleId)
        {
            return await _staffRespository.GetStaffDetailsByRole(roleId);
        }
    }
}
