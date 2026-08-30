using Soenneker.Figma.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.Figma.OpenApiClientUtil.Abstract;
/// <summary>
/// Provides a generated Figma client cached for the lifetime of the utility.
/// </summary>
public interface IFigmaOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured generated Figma client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the client cached by this utility instance.</returns>
    ValueTask<FigmaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
