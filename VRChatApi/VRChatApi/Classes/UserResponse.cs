using System;
using System.Collections.Generic;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class PastDisplayName
    {
        public string displayName { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class SteamDetails
    {
    }

    public class Feature
    {
        public bool twoFactorAuth { get; set; }
    }

    public class UserResponse : UserBriefResponse
    {
        public List<PastDisplayName> pastDisplayNames { get; set; }
        public bool hasEmail { get; set; }
        public bool hasPendingEmail { get; set; }
        public string obfuscatedEmail { get; set; }
        public string obfuscatedPendingEmail { get; set; }
        public bool emailVerified { get; set; }
        public bool hasBirthday { get; set; }
        public bool unsubscribe { get; set; }
        public List<string> friends { get; set; }
        public List<string> friendGroupNames { get; set; }
        public string currentAvatar { get; set; }
        public string currentAvatarAssetUrl { get; set; }
        public int acceptedTOSVersion { get; set; }
        public string steamId { get; set; }
        public SteamDetails steamDetails { get; set; }
        public string oculusId { get; set; }
        public bool hasLoggedInFromClient { get; set; }
        public string homeLocation { get; set; }
        public bool twoFactorAuthEnabled { get; set; }
        public Feature feature { get; set; }
        public string state { get; set; }
        public DateTime last_login { get; set; }
        public bool allowAvatarCopying { get; set; }
        public List<string> onlineFriends { get; set; }
        public List<string> activeFriends { get; set; }
        public List<string> offlineFriends { get; set; }
    }
}
