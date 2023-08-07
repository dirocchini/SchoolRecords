namespace SchoolRecords.ApplicationServices.Users.Commands.AddUser
{
    public class NewUserVm
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string SchoolingType { get; set; }
    }
}
