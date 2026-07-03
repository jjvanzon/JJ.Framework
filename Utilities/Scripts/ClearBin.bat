@echo off

REM /d    = directories
REM /r    = recurse
REM %~dp0 = Folder of bat file
REM .     = Current folder
REM %%D   = Folder path
REM /s    = recursive
REM /q    = quiet

rem for /d /r "%~dp0" %%D in (bin) do (
for /d /r "." %%D in (bin) do (
    if exist "%%D" (
        echo Deleting "%%D"
        rd /s /q "%%D"
    )
)
echo Done.

