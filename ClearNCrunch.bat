@echo off

echo Clearing NCrunch caches (will only remove cache folders, not .ncrunchproject/.ncrunchsolution files)...

rem Also look for NCrunch-generated files (e.g. nCrunchTemp_*.csproj.user) and report them.
for /r %%F in ("nCrunchTemp_*.*" ".NCrunch*") do (
  echo Deleting "%%~fF"
  del "%%~fF"
)

rem ------------------------------------------------------------------
rem Remove per-user/global NCrunch cache under Local AppData.
rem This is the heavy cache and safe to remove; NCrunch will re-create it.
rem ------------------------------------------------------------------
if exist "%LOCALAPPDATA%\NCrunch" (
  echo Deleting "%LOCALAPPDATA%\NCrunch"
  rd /s /q "%LOCALAPPDATA%\NCrunch"
)

REM Surplus:

rem Some caches may be created in a hidden ".ncrunch" folder
REM if exist ".ncrunch" (
REM   echo Deleting ".ncrunch"
REM   rd /s /q ".ncrunch"
REM )

rem Some installations use a dot-folder in the user profile
REM if exist "%USERPROFILE%\\.ncrunch" (
REM   echo Deleting "%USERPROFILE%\\.ncrunch"
REM   rd /s /q "%USERPROFILE%\\.ncrunch"
REM )

echo Done.
