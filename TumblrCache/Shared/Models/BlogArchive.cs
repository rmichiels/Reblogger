using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models
{
    public class BlogArchive
    {
        public Identifiable? BlogID { get; set; }
        public List<Identifiable> FollowingArchive { get; set; } = new List<Identifiable>();
        public List<TagArchive>? TagArchives { get; set; }

        public void AddFollowing(IEnumerable<Identifiable> followers)
        {
            foreach (Identifiable identifiable in followers)
            {
                FollowingArchive.Add(identifiable);
            }
        }
    }
}
