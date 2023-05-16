using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models.DTO.NPF.Text
{
    public class TextBlockFormatting
    {
        public int Start { get; set; }
        public int End { get; set; }
        public string? Type { get; set; }
    }
}
