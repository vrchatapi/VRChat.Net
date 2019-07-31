using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VRChatApi.Logging;

namespace VRChatApi
{
    static class Utils
    {
        public static void AddIfNotNull(this JObject jObject, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                jObject[key] = value;
            }
        }

        public static void AddIfNotNull(this JObject jObject, string key, JToken value)
        {
            if (value.HasValues)
            {
                jObject[key] = value;
            }
        }

        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public static async Task<T> ParseResponse<T>(HttpResponseMessage responseMessage) where T : class
        {
            T res = null;

            if (responseMessage.IsSuccessStatusCode)
            {
                var receivedJson = await responseMessage.Content.ReadAsStringAsync();

                Logger.Debug(() => $"JSON received: {receivedJson}");

                res = JsonConvert.DeserializeObject<T>(receivedJson);
            }

            responseMessage.Dispose();

            return res;
        }
    }
}
