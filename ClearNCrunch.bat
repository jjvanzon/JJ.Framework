@echo off

echo Clearing NCrunch caches (will only remove cache folders, not .ncrunchproject/.ncrunchsolution files)...

rem ------------------------------------------------------------------
rem Remove solution-level NCrunch cache directories in the repo root.
rem These are typically folders created by NCrunch (often start with underscore
rem or ".ncrunch"). We only target directories so "*.ncrunchproject" and
rem "*.ncrunchsolution" files are not affected.
rem ------------------------------------------------------------------
for /d %%D in ("*_NCrunch*" "_ncrunch*" "*.ncrunch*" "ncrunch_*" "_nCrunch*") do (
  if exist "%%~fD" (
    echo Deleting "%%~fD"
    echo "COLD RUN. NOTHING DELETED FOR NOW. VERIFY VALIDITY FIRST."
    REM rd /s /q "%%~fD"
  )
)

rem ------------------------------------------------------------------
rem Remove per-user/global NCrunch cache under Local AppData.
rem This is the heavy cache and safe to remove; NCrunch will re-create it.
rem ------------------------------------------------------------------
echo Deleting "%LOCALAPPDATA%\NCrunch"
rd /s /q "%LOCALAPPDATA%\NCrunch"

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
