# YamlConfigurator
Manage and extend YAML configuration settings in .NET applications.  This is a package

# YamlConfigurator.Files
YamlConfigurator.Files is a .NET library that facilitates the loading and usage of YAML configuration files in .NET applications. It provides seamless integration with the Microsoft.Extensions.Configuration framework, allowing developers to manage application settings and configurations using YAML files. This library is particularly useful for scenarios where configurations need to be more human-readable and manageable compared to traditional JSON or XML formats.

## Features
- **YAML Configuration Loading:** Load configuration settings from YAML files.
- **Integration with .NET Configuration:** Seamlessly integrate with `Microsoft.Extensions.Configuration` framework.
- **Combine Multiple Configuration Sources:** Use YAML alongside other configuration sources like JSON.
- **Flexible Configuration Management:** Easily manage application settings, including logging, file management, and more.

# YamlConfiguror.Files Management

## Adding `InergyLLC.YamlConfigurator` to NuGet Package Manager in Visual Studio 2022

### Step 1: Open Visual Studio 2022
1. Launch or Open Visual Studio 2022 Project

### Step 2: Open NuGet Package Manager
1. Right-click on your project in Solution Explorer.
2. Select `Manage NuGet Packages`.

### Step 3: Add a New Package Source
1. In the NuGet Package Manager, click on the settings icon (gear).
2. Select `Package Sources` from the options.

![Step 3](https://github.com/inergyllc/YamlConfigurator/blob/master/Resources/Nuget%20package%20manager%201.PNG)

### Step 4: Add the Package Source URL
1. Click the `+` button to add a new package source.
2. Enter the following details:
   - **Name**: `GitHub InergyLLC`
   - **Source**: `https://nuget.pkg.github.com/InergyLLC/index.json`
3. Click `OK` to save the new source.

### Step 5: Close the Package Manager Settings
1. Click `OK` to close the NuGet Package Manager settings.

### Step 6: Select the New Package Source
1. In the NuGet Package Manager, select the newly added source (`GitHub InergyLLC`) from the package source dropdown.

![Step 6](https://github.com/inergyllc/YamlConfigurator/blob/master/Resources/Nuget%20package%20manager%203.PNG)

### Step 7: Search for `YamlConfigurator`
1. In the search box, type `YamlConfigurator.Files`.
2. Press Enter to search.

### Step 8: Install the Package
1. Select `YamlConfigurator.Files` from the search results.
2. Click `Install` to add the package to your project.

---

## Steps to Get a Personal Access Token (PAT) from GitHub

### Step 1: Log in to GitHub
1. Go to [GitHub](https://github.com).
2. Log in with your GitHub credentials.
**You Must Have an Account (I think)**

### Step 2: Go to Settings
1. Click on your profile picture in the top-right corner.
2. Select `Settings` from the dropdown menu.

![Step 2](path/to/image10.png)

### Step 3: Navigate to Developer Settings
1. In the left sidebar, scroll down and click on `Developer settings`.

### Step 4: Personal Access Tokens
1. Click on `Personal access tokens` in the left sidebar.
2. Click on `Tokens (classic)`.
3. Click the `Generate new token (classic)` button.

![Step 4](path/to/image13.png)

### Step 5: Configure the Token
1. Enter a note to describe the token.
2. Select the expiration date for the token.
3. Select the scopes you need 
- `read:pacakges`
- `write:packages`
- `delete:packages`
**You will probably have to go through 2 step authentication here**

#### Step 7: Generate the Token
1. Scroll down and click the `Generate token` button.

#### Step 8: Copy the Token
1. Copy the generated token and save it securely.
**As usual.  The token will not be retrievable after this.  Remember it**

