namespace LeafNET;

public record Layer
{
    public string Pane { get; init; } = "overlayPane";

    public string? Attribution { get; init; }
}