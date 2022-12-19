using System;
using System.Linq;
using Refactoring.Commands;
using Refactoring.Constants;
using Refactoring.Factories.Interfaces;
using Refactoring.Services.Interfaces;

namespace Refactoring.Services;

internal class StateMachineService : IStateMachineService
{
    private readonly ICommandFactory _commandFactory;
    private readonly IDisplayService _displayService;
    private readonly ShowCommandsCommand _showCommandsCommand;

    public StateMachineService(
        ICommandFactory commandFactory,
        IDisplayService displayService,
        ShowCommandsCommand showCommandsCommand)
    {
        _commandFactory = commandFactory;
        _displayService = displayService;
        _showCommandsCommand = showCommandsCommand;
    }

    public void Go()
    {
        _showCommandsCommand.Execute(null);

        while (true)
        {
            var line = _displayService.ReadLine();

            var args = line?.Split(' ') ?? new string[0];

            try
            {
                var cmd = _commandFactory.GetCommand(args);

                if (cmd != null)
                {
                    cmd.Execute(args.Skip(1).ToArray());
                }
                else
                {
                    break;
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException || ex is NotSupportedException)
            {
                _displayService.WriteLine($"Invalid command ({ex.Message})");
                _displayService.WriteLine($"Type {CommandTexts.Questionmark} for available commands");
            }
        }
    }
}
