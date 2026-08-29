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
    /// <summary>
    /// Returns the configured figma OpenAPI Client used by the Figma OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested figma OpenAPI Client.</returns>
    ValueTask<FigmaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
