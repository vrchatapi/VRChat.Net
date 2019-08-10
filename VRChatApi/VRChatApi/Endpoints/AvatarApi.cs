using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;
using VRChatApi.Logging;

namespace VRChatApi.Endpoints
{
    public class AvatarApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<AvatarResponse> GetById(string id)
        {
            Logger.Debug(() => $"Getting avatar details using ID: {id}");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars/{id}?apiKey={Global.ApiKey}");

            return await Utils.ParseResponse<AvatarResponse>(response);
        }
        public async Task<List<AvatarResponse>> Personal(ReleaseStatus releaseStatus = ReleaseStatus.All, int amount = 100) => await List(releaseStatus: releaseStatus, amount: amount, user: "me");

         public async Task<List<AvatarResponse>> List(ReleaseStatus releaseStatus = ReleaseStatus.All, int amount = 100, string user = null)
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(user)) sb.Append($"&user={user}");
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars?apiKey={Global.ApiKey}&releaseStatus={releaseStatus.GetDescription()}&n={amount}{sb.ToString()}");
            return await Utils.ParseResponse<List<AvatarResponse>>(response);
        }

        public async Task<List<AvatarResponse>> Favorites(int amount = 16)
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars/favorites?apiKey={Global.ApiKey}&n={amount}");
            return await Utils.ParseResponse<List<AvatarResponse>>(response);
        }
    }
}
