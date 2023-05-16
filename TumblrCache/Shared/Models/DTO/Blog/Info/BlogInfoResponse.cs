using System.Text.Json.Serialization;

namespace TumblrCache.Shared.Models.DTO.Blog.Info
{
    public class BlogInfoResponse
    {
        [JsonPropertyName("blog")]
        public BlogInfoDTO? Blog { get; set; }
    }
}