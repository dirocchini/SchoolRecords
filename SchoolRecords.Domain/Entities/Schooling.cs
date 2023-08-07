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
        public SchoolingTypeEnum Type { get; set; }
        public string Description { get; set; }
    }

    public enum SchoolingTypeEnum
    {
        Infantil = 1,
        Fundamental = 2,
        Medio = 3,
        Superior = 4
    }
}
