using SchoolRecords.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public int? SchoolingId { get; set; }
        public Schooling Schooling { get; set; }

        public int? SchoolRecordId { get; set; }
        public SchoolRecord SchoolRecord { get; set; }
    }
}
