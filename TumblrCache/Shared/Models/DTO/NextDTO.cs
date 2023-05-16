using System.Text.Json.Serialization;

namespace TumblrCache.Shared.Models.DTO.Blog.Followers
{
    public class NextDTO
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("method")]
        public string? Method { get; set; }

        [JsonPropertyName("query_params")]
        public FollowUpQueryParams? QueryParams { get; set; }
    }
}