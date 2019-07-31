using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;

namespace VRChatApi.Endpoints
{
    public class FavouriteApi
    {

        public async Task<FavouriteResponse> FavouriteAvatar(string avatarId)
        {
            JObject json = new JObject()
            {
                { "type", "avatar" },
                { "favoriteId", avatarId },
                { "tags", new JArray(new[] { "avatars1" })}
            };

            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Global.HttpClient.PostAsync($"favorites?apiKey={Global.ApiKey}", content);

            return await Utils.ParseResponse<FavouriteResponse>(response);
        }

        public async Task<List<FavouriteResponse>> GetFavourites(string favouriteType = "avatar")
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"favorites?type={favouriteType}&apiKey={Global.ApiKey}");

            return await Utils.ParseResponse<List<FavouriteResponse>>(response);
        }

        public async Task<FavouriteResponse> GetFavourite(string favouriteId)
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"favorites/{favouriteId}?apiKey={Global.ApiKey}");

            return await Utils.ParseResponse<FavouriteResponse>(response);
        }
    }
}
