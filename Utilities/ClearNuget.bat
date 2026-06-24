@echo off

echo Deletes repo-level "packages" directory and the user's .nuget folder.

REM %~dp0         = Folder of bat file
REM .             = current dir
REM %USERPROFILE% = Windows variable pointing to user folder (like "C:\Users\janjo")

REM echo Deleting "packages"
REM rmdir /s /q "%~dp0packages"

echo Deleting ".\packages"
rmdir /s /q ".\packages"

echo Deleting "%USERPROFILE%\.nuget"
rmdir /s /q "%USERPROFILE%\.nuget"

echo Done.
