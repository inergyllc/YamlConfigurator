# YamlConfigurator
Manage and extend YAML configuration settings in .NET applications.

## YamlConfigurator.Files
YamlConfigurator.Files is a .NET library that facilitates the loading and usage of YAML configuration files in .NET applications. It provides seamless integration with the Microsoft.Extensions.Configuration framework, allowing developers to manage application settings and configurations using YAML files. This library is particularly useful for scenarios where configurations need to be more human-readable and manageable compared to traditional JSON or XML formats.

### Features
- **YAML Configuration Loading:** Load configuration settings from YAML files.
- **Integration with .NET Configuration:** Seamlessly integrate with `Microsoft.Extensions.Configuration` framework.
- **Combine Multiple Configuration Sources:** Use YAML alongside other configuration sources like JSON.
- **Flexible Configuration Management:** Easily manage application settings, including logging, file management, and more.

## YamlConfigurator.Files Management

### Adding `InergyLLC.YamlConfigurator` to NuGet Package Manager in Visual Studio 2022

#### Step 1: Open Visual Studio 2022
1. Launch or open your Visual Studio 2022 project.

#### Step 2: Open NuGet Package Manager
1. Right-click on your project in Solution Explorer.
2. Select `Manage NuGet Packages`.

#### Step 3: Add a New Package Source
1. In the NuGet Package Manager, click on the settings icon (gear).
2. Select `Package Sources` from the options.

![Step 3](https://github.com/inergyllc/YamlConfigurator/blob/master/Resources/Nuget%20package%20manager%201.PNG)

#### Step 4: Add the Package Source URL
1. Click the `+` button to add a new package source.
2. Enter the following details:
   - **Name**: `GitHub InergyLLC`
   - **Source**: `https://nuget.pkg.github.com/InergyLLC/index.json`
3. Click `OK` to save the new source.

#### Step 5: Close the Package Manager Settings
1. Click `OK` to close the NuGet Package Manager settings.

#### Step 6: Select the New Package Source
1. In the NuGet Package Manager, select the newly added source (`GitHub InergyLLC`) from the package source dropdown.

![Step 6](https://github.com/inergyllc/YamlConfigurator/blob/master/Resources/Nuget%20package%20manager%203.PNG)

#### Step 7: Search for `YamlConfigurator`
1. In the search box, type `YamlConfigurator.Files`.
2. Press Enter to search.

#### Step 8: Install the Package
1. Select `YamlConfigurator.Files` from the search results.
2. Click `Install` to add the package to your project.

---

## Steps to Get a Personal Access Token (PAT) from GitHub

### Step 1: Log in to GitHub
1. Go to [GitHub](https://github.com).
2. Log in with your GitHub credentials.

### Step 2: Go to Settings
1. Click on your profile picture in the top-right corner.
2. Select `Settings` from the dropdown menu.

![Step 2](https://github.com/inergyllc/YamlConfigurator/blob/master/Resources/github%20PAT%201.png)

### Step 3: Navigate to Developer Settings
1. In the left sidebar, scroll down and click on `Developer settings`.

### Step 4: Personal Access Tokens
1. Click on `Personal access tokens` in the left sidebar.
2. Click on `Tokens (classic)`.
3. Click the `Generate new token (classic)` button.

![Step 4](https://github.com/inergyllc/YamlConfigurator/blob/master/Resources/github%20PAT%202.png)

### Step 5: Configure the Token
1. Enter a note to describe the token.
2. Select the expiration date for the token.
3. Select the scopes you need:
   - `read:packages`
   - `write:packages`
   - `delete:packages`

#### Step 7: Generate the Token
1. Scroll down and click the `Generate token` button.

#### Step 8: Copy the Token
1. Copy the generated token and save it securely.

**Note: The token will not be retrievable after this. Ensure you store it securely.**

## Usage Example
Here's a sample code demonstrating how to use the YamlConfigurator.Files package:

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.Yaml;
using YamlConfigurator.Files;

namespace YamlConfigurator.Files.Tests
{
    class Program
    {
        static void Main()
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddYamlFile("appsettings.yaml", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .AddSingleton<IConfiguration>(configuration)
                .BuildServiceProvider();

            // Get a logger instance
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            // Get a specific file configuration (example: "results")
            var filesManagerConfig = configuration.GetFilesManagerConfiguration();
            var excelFileConfig = filesManagerConfig.GetFileByName("results");
            var journalFileConfig = filesManagerConfig.GetFileByName("journal");

            // Display the file configuration - INFORMATION LOGGER
            logger.LogInformation("INFO: File Configuration:");
            logger.LogInformation("INFO: Name: {value}", excelFileConfig.Name);
            logger.LogInformation("INFO: Type: {value}", excelFileConfig.Type);
            logger.LogInformation("INFO: Root: {value}", excelFileConfig.Root);
            logger.LogInformation("INFO: Extension: {value}", excelFileConfig.Extension);
            logger.LogInformation("INFO: Folder: {value}", excelFileConfig.Folder);
            logger.LogInformation("INFO: Timestamp: {value}", excelFileConfig.Timestamp);
            logger.LogInformation("INFO: Force: {value}", excelFileConfig.Force);
            logger.LogInformation("INFO: Append: {value}", excelFileConfig.Append);
            logger.LogInformation("INFO: Full Path: {value}", excelFileConfig.Path);
        }
    }
}
