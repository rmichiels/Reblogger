using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models
{
    public class Identifiable : IIdentifiable
    {
        [JsonPropertyName("name")]
        public virtual string? Name { get; set; }
        [JsonPropertyName("uuid")]
        public virtual string? ID { get; set; }
        [JsonPropertyName("url")]
        public virtual Uri? URL { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
