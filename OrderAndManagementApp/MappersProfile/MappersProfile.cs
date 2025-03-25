using AutoMapper;
using BusinnesLogic.AllDto.CostumerDto;
using BusinnesLogic.AllDto.OrderDto;
using BusinnesLogic.AllDto.OwnerDto;
using BusinnesLogic.AllDto.ProductDto;
using DataAccess.Entities;

namespace OrderAndManagementApp.MappersProfile
{
    public class MappersProfile:Profile
    {
        public MappersProfile()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Costumer, CostumerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
