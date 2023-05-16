using System.Text.Json.Serialization;

namespace TumblrCache.Shared.Models.DTO.Blog.Followers
{
    public class FollowersResponse
    {
        [JsonPropertyName("total_users")]
        public int FollowerCount { get; set; }
        [JsonPropertyName("users")]
        public List<Identifiable>? Followers { get; set; }

        [JsonPropertyName("_links")]
        public LinksDTO? Links { get; set; }
    }
}