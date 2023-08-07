using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using SchoolRecords.ApplicationServices.Users.Commands.DeleteUser;
using SchoolRecords.ApplicationServices.Users.Commands.UpdateUser;

namespace SchoolRecords.Api.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "working...";
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] AddUserCommand request)
        {
            var response = await Mediator.Send(request);
            return CustomResponse(response);
        }

        [HttpDelete]
        public async Task<IActionResult> AddNewUser([FromBody] DeleteUserCommand request)
        {
            var response = await Mediator.Send(request);
            return CustomResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand request)
        {
            var response = await Mediator.Send(request);
            return CustomResponse(response);
        }
    }
}
