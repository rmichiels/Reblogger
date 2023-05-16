using System.Text.Json.Serialization;
using TumblrCache.Shared.Models.DTO.Blog.Followers;

namespace TumblrCache.Shared.Models.DTO
{
    public class FollowUpQueryParams : IQueryParams
    {
        [JsonPropertyName("offset")]
        public string? Offset { get; set; }
        [JsonPropertyName("prev_offsets")]
        public string? PrevOffsets { get; set; }
        public Dictionary<string, string> GetParameters()
        {
            var payload = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Offset)) { payload.Add("offset", Offset); }
            if(!string.IsNullOrEmpty(PrevOffsets)) { payload.Add("prev_offsets", PrevOffsets); }
            
            return payload;
        }
    }
}