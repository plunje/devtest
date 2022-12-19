using Refactoring.Commands.Interfaces;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services.Interfaces;
using System.Linq;

namespace Refactoring.Commands
{
    public class SumCommand : ICommand
    {
        private readonly IRepository<IShape> _repository;
        private readonly IDisplayService _displayService;

        public SumCommand(
            IRepository<IShape> repository,
            IDisplayService displayService)
        {
            _repository = repository;
            _displayService = displayService;
        }

        public void Execute(string[]? args)
        {
            _displayService.WriteLine($"Total surfaces is {_repository.GetAll().Sum(x => x.CalculateSurface())}");
        }
    }
}