namespace SchoolRecords.ApplicationServices.Users.Queries.GetAllUsers
{
    public class AllUsersVm
    {
        public AllUsersVm()
        {
            AllUsers = new List<UserVm>();
        }

        public List<UserVm> AllUsers { get; set; }
    }
}
