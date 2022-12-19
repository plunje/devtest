using Refactoring.Builders.Interfaces;
using Refactoring.Commands;
using Refactoring.Factories.Interfaces;
using Refactoring.Models;
using Refactoring.Models.Interfaces;
using Refactoring.Repositories.Interfaces;
using Refactoring.Services.Interfaces;

namespace Refactoring.UnitTest.Commands;

public class CreateCommandTests
{
    [Theory]
    [InlineAutoDomainData(2)]
    [InlineAutoDomainData(3)]
    [InlineAutoDomainData(4)]
    public void Execute_HappyFlow(
        int count,
        [Frozen] Mock<IShapeBuilderFactory> shapeBuilderFactoryMock,
        [Frozen] Mock<IRepository<IShape>> repositoryMock,
        [Frozen] Mock<IDisplayService> displayServiceMock,
        [Frozen] Mock<IShapeBuilder> shapebuilderMock,
        CreateCommand sut,
        Circle shape)
    {
        //Arrange
        var fixture = new Helpers.AutoFixture();
        var args = fixture.CreateMany<string>(count).ToArray();

        shapeBuilderFactoryMock.Setup(x => x.GetShapeBuilder(args))
            .Returns(shapebuilderMock.Object);

        shapebuilderMock.Setup(x => x.Build(It.Is<string[]>(y => y.SequenceEqual(args.Skip(1)))))
            .Returns(shape);

        //Act
        sut.Execute(args);

        //Assert
        repositoryMock.Verify(x => x.Add(shape), Times.Once);
        displayServiceMock.Verify(x => x.WriteLine($"{shape.DisplayName} created!"), Times.Once);
    }

    [Theory]
    [AutoDomainData]
    public void Execute_InputNull_ThrowsArgumentException(
        CreateCommand sut)
    {
        //Act
        Action act = () => sut.Execute(null);

        //Assert
        act.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("args");
    }

    [Theory]
    [InlineAutoDomainData(0)]
    [InlineAutoDomainData(1)]
    public void Execute_InvalidArgumentCount_ThrowsArgumentException(
        int count,
        CreateCommand sut)
    {
        var fixture = new Helpers.AutoFixture();
        var args = fixture.CreateMany<string>(count).ToArray();

        //Act
        Action act = () => sut.Execute(args);

        //Assert
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"2 elements or more were expected, but found {count} (Parameter 'args')");
    }
}
