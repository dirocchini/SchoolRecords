namespace SchoolRecords.Shared.Notifications
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;

        public IReadOnlyCollection<Notification> Notifications => this._notifications;

        public bool Succeeded => !this._notifications.Any();

        public NotificationContext()
        {
            this._notifications = new List<Notification>();
        }

        public void AddNotification(string key, string message)
        {
            this._notifications.Add(new Notification(key, message));
        }

        public void AddNotification(Notification notification)
        {
            this._notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }
    }
}
