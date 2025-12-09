using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Services.Abstraction.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync();
            var productsResult = _mapper.Map<IEnumerable<ProductResultDto>>(products);
            return productsResult;
        }

        public async Task<ProductResultDto> GetProductByIdAsync(int id)
        {
            var prodcut = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            var productResult = _mapper.Map<ProductResultDto>(prodcut);
            return productResult;
        }

        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var brandsResult = _mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return brandsResult;
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typesResult = _mapper.Map<IEnumerable<TypeResultDto>>(types);
            return typesResult;
        }
    }
}
