namespace Refactoring.UnitTest.Helpers;

public class InlineAutoDomainDataAttribute : InlineAutoDataAttribute
{
    public InlineAutoDomainDataAttribute(params object[] objects) : base(new AutoDomainDataAttribute(), objects)
    {
    }
}
