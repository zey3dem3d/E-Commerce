using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductModule
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }

        // One to Many Relationship Between ProductBrand & Product
        public ProductBrand ProductBrand { get; set; }
        public int BrandId { get; set; } // FK For ProductBrand

        // One to Many Relationship Between ProductType & Product
        public ProductType ProductType { get; set; }
        public int TypeId { get; set; } // FK For ProductType
    }
}
