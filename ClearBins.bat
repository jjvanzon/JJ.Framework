rem %~dp0 : the bat file's own directory
rem for /d /r ... in (bin) — matches folders exactly named bin (not e.g. bin64).
rem %%D - 

@echo off
for /d /r "%~dp0" %%D in (bin) do (
    if exist "%%D" (
        echo Deleting "%%D"
        rd /s /q "%%D"
    )
)
echo Done.
