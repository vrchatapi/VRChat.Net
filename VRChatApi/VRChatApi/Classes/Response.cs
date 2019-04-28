using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRChatApi.Classes
{
    public class Response
    {
        public object Content { get; set; }
        public object Status { get; set; }
        public Response(object content, object status) {
            Content = content; Status = status;
        }
    }
    public class ErrorResponse
    {
        public ErrorMessage Error { get; set; }
        public class ErrorMessage
        {
                public string Message { get; set; }
                public int status_code { get; set; }
                [JsonIgnore]
                public System.Net.HttpStatusCode StatusCode { get { return (System.Net.HttpStatusCode)status_code; } }
        }
    }
    public class BanResponse : ErrorResponse
    {
        [JsonIgnore]
        public bool Banned { get { return (ExpiresAt < DateTime.Now) ? true : false; } }
        public string Target { get; set; }
        public string Reason { get; set; }
        public string Expires { get;  set; }
        [JsonIgnore]
        public DateTime ExpiresAt { get { return Convert.ToDateTime(Expires); } }
        [JsonIgnore]
        public TimeSpan ExpiresIn { get { return ExpiresAt - DateTime.Now; } }
    }
}
