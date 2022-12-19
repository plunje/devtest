using Refactoring.Commands;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services.Interfaces;

namespace Refactoring.UnitTest.Commands;

public class PrintCommandTests
{
    [Theory]
    [AutoDomainData]
    public void Execute_HappyFlow(
        [Frozen] Mock<IRepository<IShape>> repositoryMock,
        [Frozen] Mock<IDisplayService> displayServiceMock,
        Mock<IShape> shapeMock,
        PrintCommand sut,
        string[] args)
    {
        //Arrange
        shapeMock.Setup(x => x.CalculateSurface()).Returns(0);
        shapeMock.SetupGet(x => x.DisplayName).Returns("Shape");

        repositoryMock.Setup(x => x.GetAll()).
            Returns(new[] { shapeMock.Object, shapeMock.Object, shapeMock.Object });

        //Act
        sut.Execute(args);

        //Assert
        displayServiceMock.Verify(x => x.WriteLine($"[0] Shape surface area is 0"), Times.Once);
        displayServiceMock.Verify(x => x.WriteLine($"[1] Shape surface area is 0"), Times.Once);
        displayServiceMock.Verify(x => x.WriteLine($"[2] Shape surface area is 0"), Times.Once);

        displayServiceMock.VerifyNoOtherCalls();
    }

    [Theory]
    [AutoDomainData]
    public void Execute_NoItems(
        [Frozen] Mock<IRepository<IShape>> repositoryMock,
        [Frozen] Mock<IDisplayService> displayServiceMock,
        PrintCommand sut,
        string[] args)
    {
        //Arrange
        repositoryMock.Setup(x => x.GetAll()).
            Returns(Array.Empty<IShape>);

        //Act
        sut.Execute(args);

        //Assert
        displayServiceMock.Verify(x => x.WriteLine("There are no surface areas to print"), Times.Once);
        displayServiceMock.VerifyNoOtherCalls();
    }
}
