using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rugal.DotNetLib.Core.JsonConverters
{
    public static class JsonConverterExtention
    {
        public static string ToUtf8String(this Utf8JsonReader Reader)
        {
            var JsonValue = Encoding.UTF8.GetString(Reader.ValueSpan);
            return JsonValue;
        }
        public static void AddDotNetLib_JsonConverter(this IList<JsonConverter> Converters)
        {
            var AllConverter = GetAllConverter();
            foreach (var Item in AllConverter)
                Converters.Add(Item);
        }
        private static JsonConverter[] GetAllConverter()
        {
            var AllConverters = new JsonConverter[]
            {
                new TimeSpanJsonConverter(),
                new TimeSpanNullJsonConverter(),
                new DateTimeJsonConverter(),
                new DateTimeNullJsonConverter(),
                new DateOnlyJsonConverter(),
                new DateOnlyNullJsonConverter(),
                new BooleanJsonConverter(),
                new BooleanNullJsonConverter(),
                new GuidJsonConverter(),
                new GuidNullJsonConverter(),
                new IntJsonConverter(),
                new IntNullJsonConverter(),
            };
            return AllConverters;
        }
    }
}