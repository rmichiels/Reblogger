using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TumblrCache.Client.Helpers;
using TumblrCache.Shared;
using TumblrCache.Shared.Extensions;
using TumblrCache.Shared.Models;
using TumblrCache.Shared.Models.DTO.Blog;
using TumblrCache.Shared.Models.DTO.Blog.Followers;
using TumblrCache.Shared.Models.DTO.Blog.Info;
using TumblrCache.Shared.Models.DTO.NPF;
using TumblrCache.Shared.Models.DTO.User.Followers;
using TumblrCache.Shared.Models.DTO.User.Info;
using TumblrCache.Shared.Models.Interfaces;

namespace TumblrCache.Shared.Handlers
{
    public class TumblrClient
    {
        public bool EnableFollowUpRequests { get; set; } = true;
        private readonly HttpClientHelper helper;
        private HttpClient API;
        private HttpClient Backend => helper.BaseClient;
        public Token Token { get; set; }
        public List<string> Blockables = new List<string>()
        {
            "untitled",
            "sin titulo",
            "unbeteitelt"
        };
        public User? User { get; set; } = null;

        public TumblrClient(IWebAssemblyHostEnvironment env, HttpClientHelper clientHelper)
        {
            if (env.IsDevelopment())
            {
                EnableFollowUpRequests = false;
                Console.WriteLine("Follow-up requests are disabled.");
            }
            helper = clientHelper;
            API = helper.ApiClient;
        }


        public async Task Handover(string code, string redirectURL)
        {
            var content = new Dictionary<string, string>()
            {
                { "code", code } ,
                { "redirectURL", redirectURL }
            }.GetFormDataContent();
            var bridge = await Backend.PostAsync("api/vault/handover", content);
            Token = JsonSerializer.Deserialize<Token>(await bridge.Content.ReadAsStringAsync());
            API.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.AccessToken);
            Token.TokenExpiration += RefreshTokenAsync;
        }

        public async Task RefreshTokenAsync()
        {
            Token = await Backend.GetFromJsonAsync<Token>("api/vault/refresh");
            Token.TokenExpiration += RefreshTokenAsync;
            API.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.AccessToken);
        }

        public async Task<User> GetUser()
        {
            var UserInfoResponse = await API.GetFromJsonAsync<TumblrUserInfoResponse>("user/info");

            User = new()
            {
                Name = UserInfoResponse.Response.User.Name,
                Following = UserInfoResponse.Response.User.Following,
                Likes = UserInfoResponse.Response.User.Likes
            };

            UserInfoResponse.Response.User.Blogs.ForEach(b => User.Blogs.Add(new(b, this)));

            return User;
        }

        public async Task<List<Identifiable>> GetFollowers(Blog blog)
        {
            var payload = new List<Identifiable>();
            var blogs = new List<BlogDTO>();

            TumblrBlogFollowersResponse? followersResponse = await API.GetFromJsonAsync<TumblrBlogFollowersResponse>($"blog/{blog.Name}/followers");
            followersResponse?.Response.Followers.ForEach(f => payload.Add(f));

            if (EnableFollowUpRequests)
            {
                Console.WriteLine("following up initial request...");
                int i = 0;
                while (followersResponse?.Response.Links.Next is not null)
                {
                    i++;
                    followersResponse = await API.GetFromJsonAsync<TumblrBlogFollowersResponse>(followersResponse.Response.Links.Next.Href);
                    followersResponse?.Response.Followers.ForEach(f => payload.Add(f));
                }
                Console.WriteLine($"...follow-ups exhausted after {i} requests");
            }
            return payload;
        }

        public async Task<List<Identifiable>> GetFollowing()
        {
            if (User is null) { throw new NoAuthorizedUserException("There is no user registered to work with the client."); }
            var response = await API.GetFromJsonAsync<TumblrUserFollowersResponse>($"user/following");
            return response.Response.Blogs;
        }

        public async Task<bool> FollowBlog(Identifiable i)
        {
            if (User is null) { throw new NoAuthorizedUserException("There is no user registered to work with the client."); }
            var formData = new MultipartFormDataContent
            {
                { new StringContent(i.Name), "url" }
            };
            var bridge = await API.PostAsync("user/follow", formData);
            if (bridge.IsSuccessStatusCode) { return true; }
            else { return false; }
        }

        public async Task<IBlog> GetBlogInfo(Identifiable i)
        {
            string endpoint = $"blog/{i.Name}/info";
            TumblrBlogInfoResponse? response = await API.GetFromJsonAsync<TumblrBlogInfoResponse>(endpoint);
            return response.Response.Blog;
        }

        public Task BlockBlogFor(Identifiable blockFor, Identifiable toBlock)
        {
            API.PostAsync($"blog/{blockFor}/blocks", new Dictionary<string, string>() { { "blocked_tumblelog", toBlock.Name } }.GetFormDataContent());
            return Task.CompletedTask;
        }

        public Task BlockBulkFor(Identifiable blockFor, List<Identifiable> toBlock)
        {
            string blocklist = string.Empty;
            toBlock.ForEach(i =>
            {
                blocklist += i + ",";
            });
            blocklist = blocklist.Remove(blocklist.Length - 1);
            var content = new Dictionary<string, string>()
            {
                {"blocked_tumblelogs", blocklist }
            };
            API.PostAsync($"blog/{blockFor}/blocks/bulk", content.GetFormDataContent());
            return Task.CompletedTask;
        }

        public Task<List<NPFPost>> GetPostsByTagFor(Identifiable blogID, string tag)
        {
            throw new NotImplementedException();

        }
    }
}
