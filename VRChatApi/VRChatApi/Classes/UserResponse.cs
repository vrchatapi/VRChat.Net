using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatApi.Classes
{
    public class PastDisplayName
    {
        string displayName { get; set; }
        string updated_at { get; set; }
    }

    public class UserResponse
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public List<PastDisplayName> pastDisplayNames { get; set; }
        public bool hasEmail { get; set; }
        public string obfuscatedEmail { get; set; }
        public bool emailVerified { get; set; }
        public bool hasBirthday { get; set; }
        public bool unsubscribe { get; set; }
        public List<string> friends { get; set; }
        public JObject blueprints { get; set; }
        public JObject currentAvatarBlueprint { get; set; }
        public List<string> events { get; set; }
        public string currentAvatar { get; set; }
        public string currentAvatarImageUrl { get; set; }
        public string currentAvatarAssetUrl { get; set; }
        public string currentAvatarThumbnailImageUrl { get; set; }
        public int acceptedTOSVersion { get; set; }
        public JObject steamDetails { get; set; }
        public bool hasLoggedInFromClient { get; set; }
        public List<string> tags { get; set; }
        public string developerType { get; set; }
        public string authToken { get; set; }
    }
}
