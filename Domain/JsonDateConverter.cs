using System;
using Newtonsoft.Json.Converters;

namespace Domain
{
    public class JsonDateConverter : IsoDateTimeConverter
    {
        public JsonDateConverter(string dateFormat)
        {
            DateTimeFormat = dateFormat;
        }
    }
}
