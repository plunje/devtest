using Refactoring.Commands;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services.Interfaces;

namespace Refactoring.UnitTest.Commands;

public class ResetCommandTests
{
    [Theory]
    [AutoDomainData]
    public void Execute_HappyFlow(
        [Frozen] Mock<IRepository<IShape>> repositoryMock,
        [Frozen] Mock<IDisplayService> displayServiceMock,
        ResetCommand sut,
        string[] args)
    {
        //Act
        sut.Execute(args);

        //Assert
        repositoryMock.Verify(x => x.Reset(), Times.Once);
        displayServiceMock.Verify(x => x.WriteLine($"Reset state!!"), Times.Once);
    }
}
