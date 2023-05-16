using System.Net.Http.Headers;
using System.Text.Json;
using TumblrCache.Shared.Models;
using TumblrCache.Shared.Extensions;

namespace TumblrCache.Shared.Handlers
{
    public class TumblrBackend
    {
        public KeyChain? KeyChain { get; set; } = null;
        private HttpClient API = new() { BaseAddress = new Uri("https://api.tumblr.com/v2/") };
        public async Task<Token> RefreshTokenAsync()
        {
            Console.WriteLine("refreshing token...");
            var content = new Dictionary<string, string>()
            {
                { "grant_type", "refresh_token" },
                { "client_id", KeyChain.ConsumerKey },
                { "client_secret", KeyChain.ConsumerSecret },
                {"refresh_token", KeyChain.Token.RefreshToken },
                {"redirect_uri", KeyChain.RedirectURL}
            };
            var response = await API.PostAsync("oauth2/token", content.GetFormDataContent());
            KeyChain.Token = JsonSerializer.Deserialize<Token>(await response.Content.ReadAsStringAsync());
            API.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", KeyChain.Token.AccessToken);
            Console.WriteLine("...token refreshed");
            return KeyChain.Token;
        }
        public async Task<Token> RequestTokenAsync(KeyChain keyChain)
        {
            Console.WriteLine("requesting bearer token...");
            KeyChain = keyChain;
            var content = new Dictionary<string, string>()
            {
                { "grant_type", "authorization_code" },
                { "code", KeyChain.Code },
                { "client_id", KeyChain.ConsumerKey },
                { "client_secret", KeyChain.ConsumerSecret },
                {"redirect_uri", KeyChain.RedirectURL}
            };
            var response = await API.PostAsync("oauth2/token", content.GetFormDataContent());
            KeyChain.Token = JsonSerializer.Deserialize<Token>(await response.Content.ReadAsStringAsync());
            API.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", KeyChain.Token.AccessToken);
            Console.WriteLine("...token received");
            return KeyChain.Token;
        }
    }
}