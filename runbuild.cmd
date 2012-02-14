powershell -Command "& {Import-Module .\Tools\PSake\psake.psm1; Invoke-psake .\build\build.ps1 %*}"
pause