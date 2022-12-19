using Refactoring.Models.Interfaces;

namespace Refactoring.Models;

public class Rectangle : BaseShape, IShape
{
    public required double Height { get; init; }

    public required double Width { get; init; }

    public double CalculateSurface()
    {
        return Height * Width;
    }
}
