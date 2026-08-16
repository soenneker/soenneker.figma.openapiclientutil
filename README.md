[![](https://img.shields.io/nuget/v/soenneker.figma.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.figma.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.figma.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.figma.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.figma.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.figma.openapiclientutil/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Figma.OpenApiClientUtil
### A thread-safe utility for obtaining Figma's OpenApiClient singleton.

## Installation

```
dotnet add package Soenneker.Figma.OpenApiClientUtil
```

## Configuration

For a personal access token:

```json
{
  "Figma": {
    "ApiKey": "your-personal-access-token"
  }
}
```

The default header is `X-Figma-Token`. For an OAuth access token, configure
`AuthHeaderName` as `Authorization` and `AuthHeaderValueTemplate` as `Bearer {token}`.
