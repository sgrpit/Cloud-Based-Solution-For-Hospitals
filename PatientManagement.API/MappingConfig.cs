using AutoMapper;
using PatientManagement.API.DTOs;
using PatientManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Patient, CreatePatientReqDto>().ReverseMap();
                config.CreateMap<CreatePatientResDto, Patient>().ReverseMap();
                //config.CreateMap<AppointmentRequestDto, PatientAppointment>().ReverseMap();
                //config.CreateMap<AppointmentResponseDto, PatientAppointment>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
