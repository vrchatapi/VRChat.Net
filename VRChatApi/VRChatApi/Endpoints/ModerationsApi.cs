using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VRChatApi.Classes;
using VRChatApi.Logging;

namespace VRChatApi.Endpoints
{
    public class ModerationsApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerations()
        {
            Logger.Trace(() => "Get list of moderations made by current user");

            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderations");

            return await Utils.ParseResponse<List<PlayerModeratedResponse>>(response);
        }

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerated()
        {
            Logger.Trace(() => "Get list of moderations made against current user");

            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderated");

            return await Utils.ParseResponse<List<PlayerModeratedResponse>>(response);
        }
    }
}
