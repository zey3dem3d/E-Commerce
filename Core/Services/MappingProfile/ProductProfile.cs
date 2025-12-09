using AutoMapper;
using Domain.Entities.ProductModule;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDto>()
                  .ForMember(M => M.BrandName, O => O.MapFrom(S => S.ProductBrand.Name))
                  .ForMember(M => M.TypeName, O => O.MapFrom(S => S.ProductType.Name));
            CreateMap<ProductBrand, BrandResultDto>();
            CreateMap<ProductType, TypeResultDto>();
        }
    }
}
