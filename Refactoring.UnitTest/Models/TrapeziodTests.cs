using Refactoring.Models;

namespace Refactoring.UnitTest.Models;

public class TrapeziodTests
{
    [Theory]
    [AutoDomainData]
    public void CalculateSurface_RandomValues_ReturnsExpected(
        Trapezoid sut)
    {
        //Act
        var result = sut.CalculateSurface();

        //Assert
        result.Should().BeApproximately(sut.Height * ((sut.BottomWidht + sut.TopWidht) / 2), 5);
    }
}
