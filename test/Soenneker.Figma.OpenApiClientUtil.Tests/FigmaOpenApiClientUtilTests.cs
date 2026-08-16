using Soenneker.Figma.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Figma.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class FigmaOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IFigmaOpenApiClientUtil _openapiclientutil;

    public FigmaOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IFigmaOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
