using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Figma.HttpClients.Abstract;
using Soenneker.Figma.OpenApiClientUtil.Abstract;
using Soenneker.Figma.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Figma.OpenApiClientUtil;

public sealed class FigmaOpenApiClientUtil : IFigmaOpenApiClientUtil
{
    private readonly AsyncSingleton<FigmaOpenApiClient> _client;

    public FigmaOpenApiClientUtil(IFigmaOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<FigmaOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(),
                httpClient: httpClient);

            return new FigmaOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<FigmaOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
