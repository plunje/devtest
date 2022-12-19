using System;
using Refactoring.Models.Interfaces;

namespace Refactoring.Models;

public class Circle : BaseShape, IShape
{
    public required double Radius { get; init; }

    public double CalculateSurface()
    {
        return Math.Round(Math.PI * (Radius * Radius), 2);
    }
}
