
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistences.Data;
using Presistences.Repositories;

namespace E_Commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IDbInititlazer, DbInititlazer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            var app = builder.Build();

            await InitilaizeDbAsync(app);

            #region Configure Kestrel MiddelWares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            #endregion

            app.Run();

            async Task InitilaizeDbAsync(WebApplication app)
            {
                // Create Object From Type That Implements IDbInititlazer
                using var scope = app.Services.CreateScope();

                var dbInititlazer = scope.ServiceProvider.GetRequiredService<IDbInititlazer>();

                await dbInititlazer.InitilaizerAsync();
            }
        }
    }
}