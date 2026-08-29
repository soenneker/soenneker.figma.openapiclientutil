[![](https://img.shields.io/nuget/v/soenneker.figma.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.figma.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.figma.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.figma.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.figma.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.figma.openapiclientutil/)

# Soenneker.Figma.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Figma.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Figma.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddFigmaOpenApiClientUtilAsSingleton();
```

Adds `FigmaOpenApiClientUtil` as a singleton service.

## What you get

- `IFigmaOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `FigmaOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `FigmaOpenApiClientUtilRegistrar.AddFigmaOpenApiClientUtilAsSingleton(services)` | Adds `FigmaOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `FigmaOpenApiClientUtilRegistrar.AddFigmaOpenApiClientUtilAsScoped(services)` | Adds `FigmaOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
