REM /d    = directories
REM /r    = recurse
REM %~dp0 = Folder of bat file
REM %%D   = Folder path
REM /s    = recursive
REM /q    = quiet

@echo off
for /d /r "%~dp0" %%D in (obj) do (
    if exist "%%D" (
        echo Deleting "%%D"
        rd /s /q "%%D"
    )
)
echo Done.

