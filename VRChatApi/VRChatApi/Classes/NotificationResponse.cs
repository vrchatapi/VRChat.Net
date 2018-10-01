using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VRChatApi.Classes
{
    public class NotificationResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string senderUserId { get; set; }
        public string receiverUserId { get; set; }
        public string message { get; set; }
        public JObject details { get; set; } // unknown
        public string jobName { get; set; }
        public string jobColor { get; set; }

        [Obsolete("Typoed property, use receiverUserId instead")]
        [JsonIgnore]
        public string recieverUserId { get => receiverUserId; set => receiverUserId = value; }
    }
}
