using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatApi.Classes
{
    public class FavoritesResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string favoriteId { get; set; }
        public string[] tags { get; set; }
    }
    public enum FavoriteType
    {

    }
}
