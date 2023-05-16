using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models.DTO.Blog.Followers
{
    public class TumblrBlogFollowersResponse
    {
        [JsonPropertyName("meta")]
        public MetaDTO? Meta { get; set; }
        [JsonPropertyName("response")]
        public FollowersResponse? Response { get; set; }
    }
}
