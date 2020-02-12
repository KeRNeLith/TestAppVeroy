"APPVEYOR_BUILD_ID: $env:APPVEYOR_BUILD_ID";
"APPVEYOR_BUILD_VERSION: $env:APPVEYOR_BUILD_VERSION";
"APPVEYOR_PULL_REQUEST_NUMBER: $env:APPVEYOR_PULL_REQUEST_NUMBER ";

./updatePackagesGeneration.ps1;

if ($env:APPVEYOR_REPO_TAG -eq "true")
{
	./updatePackagesGeneration.ps1;
}
else
{
	$env:Build_Version = "$($env:APPVEYOR_BUILD_VERSION)";
	$env:Build_Assembly_Version = "$env:Build_Version" -replace "\-.*","";
	$env:IsFullIntegrationBuild = "$env:APPVEYOR_PULL_REQUEST_NUMBER" -eq "" -And $env:Configuration -eq "Release";
	"Build_Version: $env:Build_Version";
	"Build_Assembly_Version: $env:Build_Assembly_Version";
}

$env:MyVar = $true;
$env:MyVar2 = $false;
if ($env:MyVar -eq $true)
{
	"MyVar is true"; 
}
else
{
	"MyVar is false";
}
if ($env:MyVar2 -eq $true)
{
	"MyVar2 is true"; 
}
else
{
	"MyVar2 is false";
}

"Integ build: $env:IsFullIntegrationBuild";