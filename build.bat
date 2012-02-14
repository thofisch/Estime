@ECHO OFF
@CLS

IF [%1]==[] GOTO default

%WinDir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe /nologo /verbosity:normal /target:%1 build/build.proj

GOTO exit

:default

%WinDir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe /nologo /verbosity:normal  build/build.proj

:exit