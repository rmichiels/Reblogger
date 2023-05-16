using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TumblrCache.Shared.Models.DTO.NPF.Text;

namespace TumblrCache.Shared.Models.DTO.NPF
{
    public class NPFBlockConverter : JsonConverter<NPFBlock>
    {
        public override NPFBlock? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var block = new TextBlock();
            switch (block.Type)
            {

            }
            return block;
        }

        public override void Write(Utf8JsonWriter writer, NPFBlock value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
