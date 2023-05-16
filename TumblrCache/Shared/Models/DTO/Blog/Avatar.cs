using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models.DTO.Blog
{
    public class AvatarDTO
    {
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("url")]
        public string? URL { get; set; }
    }
}
