using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;
using Shared;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager _serviceManager) : ControllerBase
    {
        #region Get All Products
        [HttpGet] // GET: BaseUrl/api/Products
        public async Task<ActionResult<PaginatedResult<ProductResultDto>>> GetAllProducts([FromQuery] ProductSpecParams parameter)
            => Ok(await _serviceManager.ProductService.GetAllProductsAsync(parameter));
        #endregion

        #region Get Product By Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResultDto>> GetProductById(int id)
            => await _serviceManager.ProductService.GetProductByIdAsync(id);
        #endregion

        #region Get All Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrands()
            => Ok(await _serviceManager.ProductService.GetAllBrandsAsync());
        #endregion

        #region Get All Types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
            => Ok(await _serviceManager.ProductService.GetAllTypesAsync());
        #endregion

    }
}
