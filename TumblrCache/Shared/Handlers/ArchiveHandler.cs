using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TumblrCache.Shared.Extensions;
using TumblrCache.Shared.Models;
using TumblrCache.Shared.Models.DTO.Blog;
using TumblrCache.Shared.Models.DTO.Blog.Info;
using TumblrCache.Shared.Models.DTO.NPF;

namespace TumblrCache.Shared.Handlers
{
    public class ArchiveHandler
    {
        private TumblrClient _tumblr { get; set; }
        private IJSRuntime _js { get; set; }

        public int MyProperty { get; set; }

        public List<BlogArchive> Archives = new List<BlogArchive>();

        public BlogArchive? this[string blogname]
        {
            get => Archives.FirstOrDefault(a => a.BlogID.Name == blogname);
        }

        public BlogArchive? this[int index]
        {
            get => Archives[index];
        }

        public BlogArchive? this[Identifiable id]
        {
            get => Archives.FirstOrDefault(a => a.BlogID == id);
        }


        public ArchiveHandler(TumblrClient tumblr, IJSRuntime jSRuntime)
        {
            _tumblr = tumblr;
            _js = jSRuntime;
        }

        public void CreateArchiveFor(Blog blog)
        {
            Archives.Add(new BlogArchive()
            {
                BlogID = blog
            });
        }

        public async Task AddFollowingTo(BlogArchive archive)
        {
            var following = await _tumblr.GetFollowing();
            archive.AddFollowing(following);
        }

        public async Task AddTagArchiveTo(BlogArchive archive, string tag)
        {
            List<NPFPost> posts = await _tumblr.GetPostsByTagFor(archive.BlogID, tag);
            var tagarchive = new TagArchive()
            {
                Tag = tag,
                Posts = posts
            };
            archive.TagArchives.Add(tagarchive);
        }
        public async Task DownloadArchiveFor(Identifiable blog)
        {
            BlogArchive archive = this[blog];
            Dictionary<string, DotNetStreamReference?> namedFileStreams = new()
            {
                { $"{blog.Name}.zip", null },
                { $"{archive.BlogID.Name}.json", archive.BlogID.GetJsonAsDotNetStreamReference() },
                { $"{archive.BlogID.Name}.following.json", archive.FollowingArchive.GetJsonAsDotNetStreamReference() }
            };

            // Download Profile picture
            if (archive.BlogID is Blog b)
            {
                AvatarDTO avatar = b.Avatars.FirstOrDefault(a => a.Width == 512);
                Tuple<DotNetStreamReference, string> tuple = await avatar.URL.GetUrlContentAsSteamRefWithFileExtension();
                namedFileStreams.Add(blog.Name + tuple.Item2, tuple.Item1);
            }

            await _js.InvokeVoidAsync("generateZIP", namedFileStreams);
            try
            {
                foreach (var kvp in namedFileStreams) { kvp.Value.Dispose(); }
            }
            catch { }
        }
    }
}
