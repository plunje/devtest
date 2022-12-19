using Refactoring.Builders.Interfaces;
using Refactoring.Models;
using Refactoring.Models.Interfaces;
using Refactoring.Tools;
using System;

namespace Refactoring.Builders;

public class SquareBuilder : IShapeBuilder
{
    public IShape Build(string[]? args)
    {
        ArgumentNullException.ThrowIfNull(args);
        Guard.ExpectCount(args!, 1);

        float side;

        if (!float.TryParse(args![0], out side))
        {
            throw new ArgumentException($"{nameof(SquareBuilder)}: cannot parse {args[0]} to float");
        }
        else
        {
            return new Rectangle { Height = side, DisplayName = "Square", Width = side };
        }
    }
}