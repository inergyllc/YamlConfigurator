function Add-DotnetPackage {
    param (
        [string]$PackageName,
        [string]$PrereleaseFlag
    )

    # Check if the package is already installed
    $installed = dotnet list package --include-transitive | Select-String -Pattern $PackageName

    if ($installed -eq $null) {
        Write-Host "Installing package: $PackageName"
        dotnet add package $PackageName $PrereleaseFlag
    } else {
        Write-Host "Package already installed: $PackageName"
    }
}

# Set the project directory
# Env var from witing project did not work, and I do not feel like tracking it down
# $projectDir = $env:ProjectDir
$projectDir = ".\YamlConfigurator.Files"
if ($null -eq $projectDir) {
    Write-Host "Project directory not found."
} else {
    Write-Host "Project Directory: $projectDir"
    # You can also set the location to the project directory if needed
    Set-Location -Path $projectDir

    # Install packages
    Add-DotnetPackage "Microsoft.Extensions.Configuration" "--prerelease"
    Add-DotnetPackage "Microsoft.Extensions.Configuration.FileExtensions" "--prerelease"
    Add-DotnetPackage "Microsoft.Extensions.Configuration.Json" "--prerelease"
    Add-DotnetPackage "Microsoft.Extensions.Configuration.Yaml" "--prerelease"
    Add-DotnetPackage "Microsoft.Extensions.DependencyInjection" "--prerelease"
    Add-DotnetPackage "Microsoft.Extensions.Configuration.Binder" "--prerelease"
}
