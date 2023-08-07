namespace SchoolRecords.ApplicationServices.Interfaces
{
    public interface IApplicationContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
