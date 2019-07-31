using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VRChatApi.Classes;
using VRChatApi.Logging;


namespace VRChatApi.Endpoints
{
    public class WorldApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<WorldResponse> Get(string id)
        {
            Logger.Debug(() => $"Getting world info with ID: {id}");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"worlds/{id}?apiKey={Global.ApiKey}");

            var res = await Utils.ParseResponse<WorldResponse>(response);

            // parse instances
            res.instances = res._instances.Select(data => new WorldInstance()
            {
                id = (string)data[0],
                occupants = (int)data[1]
            }).ToList();

            return res;
        }

        public async Task<List<WorldBriefResponse>> Search(WorldGroups? endpoint = null, bool? featured = null,
            SortOptions? sort = null, UserOptions? user = null,
            string userId = null, string keyword = null, string tags = null, string excludeTags = null,
            ReleaseStatus? releaseStatus = null, int offset = 0, int count = 20)
        {
            Logger.Debug(() => "Getting world list");

            var param = new StringBuilder();

            param.Append($"&n={count}");
            param.Append($"&offset={offset}");

            if (featured.HasValue)
            {
                param.Append($"&featured={featured.Value}");

                if (featured.Value && sort.HasValue == false)
                {
                    param.Append("&sort=order");
                }
            }

            if (sort.HasValue)
            {
                param.Append($"&sort={sort.Value.ToString().ToLowerInvariant()}");

                if (sort.Value == SortOptions.Popularity && featured.HasValue == false)
                {
                    param.Append("&featured=false");
                }
            }

            if (user.HasValue)
            {
                param.Append($"&user={user.Value.ToString().ToLowerInvariant()}");
            }

            if (!string.IsNullOrEmpty(userId))
            {
                param.Append($"&userId={userId}");
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                param.Append($"&search={keyword}");
            }

            if (!string.IsNullOrEmpty(tags))
            {
                param.Append($"&tag={tags}");
            }

            if (!string.IsNullOrEmpty(excludeTags))
            {
                param.Append($"&notag={excludeTags}");
            }

            if (releaseStatus.HasValue)
            {
                param.Append($"&releaseStatus={releaseStatus.Value.ToString().ToLowerInvariant()}");
            }

            string baseUrl = "worlds";

            if (endpoint.HasValue)
            {
                switch (endpoint.Value)
                {
                    case WorldGroups.Active:
                        baseUrl = "worlds/active";
                        break;
                    case WorldGroups.Recent:
                        baseUrl = "worlds/recent";
                        break;
                    case WorldGroups.Favorite:
                        baseUrl = "worlds/favorites";
                        break;
                }
            }

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"{baseUrl}?apiKey={Global.ApiKey}{param.ToString()}");

            return await Utils.ParseResponse<List<WorldBriefResponse>>(response);
        }

        public async Task<WorldMetadataResponse> GetMetadata(string id)
        {
            Logger.Debug(() => $"Getting world metadata with ID: {id}");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"worlds/{id}/metadata?apiKey={Global.ApiKey}");

            return await Utils.ParseResponse<WorldMetadataResponse>(response);
        }

        public async Task<WorldInstanceResponse> GetInstance(string worldId, string instanceId)
        {
            Logger.Debug(() => $"Getting world instance with world ID: {worldId} and instance ID {instanceId}");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"worlds/{worldId}/{instanceId}?apiKey={Global.ApiKey}");

            WorldInstanceResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                string text = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {text}");
                var json = JObject.Parse(text);

                res = new WorldInstanceResponse
                {
                    id = json["id"].ToString(),
                    name = json["name"].ToString(),
                    privateUsers = (json["private"] is JArray)
                        ? json["private"].Select(tk => tk.ToObject<WorldInstanceUserResponse>()).ToList() : null,
                    friends = (json["friends"] is JArray)
                        ? json["friends"].Select(tk => tk.ToObject<WorldInstanceUserResponse>()).ToList() : null,
                    users = (json["users"] is JArray)
                        ? json["users"].Select(tk => tk.ToObject<WorldInstanceUserResponse>()).ToList() : null,
                    hidden = (json["hidden"] == null || json["hidden"].Type == JTokenType.Null) ? null : json["hidden"].ToString(),
                    nonce = json["nonce"]?.ToString(),
                };
            }

            response.Dispose();

            return res;
        }
    }
}
