Param ($Version = "0.1.0-pre", [switch]$GitHubRelease)
$ErrorActionPreference = "Stop"
pushd $PSScriptRoot

# Ensure 0install is in the PATH
if (!(Get-Command 0install -ErrorAction SilentlyContinue)) {
    mkdir -Force "$env:TEMP\zero-install" | Out-Null
    Invoke-WebRequest "https://0install.de/files/0install.exe" -OutFile "$env:TEMP\zero-install\0install.exe"
    $env:PATH = "$env:TEMP\zero-install;$env:PATH"
}

# Exclude .NET XML Documentation and Debug Symbols from release
rm -Force ..\artifacts\Release\*.xml,..\artifacts\Release\*.pdb

# Build feed and archive
$stability = if($Version.Contains('-')) {'developer'} else {'stable'}
cmd /c "0install run --batch http://0install.net/tools/0template.xml LightTag.xml.template version=$Version stability=$stability 2>&1" # Redirect stderr to stdout
if ($LASTEXITCODE -ne 0) {throw "Exit Code: $LASTEXITCODE"}

# Patch archive URL to point to GitHub Release
if ($GitHubRelease) {
    $path = Resolve-Path "LightTag-$Version.xml"
    [xml]$xml = Get-Content $path
    $xml.interface.group.implementation.archive.href = "https://github.com/nano-byte/LightTag/releases/download/$Version/$($xml.interface.group.implementation.archive.href)"
    $xml.Save($path)
}

popd
