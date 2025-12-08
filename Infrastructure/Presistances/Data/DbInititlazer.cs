using Domain.Contracts;
using Domain.Entities.ProductModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistences.Data
{
    public class DbInititlazer : IDbInititlazer
    {
        private readonly StoreDbContext _dbContext;

        public DbInititlazer(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitilaizerAsync()
        {
            try
            {
                // Create Database If It Doesn't Exist & Apply Migrations
                if (_dbContext.Database.GetPendingMigrations().Any())
                    await _dbContext.Database.MigrateAsync();

                // Seed Data
                if (!_dbContext.ProductTypes.Any())
                {
                    // Read Types From File As String
                    var typeData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistances\Data\DataSeeding\types.json");

                    // Transform From JSON To C# Object
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);

                    // Add To Database Context & Save Changes
                    if (types is not null && types.Any())
                        await _dbContext.ProductTypes.AddRangeAsync(types);
                }

                if (!_dbContext.ProductBrands.Any())
                {
                    // Read Types From File As String
                    var brandData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistances\Data\DataSeeding\brands.json");

                    // Transform From JSON To C# Object
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    // Add To Database Context & Save Changes
                    if (brands is not null && brands.Any())
                        await _dbContext.ProductBrands.AddRangeAsync(brands);
                }

                if (!_dbContext.Products.Any())
                {
                    // Read Types From File As String
                    var productData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistances\Data\DataSeeding\products.json");

                    // Transform From JSON To C# Object
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    // Add To Database Context & Save Changes
                    if (products is not null && products.Any())
                        await _dbContext.Products.AddRangeAsync(products);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
