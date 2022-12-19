using System;
using Microsoft.Extensions.DependencyInjection;
using Refactoring.Commands;
using Refactoring.Commands.Interfaces;
using Refactoring.Constants;
using Refactoring.Factories.Interfaces;
using Refactoring.Tools;

namespace Refactoring.Factories;

public class CommandFactory : ICommandFactory
{
    private readonly IServiceProvider _serviceProvider;


    public CommandFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICommand? GetCommand(string[]? args)
    {
        ArgumentNullException.ThrowIfNull(args);
        Guard.ExpectEqualOrMore(args!, 1);

        switch (args![0].ToLowerInvariant())
        {
            case CommandTexts.Create:
                return _serviceProvider.GetService<CreateCommand>();
            case CommandTexts.Sum:
                return _serviceProvider.GetService<SumCommand>();
            case CommandTexts.Reset:
                return _serviceProvider.GetService<ResetCommand>();
            case CommandTexts.Print:
                return _serviceProvider.GetService<PrintCommand>();
            case CommandTexts.Questionmark:
                return _serviceProvider.GetService<ShowCommandsCommand>();
            case CommandTexts.Exit:
                return null;
            default:
                throw new NotSupportedException($"Unknown command '{args[0]}'");
        }
    }
}
