using Refactoring.Builders.Interfaces;
using Refactoring.Models;
using Refactoring.Models.Interfaces;
using Refactoring.Tools;
using System;

namespace Refactoring.Builders;

public class TriangleBuilder : IShapeBuilder
{
    public IShape Build(string[]? args)
    {
        ArgumentNullException.ThrowIfNull(args);
        Guard.ExpectCount(args!, 2);

        float height;
        float width;

        if (!float.TryParse(args[0], out height))
        {
            throw new ArgumentException($"{nameof(TriangleBuilder)}: cannot parse {args[0]} to float");
        }
        else if (!float.TryParse(args[1], out width))
        {
            throw new ArgumentException($"{nameof(TriangleBuilder)}: cannot parse {args[1]} to float");
        }
        else
        {
            return new Triangle { Height = height, DisplayName = "Rectangle", Width = width };
        }
    }
}
