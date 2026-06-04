@echo off

echo Deletes repo-level "packages" directory and the user's .nuget folder.

REM %~dp0         = Folder of bat file
REM %USERPROFILE% = Windows variable pointing to user folder (like "C:\Users\janjo")

echo Deleting "%~dp0packages"
rmdir /s /q "%~dp0packages"

echo Deleting "%USERPROFILE%\.nuget"
rmdir /s /q "%USERPROFILE%\.nuget"

echo Done.
