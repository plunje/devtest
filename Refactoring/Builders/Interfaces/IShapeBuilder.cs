using Refactoring.Models.Interfaces;

namespace Refactoring.Builders.Interfaces
{
    public interface IShapeBuilder
    {
        IShape Build(string[]? args);
    }
}
