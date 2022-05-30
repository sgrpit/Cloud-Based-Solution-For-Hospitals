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
    public class DepartmentRepository : IDepartmentRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DepartmentResDto>> GetDepartmentDetails()
        {
            IList<Department> departments = await _dbContext.Departments.ToListAsync();
            return _mapper.Map<IList<DepartmentResDto>>(departments);
            //throw new Exception("Helllo");
        }

        public async Task<DepartmentResDto> UpsertDepartment(AddDepartmentReqDto addDepartmentReqDto)
        {
            Department department = _mapper.Map<Department>(addDepartmentReqDto);
            await _dbContext.AddAsync(department);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<DepartmentResDto>(department);
            //throw new Exception("Helllo");
        }
    }
}
