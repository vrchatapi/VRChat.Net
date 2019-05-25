using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VRChatApi.Classes
{
    public class NotificationDetails
    {
        public string WorldId { get; set; }
        public string WorldName { get; set; }
    }
    public class NotificationResponse
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUserId { get; set; }
        public string Message { get; set; }
        public NotificationDetails Details { get; set; } // unknown
        [JsonProperty(PropertyName = "created_at")]
        public string Created { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get { return Convert.ToDateTime(Created); } }
        public string JobName { get; set; }
        public string JobColor { get; set; }

        [Obsolete("Typoed property, use receiverUserId instead")]
        [JsonIgnore]
        public string recieverUserId { get => ReceiverUserId; set => ReceiverUserId = value; }
    }
    public class NotificationResponseWithSeen : NotificationResponse
    {
        public bool Seen { get; set; }
    }
}
