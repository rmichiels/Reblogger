using Microsoft.AspNetCore.Mvc;
using System.Text;
using TumblrCache.Shared.Handlers;
using TumblrCache.Shared.Models;

namespace TumblrCache.Server.Controllers
{
    public class VaultController : Controller
    {
        public IConfiguration Configuration { get; set; }
        public KeyChain KeyChain { get; set; }
        public TumblrBackend Backend { get; set; }
        public VaultController(IConfiguration configuration, TumblrBackend backend)
        {
            Configuration = configuration;

            IConfigurationSection keyChainSection = Configuration.GetSection("KeyChain");
            KeyChain = new()
            {
                ConsumerKey = keyChainSection.GetValue<string>("ConsumerKey"),
                ConsumerSecret = keyChainSection.GetValue<string>("ConsumerSecret")
            };
            Backend = backend;
        }
        [HttpGet]
        [Route("/api/vault/getkey")]
        public async Task<string> GetKey()
        {
            return KeyChain.ConsumerKey;
        }


        [HttpPost]
        [Route("/api/vault/handover")]
        public async Task<Token> Handover(string code, string redirectURL)
        {
            KeyChain.Code = code;
            KeyChain.RedirectURL = redirectURL + "/redirect";

            return await Backend.RequestTokenAsync(KeyChain);
        }
        [HttpGet]
        [Route("/api/vault/refresh")]
        public async Task<Token> Refresh()
        {

            return await Backend.RefreshTokenAsync();
        }
    }
}
