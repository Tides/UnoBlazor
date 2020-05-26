using System.Linq;

namespace UnoBlazor.Shared.Utils
{
    public static class Extensions
    {

        public static string ToSnakeCase(this string value) =>
            string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
    }
}
