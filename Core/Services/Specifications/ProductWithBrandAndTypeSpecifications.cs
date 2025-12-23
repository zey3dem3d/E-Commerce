using Domain.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product, int>
    {
        // Get All Products
        // query = _dbContext.Set<Product>().Include(P => P.ProductBrand).Include(P => P.ProductType)
        public ProductWithBrandAndTypeSpecifications(ProductSortingOptions sort, int? typeId, int? brandId) :
            base(product => 
            (!typeId.HasValue || product.TypeId == typeId.Value) && (!brandId.HasValue || product.BrandId == brandId.Value))
        {
            AddIncludes(P => P.ProductBrand);
            AddIncludes(P => P.ProductType);

            switch (sort)
            {
                case ProductSortingOptions.PriceAsc:
                    SetOrderBy(P => P.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    SetOrderByDescending(P => P.Price);
                    break;

                case ProductSortingOptions.NameAsc:
                    SetOrderBy(P => P.Name);
                    break;

                case ProductSortingOptions.NameDesc:
                    SetOrderByDescending(P => P.Name);
                    break;

                default:
                    break;
            }
        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(P => P.Id == id)
        {
            AddIncludes(P => P.ProductBrand);
            AddIncludes(P => P.ProductType);
        }
    }
}
