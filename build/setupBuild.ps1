# Update .props based on git tag status & setup build version
$env:Build_Version = "$($env:APPVEYOR_BUILD_VERSION)";
$env:Build_Assembly_Version = "$env:Build_Version" -replace "\-.*","";
$env:IsFullIntegrationBuild = $true;
$env:Release_Name = $env:Build_Version;

"Building version: $env:Build_Version";
"Building assembly version: $env:Build_Assembly_Version";

if ($env:IsFullIntegrationBuild -eq $true)
{
    "With full integration";

    $env:PATH="C:\Program Files\Java\jdk15\bin;$($env:PATH)"
    $env:JAVA_HOME_11_X64='C:\Program Files\Java\jdk15'
    $env:JAVA_HOME='C:\Program Files\Java\jdk15'
}
else
{
    "Without full integration";
}