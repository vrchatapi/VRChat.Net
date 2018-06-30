using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace VRChatApi.Classes
{
    public class WorldBriefResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string authorName { get; set; }
        public int totalLikes { get; set; }
        public int totalVisits { get; set; }
        public string imageUrl { get; set; }
        public string thumbnailImageUrl { get; set; }
        public bool isSecure { get; set; } // Unknown
        [JsonConverter(typeof(StringEnumConverter))]
        public ReleaseStatus releaseStatus { get; set; }
        public string organization { get; set; } // Unknown
        public int occupants { get; set; }
    }
}
