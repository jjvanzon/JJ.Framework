@echo off
cls

REM 1st attempt (doesn't insist on "publish" folder)
REM ------------------------------------------------
REM for /R "%~dp0Framework" %%FILE in (*.Trimming.TestApp.exe) do "%%FILE" || exit /b %%ERRORLEVEL%%

REM 2nd attempt (* is AI BS, doesn't work)
REM --------------------------------------
REM /F = Run items as commands
REM /B = Dir bare output = file paths
REM /S = Recursive
REM /b = Exit bat, but prevent quit cmd
REM %%F = File path
REM %~dp0 = Folder path of bat file
REM "delims=" = Don't split tokens, keep whole lines

REM for /F "delims=" %%F in ('dir /B /S "%~dp0Framework\*\publish\*.Trimming.TestApp.exe"') do "%%F" || exit /b %%ERRORLEVEL%%

REM 3rd attempt
REM -----------

REM /R         = for /R “root”: recurse into all subdirectories
REM %%F        = loop variable inside a .bat (use %F interactively)
REM %~dp0      = drive & path of this script file (with trailing “\”)
REM %%~dpF     = drive & path of the current %%F file’s folder (with trailing “\”)
REM %%~nxD     = name & extension of the current %%D item (folder name)
REM if /I      = if comparison, case-insensitive
REM exit /b    = exit the batch script with a code, do not close cmd

for /R "%~dp0Framework" %%F in (*.Trimming.TestApp.exe) do (
  for %%D in ("%%~dpF\.") do (
    if /I "%%~nxD"=="publish" (
      echo %%F
      echo(
      "%%F" || exit /b %ERRORLEVEL%
      echo(
    )
  )
)