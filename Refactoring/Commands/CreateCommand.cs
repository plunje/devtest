using Refactoring.Commands.Interfaces;
using Refactoring.Factories.Interfaces;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services.Interfaces;
using Refactoring.Tools;
using System;
using System.Linq;

namespace Refactoring.Commands;

public class CreateCommand : ICommand
{
    private readonly IShapeBuilderFactory _shapeBuilderFactory;
    private readonly IRepository<IShape> _repository;
    private readonly IDisplayService _displayService;

    public CreateCommand(
        IShapeBuilderFactory shapeBuilderFactory,
        IRepository<IShape> repository,
        IDisplayService displayService)
    {
        _shapeBuilderFactory = shapeBuilderFactory;
        _repository = repository;
        _displayService = displayService;
    }

    public void Execute(string[]? args)
    {
        ArgumentNullException.ThrowIfNull(args);
        Guard.ExpectEqualOrMore(args!, 2);

        var builder = _shapeBuilderFactory.GetShapeBuilder(args);

        var shape = builder.Build(args!.Skip(1).ToArray());

        _repository.Add(shape);

        _displayService.WriteLine($"{shape.DisplayName} created!");
    }
}
