using Domain.Contracts;
using E_Commerce.API.Extensions;
using E_Commerce.API.Factories;
using E_Commerce.API.MiddleWares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistences.Data;
using Presistences.Repositories;
using Services;
using Services.Abstraction.Contracts;
using Services.Implementations;

namespace E_Commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            // Add services to the container.

            builder.Services.AddWebApiServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddCoreServices();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            #endregion

            var app = builder.Build();

            #region Configure Kestrel MiddelWares
            // Configure the HTTP request pipeline.

            app.UseCustomExceptionMiddlewares();

            await app.SeedDbAsync();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}