using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class PlayerModeratedResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string sourceUserId { get; set; }
        public string sourceDisplayName { get; set; }
        public string targetUserId { get; set; }
        public string targetDisplayName { get; set; }
        public DateTime created { get; set; }
    }
}
