using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TumblrCache.Shared.Models.Interfaces;

namespace TumblrCache.Shared.Models
{
    public class User : Identifiable
    {
        [JsonPropertyName("likes")]
        public int Likes { get; set; }
        [JsonPropertyName("following")]
        public int Following { get; set; }
        [JsonPropertyName("blogs")]
        public List<Blog> Blogs { get; set; } = new List<Blog>();

        public Blog this[int value]
        {
            get => Blogs[value];
        }
    }
}
