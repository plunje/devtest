using Refactoring.Commands.Interfaces;
using Refactoring.Constants;
using Refactoring.Services.Interfaces;

namespace Refactoring.Commands;

public class ShowCommandsCommand : ICommand
{
    private readonly IDisplayService _displayService;

    public ShowCommandsCommand(IDisplayService displayService)
    {
        _displayService = displayService;
    }

    public void Execute(string[]? args)
    {
        _displayService.WriteLine("commands:");
        _displayService.WriteLine("- ? (show commands)");
        _displayService.WriteLine($"- {CommandTexts.Create} {CommandParameters.Square} {{side}} (create a new square)");
        _displayService.WriteLine($"- {CommandTexts.Create} {CommandParameters.Circle} {{radius}} (create a new circle)");
        _displayService.WriteLine($"- {CommandTexts.Create} {CommandParameters.Rectangle} {{height}} {{width}} (create a new rectangle)");
        _displayService.WriteLine($"- {CommandTexts.Create} {CommandParameters.Triangle} {{height}} {{width}} (create a new triangle)");
        _displayService.WriteLine($"- {CommandTexts.Create} {CommandParameters.Trapezoid} {{height}} {{topwidth}} {{bottomwidth}} (create a new trapezoid)");
        _displayService.WriteLine($"- {CommandTexts.Print} (print the calculated surface areas)");
        _displayService.WriteLine($"- {CommandTexts.Sum} (prints the sum of the surfaces)");
        _displayService.WriteLine($"- {CommandTexts.Reset} (reset)");
        _displayService.WriteLine($"- {CommandTexts.Exit} (exit the loop)");
    }
}
