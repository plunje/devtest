using System.Collections.Generic;
using Refactoring.Commands;
using Refactoring.Models;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services.Interfaces;

namespace Refactoring.UnitTest.Commands;

public class SumCommandTests
{
    [Theory]
    [AutoDomainData]
    public void Execute_HappyFlow(
        [Frozen] Mock<IRepository<IShape>> repositoryMock,
        [Frozen] Mock<IDisplayService> displayServiceMock,
        List<Rectangle> shapes,
        SumCommand sut,
        string[] args)
    {
        //Arrange
        repositoryMock.Setup(x => x.GetAll()).
            Returns(shapes);

        //Act
        sut.Execute(args);

        //Assert
        var total = shapes.Sum(x => x.CalculateSurface());

        displayServiceMock.Verify(x => x.WriteLine($"Total surfaces is {total}"), Times.Once);

        displayServiceMock.VerifyNoOtherCalls();
    }
}
