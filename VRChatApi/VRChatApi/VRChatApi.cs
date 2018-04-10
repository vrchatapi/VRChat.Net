using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VRChatApi.Classes;

namespace VRChatApi
{
    public class VRChatApi
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }

        private string m_apiKey { get; set; }
        private string m_authCookie { get; set; }

        public VRChatApi(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public async Task<UserResponse> PerformLogin()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"auth/user?apiKey={Global.ApiKey}");

            UserResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<UserResponse>();
            }

            return res;
        }

        public async Task<ConfigResponse> GetConfig()
        {
            // since this is the first function that will be called, we will initialize the http client here.
            // TODO: use the auth cookie
            if (Global.HttpClient == null)
            {
                Global.HttpClient = new HttpClient();
                Global.HttpClient.BaseAddress = new Uri("https://api.vrchat.cloud/api/1/");

                string authEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Username}:{Password}"));
                Global.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {authEncoded}");
            }

            HttpResponseMessage response = await Global.HttpClient.GetAsync("config");

            ConfigResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<ConfigResponse>();
                Global.ApiKey = res.clientApiKey;
            }

            return res;
        }
    }
}
