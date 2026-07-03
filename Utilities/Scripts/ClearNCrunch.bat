@echo off

echo Clearing NCrunch caches (will only remove cache folders, not .ncrunchproject/.ncrunchsolution files)...

rem Remove per-user/global NCrunch cache under Local AppData.
rem This is the heavy cache and safe to remove; NCrunch will re-create it.
if exist "%LOCALAPPDATA%\NCrunch" (
  echo Deleting "%LOCALAPPDATA%\NCrunch"
  rd /s /q "%LOCALAPPDATA%\NCrunch"
)

rem Also look for NCrunch-generated files (e.g. nCrunchTemp_*.csproj.user) and delete them.
for /r %%F in ("nCrunchTemp_*.*" ".NCrunch*") do (
  echo Deleting "%%~fF"
  del "%%~fF"
)

echo Done.
