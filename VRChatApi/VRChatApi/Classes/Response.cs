using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRChatApi.Classes
{
    public class Response
    {
        public object Content { get; set; }
        public StatusMessage Status { get; set; }
        public class StatusMessage
        {
                public string Message { get; set; }
                public System.Net.HttpStatusCode StatusCode { get; set; }
                public StatusMessage(string message, int statusCode)
                {
                    Message = message;
                    StatusCode = (System.Net.HttpStatusCode)statusCode;
                }
        }
    }
    public class BanResponse : Response
    {
        public bool Banned { get { return (Reason != null) ? true : false; } }
        public string Reason { get; set; }
        [JsonProperty(PropertyName = "expires")]
        private string _expires { get;  set; }
        [JsonIgnore]
        public DateTime Expires { get { return Convert.ToDateTime(_expires); } }
        public BanResponse(string reason, string expires)
        {
            Reason = reason;
            // Expires = Convert.ToDateTime(_expires);
        }
    }
}
