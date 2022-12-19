using System;
using Refactoring.Builders.Interfaces;
using Refactoring.Models;
using Refactoring.Models.Interfaces;
using Refactoring.Tools;

namespace Refactoring.Builders;

public class CircleBuilder : IShapeBuilder
{
    public IShape Build(string[]? args)
    {
        ArgumentNullException.ThrowIfNull(args);
        Guard.ExpectCount(args!, 1, nameof(args));

        if (float.TryParse(args![0], out float radius))
        {
            return new Circle { Radius = radius, DisplayName = "Circle" };
        }
        else
        {
            throw new ArgumentException($"{nameof(CircleBuilder)}: cannot parse {args[0]} to float");
        }
    }
}
