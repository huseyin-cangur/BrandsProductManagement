

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator? mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
