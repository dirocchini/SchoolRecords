namespace SchoolRecords.Shared.Notifications
{
    public sealed class Notification
    {
        public Notification(string key, string message)
        {
            this.Key = key;
            this.Message = message;
        }

        public string Key { get; }

        public string Message { get; }
    }
}
