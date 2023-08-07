using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Interfaces;
using SchoolRecords.Infrasctructure.Data.Context;
using SchoolRecords.Infrasctructure.Data.Repositories.Base;

namespace SchoolRecords.Infrasctructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SchoolRecordsContext context) : base(context)
        {
        }
    }
}
