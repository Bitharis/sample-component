<#  
    .Description
    The build script:
    Publishes the two projects as self-contained executables.
    Creates a plugin.zip archive containing the self-contained applications and the metadata.json.
    Signs the archive and creates the bundled zip file that contains the plugin.zip the certificae and the signature.
#>

$pluginArchiveFileName = "plugin.zip"

if(Test-Path $pluginArchiveFileName){
    Write-Output "Removing old plugin.zip file..."
    Remove-Item $pluginArchiveFileName -Recurse -Force
    Write-Output "Removed old plugin.zip file..."
}

Write-Output "Publish WebService.proj"
dotnet publish ..\WebService\WebService.csproj -c Release -o "..\AXIS Sample Certificate Component" -r win-x64

Write-Output "Publish SampleComponent.proj"
dotnet publish ..\SampleComponent\SampleComponent.csproj -c Release -o ..\ -r win-x64

Compress-Archive -Path ..\metadata.json -DestinationPath plugin.zip
Compress-Archive -Path "..\AXIS Sample Certificate Component" -Update -DestinationPath plugin.zip
Compress-Archive -Path ..\SampleComponent.exe -Update -DestinationPath plugin.zip

Remove-Item "..\AXIS Sample Certificate Component" -Recurse -Force
Remove-Item ..\SampleComponent.exe -Recurse -Force

# Component signature logic here and creation of outer zip file
