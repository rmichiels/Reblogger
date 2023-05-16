using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace TumblrCache.Client.Helpers
{
    public class HttpClientHelper
    {
        private IWebAssemblyHostEnvironment _env;
        public HttpClient BaseClient => new() { BaseAddress = new Uri(_env.BaseAddress) };
        public HttpClient ApiClient => new() { BaseAddress = new Uri("https://api.tumblr.com/v2/") };
        public HttpClientHelper(IWebAssemblyHostEnvironment environment)
        {
            _env = environment;
        }
    }
}
