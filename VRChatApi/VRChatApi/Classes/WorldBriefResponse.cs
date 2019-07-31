using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class WorldBriefResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string authorId { get; set; }
        public string authorName { get; set; }
        public int capacity { get; set; }
        public string imageUrl { get; set; }
        public string thumbnailImageUrl { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ReleaseStatus releaseStatus { get; set; }

        public string organization { get; set; }
        public List<string> tags { get; set; }
        public int favorites { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime publicationDate { get; set; }
        public DateTime labsPublicationDate { get; set; }
        public int visits { get; set; }
        public List<UnityPackage> unityPackages { get; set; }
        public int popularity { get; set; }
        public int heat { get; set; }
        public int occupants { get; set; }
    }
}
