using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TumblrCache.Shared.Models.DTO.Blog;

namespace TumblrCache.Shared.Models.DTO.User
{
    public partial class UserDTO : Identifiable
    {
        [JsonPropertyName("likes")]
        public int Likes { get; set; }

        [JsonPropertyName("following")]
        public int Following { get; set; }

        [JsonPropertyName("default_post_format")]
        public string? DefaultPostFormat { get; set; }

        [JsonPropertyName("blogs")]
        public List<BlogDTO>? Blogs { get; set; }
    }
}
