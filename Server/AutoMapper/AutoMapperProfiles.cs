using AutoMapper;
using imc_web_api.Dtos.AdminDtos.FeedBackDtos;
using imc_web_api.Dtos.AdminDtos.HCPDtos;
using imc_web_api.Dtos.AdminDtos.Order_ItemsDtos;
using imc_web_api.Dtos.AdminDtos.OrderDtos;
using imc_web_api.Dtos.AdminDtos.PromotionDtos;
using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Dtos.ServiceProviderDtos;
using imc_web_api.Models;

namespace imc_web_api.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<user, RegisterRequestDTO>().ReverseMap();
            CreateMap<user, RegisterationResponseDto>().ReverseMap();

            //Mapping for serviceProvider
            CreateMap<serviceprovidertype, HCPRequestDTO>().ReverseMap();
            CreateMap<serviceprovidertype, HCPResponseDTO>().ReverseMap();

            //Mapping for Qualification
            CreateMap<user_qualification, QualificationRequestDTO>().ReverseMap();
            CreateMap<user_qualification, QualificationResponseDTO>().ReverseMap();

            //Mapping For Service
            CreateMap<service, ServiceRequestDTO>().ReverseMap();
            CreateMap<service, ServiceResponseDTO>().ReverseMap();

            //Mapping For Promotion

            CreateMap<promotion, PromotionRequestDTO>().ReverseMap();
            CreateMap<promotion, PromotionResponseDTO>().ReverseMap();

            //Mapping For Feedback

            CreateMap<feedback, FeedBackRequesrDTO>().ReverseMap();
            CreateMap<feedback, FeedBackResponseDTO>().ReverseMap();

            //Mapping For Order
            CreateMap<order, OrderRequestDTO>().ReverseMap();
            CreateMap<order, OrderResponseDTO>().ReverseMap();

            //Mapping for OrderItem

            CreateMap<orderItem, OrderItemRequestDto>().ReverseMap();
            CreateMap<orderItem, OrderItemResponseDto>().ReverseMap();
        }
    }
}