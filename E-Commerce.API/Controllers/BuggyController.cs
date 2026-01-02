using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presistences.Data;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly StoreDbContext _dbContext;

        public BuggyController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _dbContext.Products.Find(-1);

            if (product is null)
                return NotFound(new ProblemDetails { Title = "Product Not Found" });

            return Ok(product);
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var products = _dbContext.Products.Find(-1);

            var ProductToReturn = products?.ToString();

            return Ok(ProductToReturn);
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "This is a bad request" });
        }

        [HttpGet("validation-error{id}")]
        public ActionResult GetValidationError(int id)
        {
            return Ok();
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized(new ProblemDetails { Title = "You are not authorized" });
        }
    }
}