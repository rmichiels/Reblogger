using System.Text.Json.Serialization;
using TumblrCache.Shared.Models.Interfaces;

namespace TumblrCache.Shared.Models.DTO.Blog
{
    public class BlogDTO : Identifiable, IBlog
    {
        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

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

        [JsonPropertyName("can_submit")]
        public bool CanSubmit { get; set; }

        [JsonPropertyName("can_subscribe")]
        public bool CanSubscribe { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("drafts")]
        public long Drafts { get; set; }

        [JsonPropertyName("facebook")]
        public string? Facebook { get; set; }

        [JsonPropertyName("facebook_opengraph_enabled")]
        public string? FacebookOpengraphEnabled { get; set; }

        [JsonPropertyName("followed")]
        public bool Followed { get; set; }

        [JsonPropertyName("followers")]
        public int Followers { get; set; }

        [JsonPropertyName("is_blocked_from_primary")]
        public bool IsBlockedFromPrimary { get; set; }

        [JsonPropertyName("is_nsfw")]
        public bool IsNsfw { get; set; }

        [JsonPropertyName("messages")]
        public long Messages { get; set; }

        [JsonPropertyName("posts")]
        public long Posts { get; set; }

        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        [JsonPropertyName("queue")]
        public long Queue { get; set; }

        [JsonPropertyName("share_likes")]
        public bool ShareLikes { get; set; }

        [JsonPropertyName("submission_page_title")]
        public string? SubmissionPageTitle { get; set; }

        [JsonPropertyName("submission_terms")]
        public SubmissionTermsDTO? SubmissionTerms { get; set; }

        [JsonPropertyName("subscribed")]
        public bool Subscribed { get; set; }

        [JsonPropertyName("theme")]
        public ThemeDTO? Theme { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("total_posts")]
        public long TotalPosts { get; set; }

        [JsonPropertyName("tweet")]
        public string? Tweet { get; set; }

        [JsonPropertyName("twitter_enabled")]
        public bool TwitterEnabled { get; set; }

        [JsonPropertyName("twitter_send")]
        public bool TwitterSend { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("updated")]
        public long Updated { get; set; }
    }
}
