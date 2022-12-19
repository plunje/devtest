using Refactoring.Builders;
using Refactoring.Builders.Interfaces;
using Refactoring.Constants;
using Refactoring.Factories.Interfaces;
using Refactoring.Tools;
using System;

namespace Refactoring.Factories;

internal class ShapeBuilderFactory : IShapeBuilderFactory
{
    public IShapeBuilder GetShapeBuilder(string[]? args)
    {
        ArgumentNullException.ThrowIfNull(args);
        Guard.ExpectEqualOrMore(args!, 2);

        switch (args![0].ToLowerInvariant())
        {
            case CommandParameters.Circle:
                return new CircleBuilder();
            case CommandParameters.Rectangle:
                return new RectangleBuilder();
            case CommandParameters.Square:
                return new SquareBuilder();
            case CommandParameters.Triangle:
                return new TriangleBuilder();
            case CommandParameters.Trapezoid:
                return new TrapezoidBuilder();
            default:
                throw new NotSupportedException($"Unknown shape '{args[0]}'");
        }
    }
}
