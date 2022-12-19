using Refactoring.Builders.Interfaces;

namespace Refactoring.Factories.Interfaces;

public interface IShapeBuilderFactory
{
    IShapeBuilder GetShapeBuilder(string[]? args);
}
