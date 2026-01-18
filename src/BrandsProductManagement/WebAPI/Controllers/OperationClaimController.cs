
using Application.Features.Claims.Queries.GetList;
using Core.Application.Request;
using Core.Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class OperationClaimController : BaseController
    {
        [Authorize(Roles ="Admin")]
        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery]PageRequest pageRequest)
        {

            var query = new GetListClaimQuery { PageRequest = pageRequest };

            GetListResponse<GetListClaimItemDto> getListResponse = await mediator.Send(query);

            return Ok(getListResponse);
        }
    }
}