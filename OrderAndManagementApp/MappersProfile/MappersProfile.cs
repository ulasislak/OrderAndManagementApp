using AutoMapper;
using BusinnesLogic.AllDto.CostumerDto;
using BusinnesLogic.AllDto.OrderDto;
using BusinnesLogic.AllDto.OwnerDto;
using BusinnesLogic.AllDto.ProductDto;
using DataAccess.Entities;
using OrderAndManagementApp.ViewModel;

namespace OrderAndManagementApp.MappersProfile
{
    public class MappersProfile:Profile
    {
        public MappersProfile()
        {
            CreateMap<OwnerVM, OwnerDto>().ReverseMap();
            CreateMap<CostumerVM, CostumerDto>().ReverseMap();
            CreateMap<OrderVM, OrderDto>().ReverseMap();
            CreateMap<ProductVM, ProductDto>().ReverseMap();
        }
    }
}
