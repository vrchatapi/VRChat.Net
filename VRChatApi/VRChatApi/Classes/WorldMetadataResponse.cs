using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace VRChatApi.Classes
{
    public class WorldMetadataResponse
    {
        public string id { get; set; }
        public JObject metadata { get; set; }
    }
}
