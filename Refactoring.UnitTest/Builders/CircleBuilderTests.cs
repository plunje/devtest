using System;
using System.Linq;
using Refactoring.Builders;
using Refactoring.Models;

namespace Refactoring.UnitTest.Builders;

public class CircleBuilderTests
{
    [Theory]
    [AutoDomainData]
    public void Build_HappyFlow(
        CircleBuilder sut)
    {
        //Arrange
        var fixture = new Helpers.AutoFixture();
        var radius = fixture.Create<double>();
        var args = new string[1] { radius.ToString() };

        //Act
        var result = sut.Build(args);

        //Assert
        result.Should().BeEquivalentTo(

            new Circle { Radius = radius, DisplayName = "Circle" }
        );
    }

    [Theory]
    [AutoDomainData]
    public void Build_InputNull_ThrowsArgumentException(
        CircleBuilder sut)
    {
        //Act
        Action act = () => sut.Build(null);

        //Assert
        act.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("args");
    }

    [Theory]
    [InlineAutoDomainData(0)]
    [InlineAutoDomainData(2)]
    public void Build_InvalidArgumentCount_ThrowsArgumentException(
        int count,
        CircleBuilder sut)
    {
        var fixture = new Helpers.AutoFixture();
        var args = fixture.CreateMany<string>(count).ToArray();

        //Act
        Action act = () => sut.Build(args);

        //Assert
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"1 elements were expected, but found {count} (Parameter 'args')");
    }

    [Theory]
    [AutoDomainData]
    public void Build_InvalidDoubleString_ThrowsArgumentException(
        CircleBuilder sut)
    {
        //Arrange
        var fixture = new Helpers.AutoFixture();
        var invalidDoubleString = fixture.Create<string>();
        var args = new string[1] { invalidDoubleString };

        //Act
        Action act = () => sut.Build(args);

        //Assert
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"CircleBuilder: cannot parse {invalidDoubleString} to float");
    }
}
