using Microsoft.AspNetCore.Mvc;

namespace TumblrCache.Server.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        [Route("api/auth/callback")]
        public async Task Callback(HttpRequest request)
        {
            
        }
    }
}
