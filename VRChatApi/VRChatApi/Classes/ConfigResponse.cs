using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatApi.Classes
{
    public class ConfigResponse
    {
        public string messageOfTheDay { get; set; }
        public string timeOutWorldId { get; set; }
        public string gearDemoRoomId { get; set; }
        public string releaseServerVersionStandalone { get; set; }
        public string downloadLinkWindows { get; set; }
        public string releaseAppVersionStandalone { get; set; }
        public string devAppVersionStandalone { get; set; }
        public string devDownloadLinkWindows { get; set; }
        public int currentTOSVersion { get; set; }
        public string releaseSdkUrl { get; set; }
        public string releaseSdkVersion { get; set; }
        public string devSdkUrl { get; set; }
        public string devSdkVersion { get; set; }
        public List<string> whiteListedAssetUrls { get; set; }
        public string clientApiKey { get; set; }
        public string viveWindowsUrl { get; set; }
        public string sdkUnityVersion { get; set; }
        public string hubWorldId { get; set; }
        public string homeWorldId { get; set; }
        public string tutorialWorldId { get; set; }
        public bool disableEventStream { get; set; }
        public bool disableAvatarGating { get; set; }
        public List<string> registrationShitList { get; set; }
        public string plugin { get; set; }
        public string address { get; set; }
        public string contactEmail { get; set; }
        public string supportEmail { get; set; }
        public string jobsEmail { get; set; }
        public string copyrightEmail { get; set; }
        public string moderationEmail { get; set; }
        public string appName { get; set; }
        public string serverName { get; set; }
        public string deploymentGroup { get; set; }
        public string buildVersionTag { get; set; }
        public string apiKey { get; set; }
    }
}
