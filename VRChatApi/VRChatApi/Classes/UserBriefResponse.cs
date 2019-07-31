using System.Collections.Generic;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class UserBriefResponse
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string currentAvatarImageUrl { get; set; }
        public string currentAvatarThumbnailImageUrl { get; set; }
        public string last_platform { get; set; }
        public List<string> tags { get; set; }
        public string developerType { get; set; }
        public string status { get; set; }
        public string statusDescription { get; set; }
        public string friendKey { get; set; }
        public bool isFriend { get; set; }
        public string location { get; set; }
    }
}
