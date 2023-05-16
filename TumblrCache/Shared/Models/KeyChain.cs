using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models
{
    public class KeyChain
    {
        public string ConsumerKey { get; set; } = string.Empty;
        public string ConsumerSecret { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public Token? Token { get; set; }
        public string RedirectURL { get; set; } = string.Empty;
    }
}
