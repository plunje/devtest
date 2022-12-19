using Refactoring.Models.Interfaces;

namespace Refactoring.Models;

public class Triangle : BaseShape, IShape
{
    public required double Height { get; init; }
    public required double Width { get; init; }

    public double CalculateSurface()
    {
        return 0.5 * Height * Width;
    }
}
