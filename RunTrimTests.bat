@echo off
REM REM cls

echo RUN TRIM TESTS
echo --------------
echo Runs trimmed exe files, which execute automated tests.
echo Walks the "Framework" folder for "publish\*.Trimming.TestApp.exe" files.
echo Runs them and exits with error code in case tests fail.

REM REM timeout /t 2
echo(

REM /R      = Recursive
REM %~dp0   = Folder of bat file
REM %%F     = File path
REM %%D     = Folder path
REM %%~dpF  = Folder path of the file item
REM /I      = Case-insensitive
REM %%~nxD  = Folder name of the directory item
REM /b      = Prevent quit command line

for /R "%~dp0Framework" %%F in (*.Trimming.TestApp.exe) do (
  for %%D in ("%%~dpF\.") do (
    if /I "%%~nxD"=="publish" (
      echo %%F
      echo(
      "%%F" || (echo Error code %ERRORLEVEL% & goto Failed)
      echo(
    )
  )
)

echo Error code %ERRORLEVEL%
echo Exiting with success
exit /b 0

:Failed
echo Error code %ERRORLEVEL%
echo Exiting with error
exit /b 1