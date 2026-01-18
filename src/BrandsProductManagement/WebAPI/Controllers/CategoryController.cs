

using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using Core.Application.Request;
using Core.Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    public class CategoryController : BaseController
    {
        [Authorize(Roles = "Category_User,Admin")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            if (mediator == null)
                return BadRequest();

            CreatedCategoryResponse response = await mediator.Send(createCategoryCommand);

            return Created(
            string.Empty,
            ApiResponse<CreatedCategoryResponse>.SuccessResponse(
                response,
                  "Kategori eklendi."
                    )
        );


        }

        [HttpGet]
        [Authorize(Roles = "Category_User,Admin")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest? pageRequest)
        {

            var query = new GetListCategoryQuery
            {
                PageRequest = pageRequest?.IsValid == true ? pageRequest : null
            };

            GetListResponse<GetListCategoryListItemDto> getListResponse = await mediator.Send(query);

            return Ok(getListResponse);
        }
        [HttpGet]
        [Authorize(Roles = "Category_User,Admin")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            GetByIdCategoryQuery getByIdCategoryQuery = new() { Id = id };
            GetByIdCategoryResponse response = await mediator.Send(getByIdCategoryQuery);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Category_User,Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            UpdateCategoryResponse response = await mediator.Send(updateCategoryCommand);

            return Ok(
       ApiResponse<UpdateCategoryResponse>.SuccessResponse(
           response,
           "Kategori başarıyla güncellendi"
       )
 );
        }

        [HttpDelete]
        [Authorize(Roles = "Category_User,Admin")]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)

        {
            DeleteCategoryCommand deleteCategory = new() { Id = Id };
            DeleteCategoryResponse response = await mediator.Send(deleteCategory);

            return Ok(
        ApiResponse<DeleteCategoryResponse>.SuccessResponse(
            response,
            "Kategori başarıyla silindi"
        )
  );
        }
    }
}