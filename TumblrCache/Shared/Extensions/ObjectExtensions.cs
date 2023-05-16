using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static DotNetStreamReference GetJsonAsDotNetStreamReference(this object obj)
        {
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            string json = JsonSerializer.Serialize(obj);
            writer.Write(json);
            writer.Flush();
            ms.Position = 0;
            return new DotNetStreamReference(ms, true);
        }
    }
}
