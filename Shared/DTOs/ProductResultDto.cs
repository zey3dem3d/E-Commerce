using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    // Record : Special kind of class in C# that is primarily used to hold data Introduced in C# 9.0 ---> Based On Value Equality Not Reference Equality & Immutable by Default.
    public record ProductResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public string BrandName { get; set; } = null!;
        public string TypeName { get; set; } = null!;
    }
}
