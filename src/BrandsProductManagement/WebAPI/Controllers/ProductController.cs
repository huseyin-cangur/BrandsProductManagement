

using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using Core.Application.Request;
using Core.Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProductController : BaseController
    {
        [Authorize(Roles = "Product_User,Admin")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            if (mediator == null)
                return BadRequest();

            CreatedProductResponse response = await mediator.Send(createProductCommand);


            return Created(
            string.Empty,
            ApiResponse<CreatedProductResponse>.SuccessResponse(
                response,
                 "Ürün eklendi."
                    )
            );
        }

        [HttpGet]
        [Authorize(Roles = "Product_User,Admin")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {

            var query = new GetListProductQuery { PageRequest = pageRequest };


            GetListResponse<GetListProductListItemDto> getListResponse = await mediator.Send(query);

            return Ok(getListResponse);
        }
        [HttpGet]
        [Authorize(Roles = "Product_User,Admin")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            GetByIdProductQuery getByIdProductQuery = new() { Id = id };
            GetByIdProductResponse response = await mediator.Send(getByIdProductQuery);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Product_User,Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            UpdateProductResponse response = await mediator.Send(updateProductCommand);

            return Ok(
            ApiResponse<UpdateProductResponse>.SuccessResponse(
                response,
                "Ürün başarıyla güncellendi"
            )
            );
        }
        [Authorize(Roles = "Product_User,Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)

        {
            DeleteProductCommand deleteProduct = new() { Id = Id };
            DeleteProductResponse response = await mediator.Send(deleteProduct);

            return Ok(
            ApiResponse<DeleteProductResponse>.SuccessResponse(
                response,
                "Ürün başarıyla silindi"
            ));
        }

    }
}