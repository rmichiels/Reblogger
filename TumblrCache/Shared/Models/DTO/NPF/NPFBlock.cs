using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Mime;

namespace TumblrCache.Shared.Models.DTO.NPF
{
    [JsonConverter(typeof(NPFBlockConverter))]
    public abstract class NPFBlock
    {
        [JsonPropertyName("Type")]
        public abstract ContentType Type { get; set; }
    }
}
