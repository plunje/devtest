using Refactoring.Models;

namespace Refactoring.UnitTest.Models;

public class CircleTests
{
    [Theory]
    [AutoDomainData]
    public void CalculateSurface_RandomValues_ReturnsExpected(
        Circle sut)
    {
        //Act
        var result = sut.CalculateSurface();

        //Assert
        result.Should().BeApproximately(sut.Radius * sut.Radius * Math.PI, 5);
    }
}
