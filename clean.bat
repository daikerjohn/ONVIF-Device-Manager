@echo > build.log
@echo Clean
"c:\Program Files\Microsoft Visual Studio\2022\Professional\Msbuild\Current\Bin\msbuild.exe" odm.sln -t:Clean -p:Configuration=Release -p:Platform=x64

@echo off
@echo Deleting all BIN and OBJ folders
for /d /r odm %%d in (bin,obj) do (
  @if exist "%%d" (
    REM echo "%%d"
    rd /s/q "%%d"
  )
)
for /d /r onvif %%d in (bin,obj) do (
  @if exist "%%d" (
    REM echo "%%d"
    rd /s/q "%%d"
  )
)
for /d /r utils %%d in (bin,obj) do (
  @if exist "%%d" (
    REM echo "%%d"
    rd /s/q "%%d"
  )
)
for /d /r . %%v in (.vs) do (
  @if exist "%%v" (
    echo "%%v"
    REM rd /s/q "%%d"
  )
)

for /d /r . %%d in (bin,obj,.vs) do (
  @if exist "%%d" (
    echo "%%d"
    REM rd /s/q "%%d"
  )
)

@echo BIN and OBJ folders successfully deleted