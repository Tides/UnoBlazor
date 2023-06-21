using UnoBlazor.Shared.Enums;

namespace UnoBlazor.Shared.Entities;
public readonly struct Card
{
    public required int Score { get; init; }

    public required CardType Type { get; init; }

    public required CardColor Color { get; init; }
}
