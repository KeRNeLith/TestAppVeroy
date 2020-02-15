<#
.Synopsis
    Gets the MSBuild property name from tag slug.
#>
function GetPropertyNameFromSlug
{
param(
[Parameter(Mandatory)]
[string] $tagSlug)
    switch ($tagSlug)
    {
        'core' { return "Generate_Package"; }
        default { throw "Invalid tag slug." }
    }
}

<#
.Synopsis
    Update the PackagesGeneration.props based on given tag name.
#>
function UpdatePackagesGeneration
{
param(
[Parameter(Mandatory)]
[string] $propertyName)
    # Update the package generation props to enable package generation of the right package
    $genPackagesFilePath = "./src/PackagesGeneration.props";
    $genPackagesContent = Get-Content $genPackagesFilePath;
    $newGenPackagesContent = $genPackagesContent -replace "<$propertyName>\w+<\/$propertyName>","<$propertyName>true</$propertyName>";
    $newGenPackagesContent | Set-Content $genPackagesFilePath;

    # Check content changes (at least one property changed
    $genPackagesContentStr = $genPackagesContent | Out-String;
    $newGenPackagesContentStr = $newGenPackagesContent | Out-String;
    if ($genPackagesContentStr -eq $newGenPackagesContentStr)
    {
        throw "MSBuild property $propertyName does not exist in $genPackagesFilePath.";
    }
}

<#
.Synopsis
    Update the PackagesGeneration.props to generate all packages.
#>
function UpdateAllPackagesGeneration()
{
    # Update the package generation props to enable package generation of the right package
    $genPackagesFilePath = "./src/PackagesGeneration.props";
    $genPackagesContent = Get-Content $genPackagesFilePath;
    $newGenPackagesContent = $genPackagesContent -replace "false","true";
    $newGenPackagesContent | Set-Content $genPackagesFilePath;
}

if ($env:APPVEYOR_REPO_TAG -eq "true")
{
    $tagParts = $tagName.split("/", 2);

    # Retrieve MSBuild property name for which enabling package generation
    $propertyName = GetPropertyNameFromSlug $tagParts[0];
    $tagVersion = $tagParts[1];

    UpdatePackagesGeneration $env:APPVEYOR_REPO_TAG_NAME;
    $env:Build_Version = $tagVersion;
    $env:IsFullIntegrationBuild = true;
}
else
{
    UpdateAllPackagesGeneration;
    $env:Build_Version = "$($env:APPVEYOR_BUILD_VERSION)";
    $env:IsFullIntegrationBuild = "$env:APPVEYOR_PULL_REQUEST_NUMBER" -eq "" -And $env:Configuration -eq "Release";
}

$env:Build_Assembly_Version = "$env:Build_Version" -replace "\-.*","";
"Build_Version: $env:Build_Version";
"Build_Assembly_Version: $env:Build_Assembly_Version";