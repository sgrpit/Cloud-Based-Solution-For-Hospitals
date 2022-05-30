using AutoMapper;
using EmployeeManagement.API.DTOs;
using EmployeeManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Staff, CreateStaffReqDto>().ReverseMap();
                config.CreateMap<StaffDetailsResDto, Staff>().ReverseMap();
                config.CreateMap<UpdateStaffReqDto, Staff>().ReverseMap();
                config.CreateMap<Department, AddDepartmentReqDto>().ReverseMap();
                config.CreateMap<DepartmentResDto, Department>().ReverseMap();
                //config.CreateMap<AppointmentResDto, PatientAppointment>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
