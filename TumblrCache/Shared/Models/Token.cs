using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models
{
    public class Token
    {
        [JsonPropertyName("access_token")]
        public string AccessToken  { get; set; }
        [JsonPropertyName("expires_in")]
        public int Lifetime 
        {
            get => _lifetime; 
            set
            {
                _lifetime = value;
                ExpectedExpiry = DateTime.UtcNow;
                ExpectedExpiry.AddSeconds(value);
                Task.Run(() => LifetimeTimer());
            }
        }
        private int _lifetime;
        [JsonIgnore]
        public DateTime TimeStamp { get; init; }
        [JsonIgnore]
        public DateTime ExpectedExpiry;

        [JsonPropertyName("token_type")]
        public string Type { get; set; }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

     

        public Token()
        {
            TimeStamp = DateTime.UtcNow;
        }

        public delegate Task TokenExpirationEventHandler();
        public event TokenExpirationEventHandler TokenExpiration;
        private async Task LifetimeTimer()
        {
            Console.WriteLine($"...token expires in {_lifetime} seconds...");
            await Task.Delay(_lifetime * 900);
            TokenExpiration.Invoke();
        }
    }
}
