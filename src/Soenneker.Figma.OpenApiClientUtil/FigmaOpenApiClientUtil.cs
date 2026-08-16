using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Figma.HttpClients.Abstract;
using Soenneker.Figma.OpenApiClientUtil.Abstract;
using Soenneker.Figma.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Figma.OpenApiClientUtil;

///<inheritdoc cref="IFigmaOpenApiClientUtil"/>
public sealed class FigmaOpenApiClientUtil : IFigmaOpenApiClientUtil
{
    private readonly AsyncSingleton<FigmaOpenApiClient> _client;

    public FigmaOpenApiClientUtil(IFigmaOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<FigmaOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Figma:ApiKey");
            string authHeaderName = configuration["Figma:AuthHeaderName"] ?? "X-Figma-Token";
            string authHeaderValueTemplate = configuration["Figma:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
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
