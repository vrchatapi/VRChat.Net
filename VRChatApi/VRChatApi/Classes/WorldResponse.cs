using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class WorldInstance
    {
        public string id { get; set; }
        public int occupants { get; set; }
    }

    public class WorldResponse : WorldBriefResponse
    {
        public string description { get; set; }
        public bool featured { get; set; }
        public int totalLikes { get; set; }
        public int totalVisits { get; set; }
        public string assetUrl { get; set; }
        public string pluginUrl { get; set; }
        public string unityPackageUrl { get; set; }
        [JsonProperty(PropertyName = "namespace")]
        public string nameSpace { get; set; } // Unknown
        public bool unityPackageUpdated { get; set; } // Unknown
        public bool isSecure { get; set; } // Unknown
        public bool isLockdown { get; set; } // Unknown
        public int version { get; set; }
        [JsonProperty(PropertyName = "instances")]
        public List<JArray> _instances { get; set; }
        [JsonIgnore]
        public List<WorldInstance> instances { get; set; }
    }
}
