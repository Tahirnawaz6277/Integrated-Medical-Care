﻿using AutoMapper;
using imc_web_api.Dtos.AdminDtos.HCPDtos;
using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;

namespace imc_web_api.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Mapping for serviceProvider
            CreateMap<serviceprovidertype, HCPRequestDTO>().ReverseMap();
            CreateMap<serviceprovidertype, HCPResponseDTO>().ReverseMap();

            //Mapping for Qualification
            CreateMap<user_qualification, QualificationRequestDTO>().ReverseMap();
            CreateMap<user_qualification, QualificationResponseDTO>().ReverseMap();



        }
    }
}