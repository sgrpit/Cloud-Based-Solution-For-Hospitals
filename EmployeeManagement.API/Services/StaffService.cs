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

        public async Task<StaffDetailsResDto> CreateStaffDetails(CreateStaffReqDto createStaffReqDto)
        {
            string staffId = await GenerateEmployeeId();
            return await _staffRespository.CreateStaff(createStaffReqDto, staffId);
        }

        public async Task<bool> DeleteStaff(Guid staffGuid)
        {
            return await _staffRespository.DeleteStaffDetails(staffGuid);
        }

        public async Task<IEnumerable<StaffDetailsResDto>> GetAllStaffDetails()
        {
            return await _staffRespository.GetAllStaffDetails();
        }

        public async Task<StaffDetailsResDto> GetAllStaffDetailsByFilter(string staffId, string contactNo, string patientUHID)
        {
            return await _staffRespository.GetStaffDetailsByFilter(staffId, contactNo);
        }

        public async Task<IEnumerable<StaffDetailsResDto>> GetAllStaffDetailsByRoles(int roleId)
        {
            return await _staffRespository.GetStaffDetailsByRole(roleId);
        }

        public async Task<StaffDetailsResDto> UpdateStaffDetails(UpdateStaffReqDto updateStaffReqDto)
        {
            return await _staffRespository.UpdateStaffDetails(updateStaffReqDto);
        }

        private async Task<string> GenerateEmployeeId()
        {
            string latestStaffId = await _staffRespository.GetLatestStaffId();
            string newStaffId = "S";
            if(string.IsNullOrEmpty(latestStaffId))
            {
                newStaffId =  "S-00001";
            }
            else
            {
                string staffIdNo = latestStaffId.Split("-")[1];
                int numericValue = Convert.ToInt32(staffIdNo) + 1;
                if (Math.Floor(Math.Log10(numericValue) + 1) == 1)
                    newStaffId = newStaffId + "0000" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 2)
                    newStaffId = newStaffId + "000" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 3)
                    newStaffId = newStaffId + "00" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 3)
                    newStaffId = newStaffId + "0" + Convert.ToString(numericValue);
                else
                    newStaffId = newStaffId + Convert.ToString(numericValue);

            }
            return newStaffId;
        }
    }
}
