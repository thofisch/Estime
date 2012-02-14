cls

Import-Module '.\Tools\PSake\psake.psm1'
Invoke-psake '.\build\build.ps1' Test -framework 3.5
Remove-Module psake