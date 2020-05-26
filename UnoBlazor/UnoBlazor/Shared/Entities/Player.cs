using System;
using System.Text.Json.Serialization;

namespace UnoBlazor.Shared.Entities
{
    public class Player
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
