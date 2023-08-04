using SchoolRecords.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.Domain.Entities
{
    public class SchoolRecord : BaseEntity
    {
        public string Format { get; set; }
        public string Name { get; set; }
    }
}
