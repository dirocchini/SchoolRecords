using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using SchoolRecords.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.ApplicationServices.Interfaces
{
    public interface IUserAppService
    {
        Task<User> AddUser(AddUserCommand request);
    }
}
