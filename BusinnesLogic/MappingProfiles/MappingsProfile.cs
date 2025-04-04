using AutoMapper;
using BusinnesLogic.AllDto;
using BusinnesLogic.AllDto.CostumerDto;
using BusinnesLogic.AllDto.OrderDto;
using BusinnesLogic.AllDto.OwnerDto;
using BusinnesLogic.AllDto.ProductDto;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.MappingProfiles
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Costumer,CostumerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product,ProductDto >().ReverseMap();
            CreateMap<CustomerProductDto, CustomerProduct>()
           .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId)).ReverseMap();           
        }
    }
}
