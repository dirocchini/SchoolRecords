using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
