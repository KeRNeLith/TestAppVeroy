if ($env:APPVEYOR_REPO_TAG -eq "true")
{
    $tagParts = $env:APPVEYOR_REPO_TAG_NAME.split("/", 2);

    if ($tagParts.Length -eq 1) # X.Y.Z
    {
        UpdateAllPackagesGeneration;
        $env:Build_Version = $env:APPVEYOR_REPO_TAG_NAME;
        $env:Release_Name = $env:Build_Version;
    }
    else # Slug/X.Y.Z
    {
        $tagSlug = $tagParts[0];
        $tagVersion = $tagParts[1];

        $env:Build_Version = $tagVersion;
        $env:Release_Name = "$projectName $tagVersion";
    }
}
else
{
    $env:Build_Version = "$($env:APPVEYOR_BUILD_VERSION)";
    $env:Release_Name = $env:Build_Version;
}

$env:Build_Assembly_Version = "$env:Build_Version" -replace "\-.*","";

"Building version: $env:Build_Version";
"Building assembly version: $env:Build_Assembly_Version";