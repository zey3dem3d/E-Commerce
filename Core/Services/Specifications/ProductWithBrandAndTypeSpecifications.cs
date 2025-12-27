using Domain.Entities.ProductModule;
using Shared;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product, int>
    {
        // Get All Products
        // query = _dbContext.Set<Product>().Include(P => P.ProductBrand).Include(P => P.ProductType)

        // Where(P => P.TypeId == Product.TypeId)
        // Where(P => P.Name == "Chicken")
        public ProductWithBrandAndTypeSpecifications(ProductSpecParams parameters) :
            base(product =>
            (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value) &&
            (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
            (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower().Trim())))
        {
            AddIncludes(P => P.ProductBrand);
            AddIncludes(P => P.ProductType);

            switch (parameters.Sort)
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

            ApplyPagination(parameters.PageIndex, parameters.PageSize);
        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(P => P.Id == id)
        {
            AddIncludes(P => P.ProductBrand);
            AddIncludes(P => P.ProductType);
        }
    }
}
