﻿Param ($Version = "0.1.0-pre")
$ErrorActionPreference = "Stop"
pushd $PSScriptRoot

$vsDir = . "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -latest -property installationPath -format value
$msBuild = "$vsDir\MSBuild\15.0\Bin\amd64\MSBuild.exe"
. $msBuild -v:Quiet -t:Restore -t:Build -p:Configuration=Release -p:Version=$Version

popd
