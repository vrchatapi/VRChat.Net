using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;

namespace VRChatApi.Endpoints
{
    public class UserApi
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserApi(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public async Task<UserResponse> Login()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"auth/user?apiKey={Global.ApiKey}");

            UserResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<UserResponse>();
            }

            return res;
        }

        public async Task<UserResponse> Register(string username, string password, string email, string birthday = null, string acceptedTOSVersion = null)
        {
            JObject json = new JObject();
            json["username"] = username;
            json["password"] = password;
            json["email"] = email;
            json["birthday"] = birthday;
            json["acceptedTOSVersion"] = acceptedTOSVersion;

            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Global.HttpClient.PostAsync($"auth/register?apiKey={Global.ApiKey}", content);

            UserResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<UserResponse>();
            }

            return res;
        }
    }
}
