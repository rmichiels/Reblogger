using System.Text.Json.Serialization;

namespace TumblrCache.Shared.Models.DTO
{
    public partial class SubmissionTermsDTO
    {
        [JsonPropertyName("accepted_types")]
        public List<string>? AcceptedTypes { get; set; }

        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("guidelines")]
        public string? Guidelines { get; set; }
    }
}
