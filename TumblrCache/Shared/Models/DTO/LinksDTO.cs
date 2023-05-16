using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;

namespace TumblrCache.Shared.Models.DTO.Blog.Followers
{
    public class LinksDTO
    {
        [JsonPropertyName("next")]
        public NextDTO? Next { get; set; }
    }
}