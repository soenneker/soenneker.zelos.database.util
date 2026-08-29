[![](https://img.shields.io/nuget/v/soenneker.zelos.database.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zelos.database.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zelos.database.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zelos.database.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zelos.database.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zelos.database.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zelos.database.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.zelos.database.util/actions/workflows/codeql.yml)

# Soenneker.Zelos.Database.Util

A DI utility that simplifies Zelos database access.

## Install

```bash
dotnet add package Soenneker.Zelos.Database.Util
```

## Quick start

```csharp
using Soenneker.Zelos.Database.Util.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddZelosDatabaseUtilAsSingleton();
```

Adds `IZelosDatabaseUtil` as a singleton service.

## What you get

- `IZelosDatabaseUtil` — A DI utility that simplifies Zelos database access.
- `ZelosDatabaseUtilRegistrar` — A DI utility that simplifies Zelos database access.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ZelosDatabaseUtilRegistrar.AddZelosDatabaseUtilAsSingleton(services)` | Adds `IZelosDatabaseUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `ZelosDatabaseUtilRegistrar.AddZelosDatabaseUtilAsScoped(services)` | Adds `IZelosDatabaseUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Dispose instances you own when their scope ends so held resources can be released.
