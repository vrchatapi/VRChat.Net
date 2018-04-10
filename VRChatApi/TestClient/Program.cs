using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChatApi;
using VRChatApi.Classes;

namespace TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            VRChatApi.VRChatApi api = new VRChatApi.VRChatApi("avail", "");

            // remote config
            ConfigResponse config = await api.RemoteConfig.Get();

            // user api
            UserResponse user = await api.UserApi.Login();
            //UserResponse userNew = await api.UserApi.Register("someName", "somePassword", "some@email.com");
            //UserResponse userUpdated = await api.UserApi.UpdateInfo(user.id, null, null, null, new List<string>() { "admin_moderator", "admin_scripting_access", "system_avatar_access", "system_world_access" });

            // friends
            //List<UserBriefResponse> friends = await api.FriendsApi.Get(0, 20, true);
            //NotificationResponse friendRequestResponse = await api.FriendsApi.SendRequest("usr_f8220fc0-e6f9-45ab-8d9f-ae00e8491685", api.UserApi.Username);
            //string friendDeletionResponse = await api.FriendsApi.DeleteFriend("usr_f8220fc0-e6f9-45ab-8d9f-ae00e8491685");
            //await api.FriendsApi.AcceptFriend("usr_f8220fc0-e6f9-45ab-8d9f-ae00e8491685");
        }
    }
}
