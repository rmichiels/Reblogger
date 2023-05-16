using System.Text.Json.Serialization;

namespace TumblrCache.Shared.Models.DTO
{
    public class MetaDTO
    {
        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("msg")]
        public string? Msg { get; set; }
    }
}