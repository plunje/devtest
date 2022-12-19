namespace Refactoring.Commands.Interfaces;

public interface ICommand
{
    void Execute(string[]? args);
}
