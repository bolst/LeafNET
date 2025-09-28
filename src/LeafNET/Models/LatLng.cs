namespace LeafNET;

public record LatLng
{
    public required double Lat { get; init; }
    
    public required double Lng { get; init; }
    
    public double? Alt { get; init; }
}