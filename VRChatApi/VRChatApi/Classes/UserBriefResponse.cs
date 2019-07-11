using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace VRChatApi.Classes
{
    public class UserBriefResponse
    {
        [JsonIgnore]
        public bool Offline { get; set; }
        public string id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string currentAvatarImageUrl { get; set; }
        public string currentAvatarThumbnailImageUrl { get; set; }
        public string developerType { get; set; }
        public List<string> tags { get; set; }
        public string status { get; set; }
        public string statusDescription { get; set; }
        public string location { get; set; }
        public string worldId { get; set; }
        public string instanceId { get; set; }
        [JsonIgnore]
        public HttpResponseMessage Raw { get; set; }
    }
}
