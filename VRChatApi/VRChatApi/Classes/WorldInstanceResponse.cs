using System.Collections.Generic;
using Newtonsoft.Json;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class WorldInstanceResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonProperty(PropertyName = "private")]
        public List<WorldInstanceUserResponse> privateUsers { get; set; }
        public List<WorldInstanceUserResponse> friends { get; set; }
        public List<WorldInstanceUserResponse> users { get; set; }
        public string hidden { get; set; }
        public string nonce { get; set; }
    }
}
