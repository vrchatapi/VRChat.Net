using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace VRChatApi.Classes
{
    public class UserStatus
    {
        public enum Status
        {
            Unknown, Offline, Busy, Active, JoinMe
        }
        public Status FromString(string status)
        {
            switch (status.ToLowerInvariant())
            {
                case "join me":
                    return Status.JoinMe;
                case "active":
                    return Status.Active;
                case "busy":
                    return Status.Busy;
                case "offline":
                    return Status.Offline;
                default:
                    return Status.Unknown;
            }
        }
        public string ToString(Status status)
        {
            switch (status)
            {
                case Status.Offline: return "offline";
                case Status.Busy: return "busy";
                case Status.Active: return "active";
                case Status.JoinMe: return "join me";
                default: return "";
            }
        }
    }
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
