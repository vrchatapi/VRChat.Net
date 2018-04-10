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

            ConfigResponse config = await api.GetConfig();

            UserResponse user = await api.PerformLogin();

            Console.WriteLine(config.address);
        }
    }
}
