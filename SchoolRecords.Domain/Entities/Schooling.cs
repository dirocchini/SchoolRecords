using SchoolRecords.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.Domain.Entities
{
    public class Schooling : BaseEntity
    {
        public string Description { get; set; }
    }
}
