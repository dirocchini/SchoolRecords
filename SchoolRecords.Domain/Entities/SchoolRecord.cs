using SchoolRecords.Domain.Entities.Base;

namespace SchoolRecords.Domain.Entities
{
    public class SchoolRecord : BaseEntity
    {
        public string Format { get; set; }
        public string Name { get; set; }
    }
}
