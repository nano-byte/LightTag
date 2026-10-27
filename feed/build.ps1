Param ($Version = "1.0.0-pre")
$ErrorActionPreference = "Stop"
pushd $PSScriptRoot

echo "Build feed"
$stability = if ($Version.Contains("-")) {"developer"} else {"stable"}
..\0install.ps1 run --batch https://apps.0install.net/0install/0template.xml LightTag.xml.template version=$Version stability=$stability
if ($LASTEXITCODE -ne 0) {throw "Exit Code: $LASTEXITCODE"}

popd
