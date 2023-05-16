using System.Text.Json.Serialization;
using TumblrCache.Shared.Models.DTO.Blog.Followers;

namespace TumblrCache.Shared.Models.DTO.User.Followers
{
    public class FollowersResponse
    {
        [JsonPropertyName("total_blogs")]
        public long TotalBlogs { get; set; }

        [JsonPropertyName("blogs")]
        public List<Identifiable>? Blogs { get; set; }

        [JsonPropertyName("_links")]
        public LinksDTO? Links { get; set; }
    }
}