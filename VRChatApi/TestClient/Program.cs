using System;
using System.Collections.Generic;
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
            VRChatApi.VRChatApi api = new VRChatApi.VRChatApi("username", "password");
            VRChatApi.Logging.LogProvider.SetCurrentLogProvider(new ColoredConsoleLogProvider());

            // remote config
            ConfigResponse config = await api.RemoteConfig.Get();

            // user api
            //UserResponse userNew = await api.UserApi.Register("someName", "somePassword", "some@email.com");
            UserResponse user = await api.UserApi.Login();
            //UserResponse userUpdated = await api.UserApi.UpdateInfo(user.id, null, null, null, new List<string>() { "admin_moderator", "admin_scripting_access", "system_avatar_access", "system_world_access" });

            // friends
            //List<UserBriefResponse> friends = await api.FriendsApi.Get(0, 20, true);
            //NotificationResponse friendRequestResponse = await api.FriendsApi.SendRequest("usr_f8220fc0-e6f9-45ab-8d9f-ae00e8491685", api.UserApi.Username);
            //string friendDeletionResponse = await api.FriendsApi.DeleteFriend("usr_f8220fc0-e6f9-45ab-8d9f-ae00e8491685");
            //await api.FriendsApi.AcceptFriend("usr_f8220fc0-e6f9-45ab-8d9f-ae00e8491685");

            // world api
            var worldId = "wrld_b2d24c29-1ded-4990-a90d-dd6dcc440300"; // The great Pug
            WorldResponse world = await api.WorldApi.Get(worldId);
            //List<WorldBriefResponse> starWorlds = await api.WorldApi.Search(WorldGroups.Favorite, count: 4);
            List<WorldBriefResponse> scaryWorlds = await api.WorldApi.Search(keyword: "Scary", sort: SortOptions.Popularity);
            List<WorldBriefResponse> featuredWorlds = await api.WorldApi.Search(featured: true);
            WorldMetadataResponse metadata = await api.WorldApi.GetMetadata(worldId);
            var instances = new List<WorldInstanceResponse>();
            if (world.instances.Count > 0) {
                foreach(WorldInstance instance in world.instances)
                {
                    WorldInstanceResponse worldInst = await api.WorldApi.GetInstance(world.id, instance.id);
                    instances.Add(worldInst);
                }
            }

            // avatar api
            AvatarResponse avatar = await api.AvatarApi.GetById("avtr_17036f54-f706-46bf-8a43-0c60564123ff");
        }
    }
}
