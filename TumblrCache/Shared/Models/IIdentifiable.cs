using System.Runtime.CompilerServices;

namespace TumblrCache.Shared.Models
{
    public interface IIdentifiable
    {
        string Name { get; set; }
        string ID { get; set; }
        Uri URL { get; set; }
    }
}