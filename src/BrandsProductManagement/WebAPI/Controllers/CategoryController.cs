

using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using Core.Application.Request;
using Core.Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            if (mediator == null)
                return BadRequest();

            CreatedCategoryResponse response = await mediator.Send(createCategoryCommand);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListCategoryQuery getListCategoryQuery = new() { PageRequest = pageRequest };

            GetListResponse<GetListCategoryListItemDto> getListResponse = await mediator.Send(getListCategoryQuery);

            return Ok(getListResponse);
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            GetByIdCategoryQuery getByIdCategoryQuery = new() { Id = id };
            GetByIdCategoryResponse response = await mediator.Send(getByIdCategoryQuery);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            UpdateCategoryResponse response = await mediator.Send(updateCategoryCommand);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)

        {
            DeleteCategoryCommand deleteCategory = new() { Id = Id };
            DeleteCategoryResponse response = await mediator.Send(deleteCategory);

            return Ok(response);
        }
    }
}