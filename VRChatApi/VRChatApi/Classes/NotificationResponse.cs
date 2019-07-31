using System;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class Details
    {
        public string worldId { get; set; }
        public bool rsvp { get; set; }
        public string worldName { get; set; }
    }

    public class NotificationResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string senderUserId { get; set; }
        public string senderUsername { get; set; }
        public string receiverUserId { get; set; }
        public string message { get; set; }
        public Details details { get; set; }
        public DateTime created_at { get; set; }
        public string jobName { get; set; }
        public string jobColor { get; set; }
    }
}
