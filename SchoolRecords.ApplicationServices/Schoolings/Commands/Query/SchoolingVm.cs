using SchoolRecords.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.ApplicationServices.Schoolings.Commands.Query
{
    public class SchoolingVm
    {
        public int Id { get; set; }
        public SchoolingTypeEnum Type { get; set; }
        public string Description { get; set; }
    }
}
