using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Services.Abstraction.Contracts
{
    public interface IProductService
    {
        // Get All Products
        public Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(ProductSortingOptions sort, int? typeId, int? brandId);
        // Get Product By Id
        public Task<ProductResultDto> GetProductByIdAsync(int id);
        // Get All Brands
        public Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
        // Get All Types
        public Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();
    }
}
