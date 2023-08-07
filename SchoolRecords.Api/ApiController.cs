using Microsoft.AspNetCore.Mvc;
using System.Net;
using SchoolRecords.Api.Common;

namespace SchoolRecords.Api
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
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
