using AutoMapper;
using imc_web_api.Dtos.AdminDtos.HCPDtos;
using imc_web_api.Models;

namespace imc_web_api.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<serviceprovidertype, HCPRequestDTO>().ReverseMap();
            CreateMap<serviceprovidertype, HCPResponseDTO>().ReverseMap();
        }
    }
}