using AutoMapper;
using AutoMapper.Execution;
using Domain.Entities.ProductModule;
using Microsoft.Extensions.Configuration;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    internal class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductResultDto, string>
    {
        public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
        {
            // BaseUrl + Source
            if (string.IsNullOrWhiteSpace(source.PictureUrl))
                return string.Empty;

            return $"{_configuration["BaseUrl"]}{source.PictureUrl}";
        }
    }
}
