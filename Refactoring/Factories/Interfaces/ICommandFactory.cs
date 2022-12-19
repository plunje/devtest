using Refactoring.Commands.Interfaces;

namespace Refactoring.Factories.Interfaces;

public interface ICommandFactory
{
    ICommand? GetCommand(string[]? args);
}
