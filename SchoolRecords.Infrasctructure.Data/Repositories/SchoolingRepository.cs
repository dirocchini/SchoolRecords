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
    internal class SchoolingRepository : BaseRepository<Schooling>, ISchoolingRepository
    {
        public SchoolingRepository(SchoolRecordsContext context) : base(context)
        {
        }
    }
}
