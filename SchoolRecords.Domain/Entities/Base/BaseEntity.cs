namespace SchoolRecords.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
