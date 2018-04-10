using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatApi.Classes
{
    public class NotificationResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string senderUserId { get; set; }
        public string recieverUserId { get; set; }
        public string message { get; set; }
        public JObject details { get; set; } // unknown
        public string jobName { get; set; }
        public string jobColor { get; set; }
    }
}
