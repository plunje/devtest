namespace Refactoring.UnitTest.Helpers;

public class AutoFixture : Fixture
{
    public AutoFixture()
    {
        this.Customize(new AutoMoqCustomization());
    }
}
