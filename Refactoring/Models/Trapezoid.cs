using Refactoring.Models.Interfaces;

namespace Refactoring.Models;
public class Trapezoid : BaseShape, IShape
{
    public required double Height { get; init; }
    public required double TopWidht { get; init; }
    public required double BottomWidht { get; init; }

    public double CalculateSurface()
    {
        return ((TopWidht + BottomWidht) / 2) * Height;
    }
}
