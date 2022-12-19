using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Refactoring.UnitTest.Helpers;

public class AutoDomainDataAttribute : AutoDataAttribute
{
    public AutoDomainDataAttribute() : base(() =>
    {
        var fixture = new AutoFixture();
        fixture.Customize<BindingInfo>(c => c.OmitAutoProperties());
        return fixture;
    })
    {
    }
}
