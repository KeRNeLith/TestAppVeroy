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
[string] $tagName)
    $tagParts = $tagName.split("/", 2);

    # Retrieve MSBuild property name for which enabling package generation
    $propertyName = GetPropertyNameFromSlug $tagParts[0];

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
        throw "MSBuild property $propertyName does not exist in $genPackagesFilePath."
    }
}

UpdatePackagesGeneration $env:APPVEYOR_REPO_TAG_NAME