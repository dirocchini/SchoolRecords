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
        Task AddUser(User user);
    }
}
