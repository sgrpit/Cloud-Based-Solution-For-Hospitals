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
        public async Task<CreateStaffResDto> CreateUpdateStaff(CreateStaffReqDto createStaffReqDto)
        {
            Staff staff = _mapper.Map<Staff>(createStaffReqDto);
            await _dbContext.StaffDetails.AddAsync(staff);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CreateStaffResDto>(staff);
        }

        public async Task<CreateStaffResDto> DeleteOrDsiableStaffDetails(string action, CreateStaffReqDto createStaffReqDto)
        {
            Staff staff = _mapper.Map<Staff>(createStaffReqDto);
            if(action == "delete")
                _dbContext.StaffDetails.Remove(staff);
            else
                _dbContext.StaffDetails.Update(staff);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CreateStaffResDto>(staff);
        }

        public async Task<IEnumerable<CreateStaffResDto>> GetAllStaffDetails()
        {
            IList<Staff> staffList = await _dbContext.StaffDetails.ToListAsync();
            return _mapper.Map<IEnumerable<CreateStaffResDto>>(staffList);
        }

        public async Task<CreateStaffResDto> GetStaffDetailsByFilter(string staffId, string ContactNo)
        {
            if (string.IsNullOrEmpty(staffId))
                return _mapper.Map<CreateStaffResDto>(await _dbContext.StaffDetails.FirstOrDefaultAsync(s => s.StaffId == staffId));
            else if(string.IsNullOrEmpty(ContactNo))
                return _mapper.Map<CreateStaffResDto>(await _dbContext.StaffDetails.FirstOrDefaultAsync(s => s.ContactNo == ContactNo));
            return new CreateStaffResDto();
        }

        public async Task<IEnumerable<CreateStaffResDto>> GetStaffDetailsByPatientUHID(string staffId, string ContactNo)
        {
            IList<Staff> staffList = await _dbContext.StaffDetails.Where(s => s.StaffId == staffId).ToListAsync();
            return _mapper.Map<IEnumerable<CreateStaffResDto>>(staffList);
        }

        public async Task<IEnumerable<CreateStaffResDto>> GetStaffDetailsByRole(int roleId)
        {
            IList<Staff> staffList = await _dbContext.StaffDetails.Where(s => s.RoleId == roleId).ToListAsync();
            return _mapper.Map<IEnumerable<CreateStaffResDto>>(staffList);
        }
    }
}
