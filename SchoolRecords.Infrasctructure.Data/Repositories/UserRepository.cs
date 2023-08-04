using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Interfaces;
using SchoolRecords.Infrasctructure.Data.Context;
using SchoolRecords.Infrasctructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.Infrasctructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SchoolRecordsContext context) : base(context)
        {
        }
    }
}
