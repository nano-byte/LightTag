Param ($Version = "0.1.0-pre")
$ErrorActionPreference = "Stop"
pushd $PSScriptRoot

src\build.ps1 $Version
feed\build.ps1 $Version

popd
