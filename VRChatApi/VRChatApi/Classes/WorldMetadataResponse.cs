using System;
using System.Collections.Generic;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class EventPortal
    {
        public string eventName { get; set; }
        public string worldId { get; set; }
        public DateTime eventStartTimeUtc { get; set; }
        public string eventDuration { get; set; }
    }

    public class Metadata
    {
        public string CENTER_TEXT { get; set; }
        public string CENTER_TEXT2 { get; set; }
        public List<string> PANOS { get; set; }
        public List<string> AVATAR_CUSTOM { get; set; }
        public List<string> AVATAR_FEATURED { get; set; }
        public List<string> AVATAR_HELP { get; set; }
        public List<string> AVATAR_MORPH { get; set; }
        public List<string> AVATAR_PEDESTAL { get; set; }
        public List<string> EVENTHALL_WELCOME { get; set; }
        public List<string> EVENTHAPPENING { get; set; }
        public List<string> EVENTS { get; set; }
        public List<string> MICROPHONE { get; set; }
        public List<string> PANOSPHERE { get; set; }
        public List<string> TIPS { get; set; }
        public List<string> WELCOME { get; set; }
        public List<string> WELCOME_2 { get; set; }
        public List<string> WORLD_CREATION { get; set; }
        public List<string> WORLD_FEATURED_ONE { get; set; }
        public List<string> WORLD_FEATURED_THREE { get; set; }
        public List<string> WORLD_FEATURED_TWO { get; set; }
        public List<string> WORLD_HELP { get; set; }
        public List<string> HELP_ROOM_1 { get; set; }
        public List<string> HELP_ROOM_2 { get; set; }
        public List<string> HELP_ROOM_3 { get; set; }
        public List<string> HELP_ROOM_4 { get; set; }
        public List<string> STAFF_PORTAL_1 { get; set; }
        public string STAFF_CREATOR_1 { get; set; }
        public List<string> STAFF_IMAGE_1 { get; set; }
        public List<string> STAFF_PORTAL_2 { get; set; }
        public string STAFF_CREATOR_2 { get; set; }
        public List<string> STAFF_IMAGE_2 { get; set; }
        public List<string> STAFF_PORTAL_3 { get; set; }
        public string STAFF_CREATOR_3 { get; set; }
        public List<string> STAFF_IMAGE_3 { get; set; }
        public string AVATAR_1 { get; set; }
        public string AVATAR_2 { get; set; }
        public string AVATAR_3 { get; set; }
        public List<string> EVENT_CALENDAR { get; set; }
        public List<string> LOCATION_SPAWN { get; set; }
        public List<string> HELP_WELCOME { get; set; }
        public List<string> AVATAR_WELCOME { get; set; }
        public List<string> NEW_WORLDS_WELCOME { get; set; }
        public List<string> FEATURED_WORLDS_WELCOME { get; set; }
        public List<string> EVENTHALL_MARQUEE { get; set; }
        public List<string> FOUNTAIN_WELCOME { get; set; }
        public List<EventPortal> EVENT_PORTAL { get; set; }
        public List<string> HELP_PORTAL_1 { get; set; }
        public List<string> HELP_PORTAL_2 { get; set; }
        public bool NameplatesVisibleByDefault { get; set; }
        public List<string> HELP_PORTALS { get; set; }
        public List<string> EVENT_PORTAL_1 { get; set; }
        public List<string> EVENT_PORTAL_2 { get; set; }
        public List<string> EVENT_PORTAL_3 { get; set; }
        public List<string> EVENT_PORTAL_4 { get; set; }
        public List<string> AVATAR_PORTAL_1 { get; set; }
        public List<string> AVATAR_PORTAL_2 { get; set; }
        public List<string> AVATAR_STATIC_PORTAL_1 { get; set; }
        public List<string> AVATAR_STATIC_PORTAL_2 { get; set; }
        public List<string> FIREPIT_PORTAL_2 { get; set; }
        public List<string> FIREPIT_PORTAL_1 { get; set; }
    }

    public class WorldMetadataResponse
    {
        public string id { get; set; }
        public Metadata metadata { get; set; }
    }
}
