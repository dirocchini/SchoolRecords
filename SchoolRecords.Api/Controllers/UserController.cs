using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolRecords.ApplicationServices.Users.Commands.AddUser;

namespace SchoolRecords.Api.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "asdasdasd";
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] AddUserCommand request)
        {
            var response = await Mediator.Send(request);
            return CustomResponse(response);
        }
    }
}
