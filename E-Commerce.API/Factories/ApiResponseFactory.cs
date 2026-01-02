using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Error_Models;
using System.Net;

namespace E_Commerce.API.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult CustomValidationErrorResponse(ActionContext context)
        {
            // Get All Errors in ModelState
            var errors = context.ModelState.Where(error => error.Value.Errors.Any())
                .Select(error => new ValidationError
                {
                    Field = error.Key,
                    Errors = error.Value.Errors.Select(e => e.ErrorMessage)
                });

            // Create Custom Response
            var response = new ValidationErrorResponse
            {
                StatusCode = (int) HttpStatusCode.BadRequest,
                ErrorMesssage = "Validation Faild",
                Errors = errors
            };

            // Return
            return new BadRequestObjectResult(response);
        }
    }
}
