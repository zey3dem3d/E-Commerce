using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistences.Data;
using Presistences.Repositories;

namespace E_Commerce.API.Extensions
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbInititlazer, DbInititlazer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
