using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VRChatApi.Classes;


namespace VRChatApi.Endpoints
{
    public class WorldApi
    {
        public async Task<WorldResponse> Get(string id)
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"worlds/{id}?apiKey={Global.ApiKey}");

            WorldResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<WorldResponse>();

                // Parse instances.
                res.instances = res._instances.Select(data => new WorldInstance()
                {
                    id = (string)data[0],
                    occupants = (int)data[1]
                }).ToList();
            }

            return res;
        }
    }
}
