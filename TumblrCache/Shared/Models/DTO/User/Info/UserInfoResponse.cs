using System.Text.Json.Serialization;

namespace TumblrCache.Shared.Models.DTO.User.Info
{
    public class UserInfoResponse
    {
        [JsonPropertyName("user")]
        public UserDTO? User { get; set; }
    }
}