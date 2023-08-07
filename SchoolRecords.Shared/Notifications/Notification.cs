using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
