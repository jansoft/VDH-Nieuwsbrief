using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class BooleanConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;

            if (value == null || String.IsNullOrWhiteSpace(value.ToString()))
            {
                return false;
            }

            return value.ToString() == "1"; 

        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(Boolean))
            {
                return true;
            }
            return false;
        }
    }
}
