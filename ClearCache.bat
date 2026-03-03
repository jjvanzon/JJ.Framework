@echo off
REM %~dp0 = this bat file's dir
echo Calling ClearBin.bat
call "%~dp0ClearBin.bat"
echo ------------------------------------------------------------------
echo Calling ClearObj.bat
call "%~dp0ClearObj.bat"
echo ------------------------------------------------------------------
echo Calling ClearNuget.bat
call "%~dp0ClearNuget.bat"
echo ------------------------------------------------------------------
echo Calling ClearReSharper.bat
call "%~dp0ClearReSharper.bat"
echo ------------------------------------------------------------------
echo Calling ClearVs.bat
call "%~dp0ClearVs.bat"
echo ------------------------------------------------------------------
echo Calling ClearNCrunch.bat
call "%~dp0ClearNCrunch.bat"
echo ------------------------------------------------------------------
echo All done.
pause
