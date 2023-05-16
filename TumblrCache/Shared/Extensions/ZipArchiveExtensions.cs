using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TumblrCache.Shared.Extensions
{
    public static class ZipExtensions
    {
        public static ZipArchive WriteJsonToArchive(this ZipArchive archive, string filename, string json)
        {
            Console.WriteLine(filename);
            Console.WriteLine(json);

            var entry = archive.CreateEntry(filename);
            using (var entryStream = entry.Open())
            {
                using (var writer = new StreamWriter(entryStream))
                {
                    writer.Write(json);
                }
            };

            Console.WriteLine(archive.Entries.Count);
            return archive;

        }
        public static T DeserializeJsonEntryAs<T>(this ZipArchiveEntry entry)
        {
            using (var entryStream = entry.Open())
            {
                using (var reader = new StreamReader(entryStream))
                {
                    string json = reader.ReadToEndAsync().Result;
                    T payload = JsonSerializer.Deserialize<T>(json);
                    return payload;
                }
            };
        }
    }
}
