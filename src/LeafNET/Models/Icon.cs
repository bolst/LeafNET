namespace LeafNET;


public record Icon
{
    public required string IconUrl { get; init; }

    public string? IconRetinaUrl { get; init; }
    
    public Point? IconSize { get; init; }
    
    public Point? IconAnchor { get; init; }

    public Point PopupAnchor { get; init; } = (0, 0);

    public Point TooltipAnchor { get; init; } = (0, 0);

    public string? ShadowUrl { get; init; }
    
    public string? ShadowRetinaUrl { get; init; }
    
    public Point? ShadowSize { get; init; }
    
    public Point? ShadowAnchor { get; init; }

    public string ClassName { get; init; } = string.Empty;
    
    // public [bool or string] CrossOrigin { get; init; } = false;
}

