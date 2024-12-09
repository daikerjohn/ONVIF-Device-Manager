@echo off

call clean.bat

REM @echo Restore
REM "c:\Program Files\Microsoft Visual Studio\2022\Professional\Msbuild\Current\Bin\msbuild.exe" odm.sln -restore -p:RestorePackagesConfig=true

time /t
@echo Build
"c:\Program Files\Microsoft Visual Studio\2022\Professional\Msbuild\Current\Bin\msbuild.exe" odm.sln -restore -p:RestorePackagesConfig=true -t:Build -p:Configuration=Release -p:Platform=x64 -fileLoggerParameters:LogFile=build.log;Verbosity=minimal;Encoding=UTF-8 -noConsoleLogger -maxCpuCount:4

time /t