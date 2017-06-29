prompt @
rem echo off
cls


rem /s: Removes all directories and files in the specified directory in addition to the directory itself.  Used to remove a directory tree.
rem /q: Quiet mode, do not ask if ok to remove a directory tree with /s

REM DELETE DOCS
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Documentation"
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Architecture"

REM DELETE CODE FOLDERS
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Business"
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Data"
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Database"
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Demos"
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Framework"
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Presentation"

rem /q: Quiet mode, do not ask if ok to delete on global wildcard
rem /f: Force deleting of read-only files.

REM DELETE CODE FILES IN ROOT
del /q /f "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\*.sln"
del /q /f "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\*.vssscc"
del /q /f "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\*.txt"

rem /s: Copies directories and subdirectories except empty ones.
rem /v: Verifies the size of each new file.
rem /r: Overwrites read-only files.
rem /q: Does not display file names while copying
rem Slash at the end of dest is needed, otherwise it asks if it is a directory or file.
rem Slash should not be put at the end of source, because then it gives an error message.

REM COPY DOCS
xcopy /s /v /r /q "D:\JJ\Dev\1. Products\1. Docs\2. Software Architecture" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Architecture\"

REM COPY CODE FOLDERS
xcopy /s /v /r /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ\Demos" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Demos\"
xcopy /s /v /r /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ\Framework" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Framework\"

REM COPY CODE FILES IN ROOT
xcopy /v /r /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ\JJ.Demos.sln" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git"
xcopy /v /r /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ\JJ.Framework.sln" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git"
xcopy /v /r /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ\LICENSE.TXT" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git"
xcopy /v /r /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ\README.MD" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git"
xcopy /v /r /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ\THIRD PARTY LICENSE.TXT" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git"

REM MOVE PDF's
xcopy /v /r /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Architecture\Parts\*.pdf" "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Architecture"
rd /s /q "D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ Git\Architecture\Parts"

rem TODO: SaveText code

pause
prompt