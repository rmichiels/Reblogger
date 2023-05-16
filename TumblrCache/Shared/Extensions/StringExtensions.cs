using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Extensions
{
    public static class StringExtensions
    {
        public static async Task<Tuple<DotNetStreamReference, string>> GetUrlContentAsSteamRefWithFileExtension(this string str)
        {
            Tuple<DotNetStreamReference, string> payload;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(str);
            var content = response.Content;
            string contentType = content.Headers.ContentType.ToString();
            string fileExtension = "." + contentType.Split('/')[1];
            Console.WriteLine(fileExtension);
            DotNetStreamReference stream = new(await content.ReadAsStreamAsync(), true);
            Console.WriteLine("stream generated with length " + stream.Stream.Length + " - " + stream.LeaveOpen);
            payload = new(stream, fileExtension);
            return payload;

        }
    }
}
