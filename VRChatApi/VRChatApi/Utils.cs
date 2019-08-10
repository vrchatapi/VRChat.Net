using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VRChatApi.Logging;
using VRChatApi.Classes;
using System.Reflection;
using System.ComponentModel;

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
            /*switch (T.GetType())
            {
                case typeof(UserBriefResponse):
                    UserBriefResponse res = null;
                    break;
                default:
                    break;
            }
            res.Raw = responseMessage;*/
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
    static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null) {
                FieldInfo field = type.GetField(name);
                if (field != null) {
                    DescriptionAttribute attr =  Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null) {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}
