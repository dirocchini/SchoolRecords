using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolRecords.Api.Controllers
{
    public class BaseController : ApiController
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
