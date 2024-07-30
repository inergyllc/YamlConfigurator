# YamlConfigurator
A library for seamlessly managing and extending YAML-based configuration settings in .NET applications.

# YamlConfigurator.Files
YamlConfigurator.Files is a .NET library that facilitates the loading and usage of YAML configuration files in .NET applications. It provides seamless integration with the Microsoft.Extensions.Configuration framework, allowing developers to manage application settings and configurations using YAML files. This library is particularly useful for scenarios where configurations need to be more human-readable and manageable compared to traditional JSON or XML formats.

## Features
- **YAML Configuration Loading:** Load configuration settings from YAML files.
- **Integration with .NET Configuration:** Seamlessly integrate with `Microsoft.Extensions.Configuration` framework.
- **Combine Multiple Configuration Sources:** Use YAML alongside other configuration sources like JSON.
- **Flexible Configuration Management:** Easily manage application settings, including logging, file management, and more.


# How to Load YamlConfigurator.Files NuGet Package

The `YamlConfigurator.Files` package is publicly available and can be added to your project using the NuGet Package Manager or the `dotnet` CLI by referencing the URL directly. Follow the instructions below to add it to your project.

## Using NuGet Package Manager

1. **Add the Package to Your Project:**

   - Open Visual Studio.
   - Right-click on your project in the Solution Explorer.
   - Select `Manage NuGet Packages...`.
   - Click on the `Settings` icon (gear icon) to open the Package Manager Settings.
   - Add a new package source by clicking the `+` button.
     - Name: `YamlConfigurator.Files`
     - Source: `https://github.com/inergyllc/YamlConfigurator/raw/master/Nugets/YamlConfigurator.Files.1.0.0.nupkg`
   - Click `OK` to save the new package source.
   - Now, you can browse or search for `YamlConfigurator.Files` in the NuGet Package Manager and install it.

## Using `dotnet` CLI

1. **Add the Package to Your Project:**

   - Open a command prompt or terminal.
   - Navigate to the directory where your project file (`.csproj`) is located.
   - Run the following command to add the package:

     ```sh
     dotnet nuget add source -n YamlConfiguratorFiles "https://github.com/inergyllc/YamlConfigurator/raw/master/Nugets/YamlConfigurator.Files.1.0.0.nupkg"
     dotnet add package YamlConfigurator.Files --source YamlConfiguratorFiles
     ```
