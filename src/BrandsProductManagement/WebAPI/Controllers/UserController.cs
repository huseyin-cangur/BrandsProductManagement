
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using Core.Application.Request;
using Core.Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
        {
            if (mediator == null)
                return BadRequest();

            CreatedUserResponse response = await mediator.Send(createUserCommand);

            return Created(
            string.Empty,
            ApiResponse<CreatedUserResponse>.SuccessResponse(
                response,
                  "Kullanıcı eklendi."
                    )
        );


        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {

            var query = new GetListUserQuery { PageRequest = pageRequest };


            GetListResponse<GetListUserListItemDto> getListResponse = await mediator.Send(query);

            return Ok(getListResponse);
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            GetByIdUserQuery getByIdUserQuery = new() { Id = id };
            GetByIdUserResponse response = await mediator.Send(getByIdUserQuery);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdateUserResponse response = await mediator.Send(updateUserCommand);

            return Ok(
       ApiResponse<UpdateUserResponse>.SuccessResponse(
           response,
           "Kullanıcı başarıyla güncellendi"
       )
 );
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)

        {
            DeleteUserCommand deleteUser = new() { Id = Id };
            DeleteUserResponse response = await mediator.Send(deleteUser);

            return Ok(
        ApiResponse<DeleteUserResponse>.SuccessResponse(
            response,
            "Kullanıcı başarıyla silindi"
        )
  );
        }
    }
}
