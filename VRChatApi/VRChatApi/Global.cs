using System.Net.Http;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VRChatApi.Tests")]

namespace VRChatApi
{
    static class Global
    {
        public static HttpClient HttpClient = null;
        public static string ApiKey = "JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26";
    }
}
