using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VRChatApi.Classes
{
    public class NotificationResponse
    {
        public string Id { get; set; }
        public bool Seen { get; set; }
        public string Type { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUserId { get; set; }
        public string Message { get; set; }
        public string Details { get; set; } // unknown
        public string JobName { get; set; }
        public string JobColor { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public string Created { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get { return Convert.ToDateTime(Created); } }

        [Obsolete("Typoed property, use receiverUserId instead")]
        [JsonIgnore]
        public string recieverUserId { get => ReceiverUserId; set => ReceiverUserId = value; }
    }
}
