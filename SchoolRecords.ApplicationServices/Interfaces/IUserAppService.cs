using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using SchoolRecords.ApplicationServices.Users.Commands.UpdateUser;
using SchoolRecords.Domain.Entities;

namespace SchoolRecords.ApplicationServices.Interfaces
{
    public interface IUserAppService
    {
        Task<User> AddUser(AddUserCommand request);
        Task<bool?> DeleteUser(int userId);
        List<User> GetAllActive();
        Task<User> UpdateUser(UpdateUserCommand request);
    }
}
