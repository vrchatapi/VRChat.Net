using System.Collections.Generic;

#pragma warning disable IDE1006

namespace VRChatApi.Classes
{
    public class FavouriteResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string favoriteId { get; set; }
        public List<string> tags { get; set; }
    }
}
