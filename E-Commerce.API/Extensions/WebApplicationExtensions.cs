using Domain.Contracts;
using E_Commerce.API.MiddleWares;

namespace E_Commerce.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> SeedDbAsync(this WebApplication app)
        {
            // Create Object From Type That Implements IDbInititlazer
            using var scope = app.Services.CreateScope();

            var dbInititlazer = scope.ServiceProvider.GetRequiredService<IDbInititlazer>();

            await dbInititlazer.InitilaizerAsync();

            return app;
        }

        public static WebApplication UseCustomExceptionMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<GlobalErrorHandelingMiddleware>();
            return app;
        }

        public static WebApplication UseSwaggerMiddlewares(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}