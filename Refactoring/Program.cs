using Microsoft.Extensions.DependencyInjection;
using Refactoring.Commands;
using Refactoring.Factories;
using Refactoring.Factories.Interfaces;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services;
using Refactoring.Services.Interfaces;

namespace Refactoring
{
    static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IStateMachineService, StateMachineService>()
                .AddTransient<IDisplayService, DisplayService>()
                .AddTransient<CreateCommand>()
                .AddTransient<SumCommand>()
                .AddTransient<ResetCommand>()
                .AddTransient<ShowCommandsCommand>()
                .AddTransient<PrintCommand>()
                .AddTransient<IShapeBuilderFactory, ShapeBuilderFactory>()
                .AddTransient<ICommandFactory, CommandFactory>()
                .AddSingleton<IRepository<IShape>, Repository<IShape>>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<IStateMachineService>();
            service?.Go();
        }
    }
}

