using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models.DTO.NPF.Text
{
    public class TextBlock : NPFBlock
    {
        public override ContentType? Type { get; set; }
        public string? Subtype { get; set; }
        public string? Content { get; set; }
        public int? Indent { get; set; }
    }
}
