using Customer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.API.Models
{
    public class OrderConverter : JsonConverter<Address>
    {
        public override Address Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return null; 
            }
            return JsonSerializer.Deserialize<Address>(ref reader);
        }

        public override void Write(Utf8JsonWriter writer, Address value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();    
        }
    }
}
