namespace SchoolRecords.ApplicationServices.Users.Commands.UpdateUser
{
    public class UpdatedUserVm
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string SchoolingType { get; set; }
    }
}