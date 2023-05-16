using System.Text.Json.Serialization;

namespace TumblrCache.Shared.Models.DTO.Blog
{
    public partial class ThemeDTO
    {
        [JsonPropertyName("header_full_width")]
        public long HeaderFullWidth { get; set; }

        [JsonPropertyName("header_full_height")]
        public long HeaderFullHeight { get; set; }

        [JsonPropertyName("header_focus_width")]
        public long HeaderFocusWidth { get; set; }

        [JsonPropertyName("header_focus_height")]
        public long HeaderFocusHeight { get; set; }

        [JsonPropertyName("avatar_shape")]
        public string? AvatarShape { get; set; }

        [JsonPropertyName("background_color")]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("body_font")]
        public string? BodyFont { get; set; }

        [JsonPropertyName("header_image")]
        public Uri? HeaderImage { get; set; }

        [JsonPropertyName("header_image_focused")]
        public Uri? HeaderImageFocused { get; set; }

        [JsonPropertyName("header_image_poster")]
        public string? HeaderImagePoster { get; set; }

        [JsonPropertyName("header_image_scaled")]
        public Uri? HeaderImageScaled { get; set; }

        [JsonPropertyName("header_stretch")]
        public bool HeaderStretch { get; set; }

        [JsonPropertyName("link_color")]
        public string? LinkColor { get; set; }

        [JsonPropertyName("show_avatar")]
        public bool ShowAvatar { get; set; }

        [JsonPropertyName("show_description")]
        public bool ShowDescription { get; set; }

        [JsonPropertyName("show_header_image")]
        public bool ShowHeaderImage { get; set; }

        [JsonPropertyName("show_title")]
        public bool ShowTitle { get; set; }

        [JsonPropertyName("title_color")]
        public string? TitleColor { get; set; }

        [JsonPropertyName("title_font")]
        public string? TitleFont { get; set; }

        [JsonPropertyName("title_font_weight")]
        public string? TitleFontWeight { get; set; }
    }
}
