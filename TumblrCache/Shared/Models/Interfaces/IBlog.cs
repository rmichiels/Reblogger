using TumblrCache.Shared.Models.DTO.Blog;

namespace TumblrCache.Shared.Models.Interfaces
{
    public interface IBlog : IIdentifiable
    {
        List<AvatarDTO> Avatars { get; set; }
        string Description { get; set; }
        int Followers { get; set; }
        string Title { get; set; }
    }
}