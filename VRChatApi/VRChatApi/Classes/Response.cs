using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VRChatApi.Classes
{
    public class Response
    {
        public object Content { get; set; }
        public object Status { get; set; }
        public HttpResponseMessage Raw { get; set; }
        public async Task<Response> FromResponseMessageAsync(HttpResponseMessage response) { // , object content = null
            // if (content != null) Content = content;
            if (response != null) {
                Raw = response;
                string json = await response.Content.ReadAsStringAsync();
                try { Status = JsonConvert.DeserializeObject<Success>(json);
                } catch { Status = JsonConvert.DeserializeObject<Error>(json); }
            }
            return this;
        }
    }
    public class Message
    {
            [JsonProperty(PropertyName = "message")]
            public string _message { get; set; }
            [JsonIgnore]
            public string Content { get { return _message; } }
            public int status_code { get; set; }
            [JsonIgnore]
            public System.Net.HttpStatusCode StatusCode { get { return (System.Net.HttpStatusCode)status_code; } }
    }

    public class Success
    {
        public Message success { get; set; }
    }
    public class Error
    {
        public Message error { get; set; }
    }
    public class BanResponse : Error
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
