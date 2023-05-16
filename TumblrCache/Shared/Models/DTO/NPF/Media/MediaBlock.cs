using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Models.DTO.NPF.Media
{
    internal class MediaBlock : NPFBlock
    {
        public override ContentType? Type { get; set; }
        public Uri? URL { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
