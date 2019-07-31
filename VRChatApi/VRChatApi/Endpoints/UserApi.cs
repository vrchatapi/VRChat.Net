using Newtonsoft.Json.Linq;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;
using VRChatApi.Logging;

namespace VRChatApi.Endpoints
{
    public class UserApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public string Username { get; set; }
        public string Password { get; set; }

        public UserApi(string username, string password)
        {
            Logger.Trace(() => $"Entering {nameof(UserApi)} constructor with username: {username}");

            Username = username;
            Password = password;
        }

        public async Task<UserResponse> Login()
        {
            Logger.Trace(() => "Getting current user details");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"auth/user?apiKey={Global.ApiKey}");

            return await Utils.ParseResponse<UserResponse>(response);
        }

        public async Task<UserResponse> Register(string username, string password, string email, string birthday = null, string acceptedTOSVersion = null)
        {
            Logger.Debug(() => $"Registering new user with {nameof(username)} = {username}, {nameof(email)} = {email}, {nameof(birthday)} = {birthday}, {nameof(acceptedTOSVersion)} = {acceptedTOSVersion}");

            JObject json = new JObject()
            {
                { "username", username },
                { "password", password }
            };

            json.AddIfNotNull("email", email);
            json.AddIfNotNull("birthday", birthday);
            json.AddIfNotNull("acceptedTOSVersion", acceptedTOSVersion);

            Logger.Debug(() => $"Prepared JSON to post: {json}");

            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Global.HttpClient.PostAsync($"auth/register?apiKey={Global.ApiKey}", content);

            return await Utils.ParseResponse<UserResponse>(response);
        }

        public async Task<UserBriefResponse> GetById(string userId)
        {
            Logger.Debug(() => $"Getting user info with ID: {userId}");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"users/{userId}?apiKey={Global.ApiKey}");

            return await Utils.ParseResponse<UserBriefResponse>(response);
        }

        public async Task<UserResponse> UpdateInfo(string userId, string email = null, string birthday = null, string acceptedTOSVersion = null, List<string> tags = null)
        {
            Logger.Debug(() => $"Updating user info for {nameof(userId)} = {userId} with {nameof(email)} = {email}, {nameof(birthday)} = {birthday}, {nameof(acceptedTOSVersion)} = {acceptedTOSVersion}, {nameof(tags)} = {tags}");

            JObject json = new JObject();
            json.AddIfNotNull("email", email);
            json.AddIfNotNull("birthday", birthday);
            json.AddIfNotNull("acceptedTOSVersion", acceptedTOSVersion);
            json.AddIfNotNull("tags", JToken.FromObject(tags));

            Logger.Debug(() => $"Prepared JSON to put: {json}");

            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Global.HttpClient.PutAsync($"users/{userId}?apiKey={Global.ApiKey}", content);

            return await Utils.ParseResponse<UserResponse>(response);
        }
    }
}
