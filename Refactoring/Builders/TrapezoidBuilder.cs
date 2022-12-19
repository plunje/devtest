using Refactoring.Builders.Interfaces;
using Refactoring.Models;
using Refactoring.Models.Interfaces;
using Refactoring.Tools;
using System;

namespace Refactoring.Builders;

public class TrapezoidBuilder : IShapeBuilder
{
    public IShape Build(string[]? args)
    {
        ArgumentNullException.ThrowIfNull(args);
        Guard.ExpectCount(args!, 3);

        float height;
        float topwidth;
        float bottomwidth;

        if (!float.TryParse(args![0], out height))
        {
            throw new ArgumentException($"{nameof(TrapezoidBuilder)}: cannot parse {args[0]} to float");
        }
        else if (!float.TryParse(args![1], out topwidth))
        {
            throw new ArgumentException($"{nameof(TrapezoidBuilder)}: cannot parse {args[1]} to float");
        }
        else if (!float.TryParse(args![2], out bottomwidth))
        {
            throw new ArgumentException($"{nameof(TrapezoidBuilder)}: cannot parse {args[2]} to float");
        }
        else
        {
            return new Trapezoid { Height = height, DisplayName = "Trapezoid", TopWidht = topwidth, BottomWidht = bottomwidth };
        }
    }
}


