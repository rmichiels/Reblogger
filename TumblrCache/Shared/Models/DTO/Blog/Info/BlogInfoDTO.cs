using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TumblrCache.Shared.Models.Interfaces;

namespace TumblrCache.Shared.Models.DTO.Blog.Info
{
    public class BlogInfoDTO : Identifiable, IBlog

    {
        [JsonPropertyName("ask")]
        public bool Ask { get; set; }

        [JsonPropertyName("ask_anon")]
        public bool AskAnon { get; set; }

        [JsonPropertyName("ask_page_title")]
        public string? AskPageTitle { get; set; }

        [JsonPropertyName("asks_allow_media")]
        public bool AsksAllowMedia { get; set; }

        [JsonPropertyName("avatar")]
        public List<AvatarDTO>? Avatars { get; set; }

        [JsonPropertyName("can_chat")]
        public bool CanChat { get; set; }

        [JsonPropertyName("can_send_fan_mail")]
        public bool CanSendFanMail { get; set; }

        [JsonPropertyName("can_subscribe")]
        public bool CanSubscribe { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("followed")]
        public bool Followed { get; set; }

        [JsonPropertyName("is_blocked_from_primary")]
        public bool IsBlockedFromPrimary { get; set; }

        [JsonPropertyName("is_nsfw")]
        public bool IsNsfw { get; set; }

        [JsonPropertyName("posts")]
        public long Posts { get; set; }

        [JsonPropertyName("share_likes")]
        public bool ShareLikes { get; set; }

        [JsonPropertyName("subscribed")]
        public bool Subscribed { get; set; }

        [JsonPropertyName("theme")]
        public ThemeDTO? Theme { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("total_posts")]
        public long TotalPosts { get; set; }

        [JsonPropertyName("updated")]
        public long Updated { get; set; }
        [JsonIgnore]
        public int Followers { get; set; }
    }
}
