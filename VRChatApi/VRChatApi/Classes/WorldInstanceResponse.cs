using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
