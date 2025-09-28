namespace LeafNET;

public record Point(double X, double Y)
{
    public static implicit operator Point((double,double) point) => new(point.Item1, point.Item2);
}