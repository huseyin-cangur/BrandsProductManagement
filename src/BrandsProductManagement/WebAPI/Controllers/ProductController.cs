

using Application.Features.Products.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProductController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            if (mediator == null)
                return BadRequest();

            CreatedProductResponse response = await mediator.Send(createProductCommand);

            return Ok(response);
        }

    }
}