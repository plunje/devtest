using Refactoring.Commands.Interfaces;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services.Interfaces;

namespace Refactoring.Commands;

public class ResetCommand : ICommand
{
    private readonly IRepository<IShape> _repository;
    private readonly IDisplayService _displayService;

    public ResetCommand(
        IRepository<IShape> repository, IDisplayService displayService)
    {
        _repository = repository;
        _displayService = displayService;
    }

    public void Execute(string[]? args)
    {
        _repository.Reset();
        _displayService.WriteLine("Reset state!!");
    }
}
