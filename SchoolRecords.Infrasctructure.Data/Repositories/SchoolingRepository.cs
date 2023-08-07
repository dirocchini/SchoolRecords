using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Interfaces;
using SchoolRecords.Infrasctructure.Data.Context;
using SchoolRecords.Infrasctructure.Data.Repositories.Base;

namespace SchoolRecords.Infrasctructure.Data.Repositories
{
    internal class SchoolingRepository : BaseRepository<Schooling>, ISchoolingRepository
    {
        public SchoolingRepository(SchoolRecordsContext context) : base(context)
        {
        }
    }
}
