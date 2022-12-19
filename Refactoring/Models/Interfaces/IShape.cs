namespace Refactoring.Models.Interfaces;

public interface IShape
{
    double CalculateSurface();
    string DisplayName { get; }
}
