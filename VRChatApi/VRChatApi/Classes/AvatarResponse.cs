using System;
using System.Collections.Generic;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class AssetUrlObject
    {
    }

    public class UnityPackage
    {
        public string id { get; set; }
        public string assetUrl { get; set; }
        public AssetUrlObject assetUrlObject { get; set; }
        public string unityVersion { get; set; }
        public long unitySortNumber { get; set; }
        public int assetVersion { get; set; }
        public string platform { get; set; }
        public DateTime created_at { get; set; }
    }

    public class UnityPackageUrlObject
    {
        public string unityPackageUrl { get; set; }
    }

    public class AvatarResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string authorId { get; set; }
        public string authorName { get; set; }
        public List<string> tags { get; set; }
        public string assetUrl { get; set; }
        public AssetUrlObject assetUrlObject { get; set; }
        public string imageUrl { get; set; }
        public string thumbnailImageUrl { get; set; }
        public string releaseStatus { get; set; }
        public int version { get; set; }
        public bool featured { get; set; }
        public List<UnityPackage> unityPackages { get; set; }
        public bool unityPackageUpdated { get; set; }
        public string unityPackageUrl { get; set; }
        public UnityPackageUrlObject unityPackageUrlObject { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
