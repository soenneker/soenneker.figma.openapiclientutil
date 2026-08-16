using Soenneker.Figma.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Figma.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IFigmaOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<FigmaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
