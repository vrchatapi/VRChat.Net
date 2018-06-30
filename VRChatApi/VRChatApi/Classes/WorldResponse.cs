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
    public class UnityPackage
    {
        public string id { get; set; }
        public string assetUrl { get; set; }
        public string pluginUrl { get; set; }
        public string unityVersion { get; set; }
        public int unitySortNumber { get; set; }
        public int assetVersion { get; set; }
        public string platform { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public string createdTime { get; set; }
    }

    public class WorldInstance
    {
        public string id { get; set; }
        public int occupants { get; set; }
    }

    public class WorldResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool featured { get; set; }
        public string authorId { get; set; }
        public string authorName { get; set; }
        public int totalLikes { get; set; }
        public int totalVisits { get; set; }
        public short capacity { get; set; }
        public List<string> tags { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ReleaseStatus releaseStatus { get; set; }
        public string imageUrl { get; set; }
        public string thumbnailImageUrl { get; set; }
        public string assetUrl { get; set; }
        public string pluginUrl { get; set; }
        public string unityPackageUrl { get; set; }
        [JsonProperty(PropertyName = "namespace")]
        public string nameSpace { get; set; } // Unknown
        public bool unityPackageUpdated { get; set; } // Unknown
        public List<UnityPackage> unityPackages { get; set; }
        public bool isSecure { get; set; } // Unknown
        public bool isLockdown { get; set; } // Unknown
        public int version { get; set; }
        public string organization { get; set; } // Unknown
        [JsonProperty(PropertyName = "instances")]
        public List<JArray> _instances { get; set; }
        [JsonIgnore]
        public List<WorldInstance> instances { get; set; }
        public int occupants { get; set; }
    }
}
