namespace LeafNET;


public sealed record DivIcon : Icon
{
    public string Html { get; init; } = string.Empty;
    public Point BgPos { get; init; } = (0, 0);
}