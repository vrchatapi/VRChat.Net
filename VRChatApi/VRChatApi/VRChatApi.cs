using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VRChatApi.Classes;
using VRChatApi.Endpoints;

namespace VRChatApi
{
    public class VRChatApi
    {
        public RemoteConfig RemoteConfig { get; set; }
        public UserApi UserApi { get; set; }
        public FriendsApi FriendsApi { get; set; }

        public VRChatApi(string username, string password)
        {
            // initialize endpoint classes
            RemoteConfig = new RemoteConfig();
            UserApi = new UserApi(username, password);
            FriendsApi = new FriendsApi();
            
            // initialize http client
            // TODO: use the auth cookie
            if (Global.HttpClient == null)
            {
                Global.HttpClient = new HttpClient();
                Global.HttpClient.BaseAddress = new Uri("https://api.vrchat.cloud/api/1/");

                string authEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{UserApi.Username}:{UserApi.Password}"));
                Global.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {authEncoded}");
            }
        }
    }
}
