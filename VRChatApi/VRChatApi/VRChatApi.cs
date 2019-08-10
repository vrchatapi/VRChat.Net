using System;
using System.Net.Http;
using System.Text;
using VRChatApi.Endpoints;
using VRChatApi.Logging;

namespace VRChatApi
{
    public class VRChatApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public RemoteConfig RemoteConfig { get; set; }
        public UserApi UserApi { get; set; }
        public FriendsApi FriendsApi { get; set; }
        public WorldApi WorldApi { get; set; }
        public ModerationsApi ModerationsApi { get; set; }
        public AvatarApi AvatarApi { get; set; }
        public FavouriteApi FavouriteApi { get; set; }
        public NotificationsAPI NotificationsAPI { get; set; }

        public VRChatApi(string username, string password)
        {
            Logger.Trace(() => $"Entering {nameof(VRChatApi)} constructor");
            Logger.Debug(() => $"Using username {username}");

            // initialize endpoint classes
            RemoteConfig = new RemoteConfig();
            UserApi = new UserApi(username, password);
            FriendsApi = new FriendsApi();
            WorldApi = new WorldApi();
            ModerationsApi = new ModerationsApi();
            AvatarApi = new AvatarApi();
            FavouriteApi = new FavouriteApi();
            NotificationsAPI = new NotificationsAPI();

            // initialize http client
            // TODO: use the auth cookie
            if (Global.HttpClient == null)
            {
                Logger.Trace(() => $"Instantiating {nameof(HttpClient)}");
                Global.HttpClient = new HttpClient();
                Global.HttpClient.BaseAddress = new Uri("https://api.vrchat.cloud/api/1/");
                Logger.Info(() => $"VRChat API base address set to {Global.HttpClient.BaseAddress}");
            }

            string authEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{UserApi.Username}:{UserApi.Password}"));

            var header = Global.HttpClient.DefaultRequestHeaders;

            if (header.Contains("Authorization"))
            {
                Logger.Debug(() => "Removing existing Authorization header");
                header.Remove("Authorization");
            }

            header.Add("Authorization", $"Basic {authEncoded}");

            Logger.Trace(() => $"Added new Authorization header");
        }
    }
}
