using AutoMapper;
using EmployeeManagement.API.DTOs;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repos.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repos
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public StaffRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<StaffDetailsResDto> CreateStaff(CreateStaffReqDto createStaffReqDto, string staffId)
        {
            try
            {                
                var staff = _mapper.Map<Staff>(createStaffReqDto);
                staff.StaffId = staffId;
                staff.CreatedBy = "Admin";
                staff.CreatedOn = DateTime.Now;
                staff.ModifiedBy= "Admin";
                staff.ModifiedOn = DateTime.Now;
                _dbContext.StaffDetails.Add(staff);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<StaffDetailsResDto>(staff);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteStaffDetails(string staffId)
        {
            Staff staff = await _dbContext.StaffDetails.FirstOrDefaultAsync(s => s.StaffId == staffId);
            if (staff == null)
                return false;
            else
            {
                _dbContext.StaffDetails.Remove(staff);
                await _dbContext.SaveChangesAsync();
                return true;
            }            
        }

        public async Task<IEnumerable<StaffDetailsResDto>> GetAllStaffDetails()
        {
            IList<Staff> staffList = await _dbContext.StaffDetails.ToListAsync();
            return _mapper.Map<IEnumerable<StaffDetailsResDto>>(staffList);
        }

        public async Task<string> GetLatestStaffId()
        {
            Staff staff = await _dbContext.StaffDetails.OrderByDescending(s => s.StaffId).FirstOrDefaultAsync();
            if (staff == null)
                return string.Empty;
            else
                return staff.StaffId;
        }

        public async Task<StaffDetailsResDto> GetStaffDetailsByFilter(string staffId, string ContactNo)
        {
            if (string.IsNullOrEmpty(staffId))
                return _mapper.Map<StaffDetailsResDto>(await _dbContext.StaffDetails.FirstOrDefaultAsync(s => s.StaffId == staffId));
            else if(string.IsNullOrEmpty(ContactNo))
                return _mapper.Map<StaffDetailsResDto>(await _dbContext.StaffDetails.FirstOrDefaultAsync(s => s.ContactNo == ContactNo));
            return new StaffDetailsResDto();
        }

        public async Task<IEnumerable<StaffDetailsResDto>> GetStaffDetailsByPatientUHID(string staffId, string ContactNo)
        {
            IList<Staff> staffList = await _dbContext.StaffDetails.Where(s => s.StaffId == staffId).ToListAsync();
            return _mapper.Map<IEnumerable<StaffDetailsResDto>>(staffList);
        }

        public async Task<IEnumerable<StaffDetailsResDto>> GetStaffDetailsByRole(int roleId)
        {
            IList<Staff> staffList = await _dbContext.StaffDetails.Where(s => s.RoleId == roleId).ToListAsync();
            return _mapper.Map<IEnumerable<StaffDetailsResDto>>(staffList);
        }

        public async Task<StaffDetailsResDto> UpdateStaffDetails(UpdateStaffReqDto updateStaffReqDto)
        {
            var staff = await _dbContext.StaffDetails.FirstOrDefaultAsync(s => s.Id == updateStaffReqDto.StaffGuid);

            staff.StaffId = updateStaffReqDto.StaffId;
            staff.FirstName = updateStaffReqDto.FirstName;
            staff.MiddleName = updateStaffReqDto.MiddleName;
            staff.LastName = updateStaffReqDto.LastName;
            staff.BloodGroup = updateStaffReqDto.BloodGroup;
            staff.ContactNo = updateStaffReqDto.ContactNo;
            staff.EmailId = updateStaffReqDto.EmailId;
            staff.RoleId = updateStaffReqDto.RoleId;
            staff.IsActive = updateStaffReqDto.IsActive;
            staff.IsPermanent = updateStaffReqDto.IsPermanent;
            staff.ModifiedBy = "Admin";
            staff.ModifiedOn = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<StaffDetailsResDto>(staff);
        }
    }
}
