using SchoolRecords.Domain.Entities;

namespace SchoolRecords.ApplicationServices.Users.Queries.GetAllUsers
{
    public class UserVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public int? SchoolingId { get; set; }
        public Schooling Schooling { get; set; }
    }
}
