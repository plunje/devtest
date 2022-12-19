using System.Linq;
using Refactoring.Commands.Interfaces;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services.Interfaces;

namespace Refactoring.Commands;

public class PrintCommand : ICommand
{
    private readonly IRepository<IShape> _repository;
    private readonly IDisplayService _displayService;

    public PrintCommand(
        IRepository<IShape> repository,
        IDisplayService displayService)
    {
        _repository = repository;
        _displayService = displayService;
    }

    public void Execute(string[]? args)
    {
        var cnt = 0;
        var shapes = _repository.GetAll();
        if (shapes.Any())
        {
            foreach (var shape in shapes)
            {
                _displayService.WriteLine($"[{cnt++}] {shape.DisplayName} surface area is {shape.CalculateSurface()}");
            }
        }
        else
        {
            _displayService.WriteLine("There are no surface areas to print");
        }
    }
}
