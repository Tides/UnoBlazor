using System.Linq;
using System.Text.Json;

namespace UnoBlazor.Shared.Utils
{
    public static class Extensions
    {
        public static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance
        };

        public static T Deserialize<T>(this string json) => JsonSerializer.Deserialize<T>(json, SerializerOptions);

        public static string Serialize(this object obj) => JsonSerializer.Serialize(obj, options: SerializerOptions);

        public static string ToSnakeCase(this string value) =>
            string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();

        public static bool EqualsIgnoreCase(this string value, string compareTo) => value.Equals(compareTo, System.StringComparison.OrdinalIgnoreCase);
    }
}
