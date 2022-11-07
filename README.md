# Doulex.DotNetCore

[![Build status](https://ci.appveyor.com/api/projects/status/4m0v88ayw844oh58?svg=true)](https://ci.appveyor.com/project/nepton/doulex-dotnetcore)
![GitHub issues](https://img.shields.io/github/issues/nepton/Doulex.DotNetCore.svg)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/nepton/Doulex.DotNetCore/blob/master/LICENSE)

## Nuget packages

| Name                   | Version                                                                                                                                                             | Downloads                                                                                                                                                            |
|------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Doulex.DotNetCore      | [![nuget](https://img.shields.io/nuget/v/Doulex.DotNetCore.svg)](https://www.nuget.org/packages/Doulex.DotNetCore/)                                         | [![stats](https://img.shields.io/nuget/dt/Doulex.DotNetCore.svg)](https://www.nuget.org/packages/Doulex.DotNetCore/)                                         |

## Usage

Creating a client and trying to invoke getCurrentUser method:

```csharp
// use yaml configuration file replace with your own
builder.Configuration.ReplaceJsonFilesToYaml();

// use attribute to inject configuration based scrutor
builder.Services.AddScrutorDependencyInjectionInProjects();
```

## Final

Leave a comment on GitHub if you have any questions or suggestions.

Turn on the star if you like this project.

## License

This project is licensed under the MIT License
