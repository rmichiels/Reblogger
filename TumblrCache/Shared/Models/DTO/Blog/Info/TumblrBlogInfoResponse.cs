using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TumblrCache.Shared.Models.DTO.Blog.Followers;

namespace TumblrCache.Shared.Models.DTO.Blog.Info
{
    public class TumblrBlogInfoResponse
    {
        [JsonPropertyName("meta")]
        public MetaDTO? Meta { get; set; }
        [JsonPropertyName("response")]
        public BlogInfoResponse? Response { get; set; }
    }
}

