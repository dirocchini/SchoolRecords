using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolRecords.Api.Common;
using System.Net;

namespace SchoolRecords.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();





        protected new IActionResult CustomResponse(
               object result = null,
               HttpStatusCode statusCode = HttpStatusCode.OK,
               string message = "")
        {
            var response = new CustomResponse<object>()
            {
                Data = result,
                Message = message
            };

            if (result != null)
            {
                // Handled Error
                // Unhandled Error
                if (result is Exception)
                {
                    response.Message = "Internal Server Error!";

                    return new ObjectResult(response)
                    { StatusCode = (int)HttpStatusCode.InternalServerError };
                }

                // Success
                if (result is object)
                {
                    return new ObjectResult(response)
                    { StatusCode = (int)statusCode };
                }
            }

            return new ObjectResult(response)
            { StatusCode = (int)statusCode };
        }
    }
}
