using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TumblrCache.Shared.Handlers;
using TumblrCache.Shared.Models.DTO.Blog;
using TumblrCache.Shared.Models.DTO.Blog.Followers;
using TumblrCache.Shared.Models.Interfaces;

namespace TumblrCache.Shared.Models
{
    public class Blog : Identifiable, IBlog
    {
 
        [JsonPropertyName("avatar")]
        public List<AvatarDTO> Avatars { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("followers")]
        public int Followers { get; set; }

        private readonly TumblrClient API;

        public Blog(IBlog blog, TumblrClient client)
        {
            Name = blog.Name;
            Avatars = blog.Avatars;
            Title = blog.Title;
            Description = blog.Description;
            Followers = blog.Followers;
            API = client;
        }

        public async Task<List<Identifiable>> GetFollowers()
        {
            return await API.GetFollowers(this);
        }
    }
}
