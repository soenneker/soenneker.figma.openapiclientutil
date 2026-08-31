[![](https://img.shields.io/nuget/v/soenneker.figma.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.figma.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.figma.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.figma.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.figma.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.figma.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.figma.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.figma.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Figma.OpenApiClientUtil

Provides a scope-cached Kiota client over the long-lived authenticated Figma HTTP client.

## Installation

```bash
dotnet add package Soenneker.Figma.OpenApiClientUtil
```

## Register the utility

```csharp
using Soenneker.Figma.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddFigmaOpenApiClientUtilAsScoped();
```

The scoped registration deliberately registers `IFigmaOpenApiHttpClient` as a singleton. Each application scope may dispose its utility and generated-client wrapper without discarding the HTTP transport needed by later scopes.

Use `AddFigmaOpenApiClientUtilAsSingleton()` only when the generated client itself should live for the entire service provider lifetime. Both registration methods use `TryAdd`, allowing an application-provided implementation to win.

## Configuration

```json
{
  "Figma": {
    "ApiKey": "your-figma-token"
  }
}
```

Authentication and base-address settings are owned by `Soenneker.Figma.HttpClients`. `Figma:ApiKey` is required; `ClientBaseUrl`, `AuthHeaderName`, and `AuthHeaderValueTemplate` are optional overrides under the same section. Keep the token in secret storage.

## Use the generated client

```csharp
public sealed class FigmaFileReader(IFigmaOpenApiClientUtil clientUtil)
{
    public async Task<GetFileResponseResponse?> Get(
        string fileKey,
        CancellationToken cancellationToken)
    {
        FigmaOpenApiClient client = await clientUtil.Get(cancellationToken);
        return await client.V1.Files[fileKey].GetAsync(cancellationToken: cancellationToken);
    }
}
```

`Get()` initializes at most one generated client per utility instance and returns that instance on later calls. The underlying `HttpClient` already carries the configured authentication header, so the Kiota adapter does not add a duplicate header.

The service container owns registered instances; do not dispose an injected instance manually. Resolve scoped instances only inside a scope.
