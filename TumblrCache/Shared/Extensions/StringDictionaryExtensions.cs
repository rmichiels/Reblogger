using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Extensions
{
    public static class StringDictionaryExtensions
    {
        public static MultipartFormDataContent GetFormDataContent(this Dictionary<string, string> dictionary)
        {
            var payload = new MultipartFormDataContent();
            foreach (var kvp in dictionary)
            {
                payload.Add(new StringContent(kvp.Value), kvp.Key);
            }
            return payload;
        }
    }
}
