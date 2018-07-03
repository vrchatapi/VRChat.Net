using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VRChatApi.Classes
{
    public class WorldInstanceUserResponse
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string currentAvatarImageUrl { get; set; }
        public string currentAvatarThumbnailImageUrl { get; set; }
        public List<string> tags { get; set; }
        public string developerType { get; set; }
        public string status { get; set; }
        public string statusDescription { get; set; }
        public string networkSessionId { get; set; }
    }
}
