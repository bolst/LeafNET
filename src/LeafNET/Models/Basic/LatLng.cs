namespace LeafNET;

public sealed record LatLng(double Lat, double Lng, double? Alt = null)
{
    public static implicit operator LatLng((double,double) latLng) => new(latLng.Item1, latLng.Item2);
    public static implicit operator LatLng((double,double,double) latLng) => new(latLng.Item1, latLng.Item2, latLng.Item3);
}