using TumblrCache.Shared.Models.DTO.NPF;

namespace TumblrCache.Shared.Models
{
    public class TagArchive
    {
        public string? Tag { get; set; }
        public List<NPFPost>? Posts { get; set; }
    }
}