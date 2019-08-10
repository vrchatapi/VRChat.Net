using System.ComponentModel;

namespace VRChatApi.Classes
{
    public enum UserOptions
    {
        Me,
        Friends,
    }

    public enum SortOptions
    {
        Popularity,
        Created,
        Updated,
        Order,
    }

    public enum ReleaseStatus
    {
        [Description("public")]
        Public,
        [Description("private")]
        Private,
        [Description("all")]
        All,
        [Description("hidden")]
        Hidden,
    }

    public enum WorldGroups
    {
        Any,
        Active,
        Recent,
        Favorite,
    }
}
