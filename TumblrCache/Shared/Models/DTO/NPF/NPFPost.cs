using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TumblrCache.Shared.Models.Interfaces;

namespace TumblrCache.Shared.Models.DTO.NPF
{
    public class NPFPost
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName ("blog")]
        public IBlog? Blog { get; set; }
        [JsonPropertyName("content")]
        public List<NPFBlock>? Content { get; set; }
    }
}
