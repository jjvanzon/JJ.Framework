prompt @

cd /D "%~dp0"

rem /S = Copies directories and subdirectories except empty ones.
rem /R = Overwrites read-only files.
rem /K = Copies attributes. Normal Xcopy will reset read-only attributes.
rem /Y = Suppresses prompting to confirm you want to overwrite an existing destination file.
xcopy "..\..\ReturnActions.Mvc\Content\Site.css" "..\Content\*" /S /R /K /Y
xcopy "..\..\ReturnActions.Mvc\Views\Shared" "..\Views\Shared\*" /S /R /K /Y
xcopy "..\..\ReturnActions.Mvc\Views\_ViewStart.cshtml" "..\Views\*" /S /R /K /Y

pause
