using Newtonsoft.Json;
using System;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class NotificationDetails
    {
        public string WorldId { get; set; }
        [JsonIgnore]
        public bool rsvp { get; set; }
        public string WorldName { get; set; }
    }

    public class NotificationResponse : Response
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUserId { get; set; }
        public string Message { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public string Created { get; set; }
        public DateTime CreatedAt { get { return Convert.ToDateTime(Created); } }
        public string JobName { get; set; }
        public string JobColor { get; set; }
    }
    public class NotificationResponseWithDetails : NotificationResponse
    {
        public NotificationDetails Details { get; set; }
    }
    public class NotificationResponseWithSeen : NotificationResponse
    {
        public bool Seen { get; set; }
    }
}
