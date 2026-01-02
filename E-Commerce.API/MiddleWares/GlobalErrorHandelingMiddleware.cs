using Domain.Exceptions;
using Shared.Error_Models;
using System.Net;
using System.Text.Json;

namespace E_Commerce.API.MiddleWares
{
    public class GlobalErrorHandelingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandelingMiddleware> _logger;

        public GlobalErrorHandelingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandelingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Response [StatusCode, ErrorMessage]
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if(httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
                    await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception exception)
            {
                // Log the exception details
                _logger.LogError($"Something Went Wrong {exception}");

                // Handle the exception and return a custom error response
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";

            var response = new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                ErrorMessage = $"The Endpoint {httpContext.Request.Path} Not Found!"
            }.ToString();

            await httpContext.Response.WriteAsync(response);

        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            // Set Content Type => application/json
            httpContext.Response.ContentType = "application/json";

            // Set Default Status Code => 500
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            // Return The Standard Respnose
            var response = new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = exception.Message
            }.ToString();

            await httpContext.Response.WriteAsync(response);
        }
    }
}
