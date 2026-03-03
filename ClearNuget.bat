@echo off

echo CLEAR NUGET
echo -----------
echo Deletes repo-level "packages" directory 
echo and the user's .nuget folder.

echo(

REM %~dp0         = Folder of bat file
REM %USERPROFILE% = Windows variable pointing to user folder (like "C:\Users\janjo")

echo Deleting "%~dp0packages"
rmdir /s /q "%~dp0packages"

echo Deleting "%USERPROFILE%\.nuget"
rmdir /s /q "%USERPROFILE%\.nuget"

echo Done.
