using Microsoft.AspNetCore.Mvc;
using SchoolRecords.ApplicationServices.Schoolings.Commands.Query;
using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using SchoolRecords.ApplicationServices.Users.Commands.DeleteUser;
using SchoolRecords.ApplicationServices.Users.Commands.UpdateUser;
using SchoolRecords.ApplicationServices.Users.Queries.GetAllUsers;

namespace SchoolRecords.Api.Controllers
{
    public class UserController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return CustomResponse(await Mediator.Send(new GetAllUsersQuery()));
        }

        [HttpGet("schooling")]
        public async Task<IActionResult> GetAllSchooling()
        {
            return CustomResponse(await Mediator.Send(new GetAllSchoolingQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] AddUserCommand request)
        {
            var response = await Mediator.Send(request);
            return CustomResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUSer(int id)
        {
            var response = await Mediator.Send(new DeleteUserCommand() { UserId = id});
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
