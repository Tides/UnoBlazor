using System.Text.Json;
using UnoBlazor.Shared.Utils;

namespace UnoBlazor.Shared
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

        public override string ConvertName(string name) => name.ToSnakeCase();
    }
}
