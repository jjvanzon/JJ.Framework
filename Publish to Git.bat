prompt @
echo off
cls

chdir "D:\JJ\Dev\1. Products\2. Code\1. Software System\X"

rem /s: Removes all directories and files in the specified directory in addition to the directory itself.  Used to remove a directory tree.
rem /q: Quiet mode, do not ask if ok to remove a directory tree with /s

REM DELETE DOCS
rd /s /q "9. JJ Git\Architecture"

REM DELETE CODE FOLDERS
rd /s /q "9. JJ Git\Business"
rd /s /q "9. JJ Git\Data"
rd /s /q "9. JJ Git\Database"
rd /s /q "9. JJ Git\Demos"
rd /s /q "9. JJ Git\Framework"
rd /s /q "9. JJ Git\Presentation"

rem /q: Quiet mode, do not ask if ok to delete on global wildcard
rem /f: Force deleting of read-only files.

REM DELETE CODE FILES IN ROOT
del /q /f "9. JJ Git\*.sln"
del /q /f "9. JJ Git\*.txt"
del /q /f "9. JJ Git\*.md"

rem /s: Copies directories and subdirectories except empty ones.
rem /v: Verifies the size of each new file.
rem /r: Overwrites read-only files.
rem /q: Does not display file names while copying
rem Slash at the end of dest is needed, otherwise it asks if it is a directory or file.
rem Slash should not be put at the end of source, because then it gives an error message.

REM COPY DOCS
xcopy /s /v /r /q "D:\JJ\Dev\1. Products\1. Docs\2. Software Architecture" "9. JJ Git\Architecture\"

REM COPY CODE FOLDERS
xcopy /s /v /r /q "9. JJ\Demos" "9. JJ Git\Demos\"
xcopy /s /v /r /q "9. JJ\Framework" "9. JJ Git\Framework\"
mkdir "9. JJ Git\Business\"
xcopy /s /v /r /q "9. JJ\Business\SaveText" "9. JJ Git\Business\SaveText\"
mkdir "9. JJ Git\Data\"
xcopy /s /v /r /q "9. JJ\Data\SaveText" "9. JJ Git\Data\SaveText\"
xcopy /s /v /r /q "9. JJ\Data\SaveText.DefaultRepositories" "9. JJ Git\Data\SaveText.DefaultRepositories\"
xcopy /s /v /r /q "9. JJ\Data\SaveText.EntityFramework5" "9. JJ Git\Data\SaveText.EntityFramework5\"
xcopy /s /v /r /q "9. JJ\Data\SaveText.Memory" "9. JJ Git\Data\SaveText.Memory\"
xcopy /s /v /r /q "9. JJ\Data\SaveText.NHibernate" "9. JJ Git\Data\SaveText.NHibernate\"
xcopy /s /v /r /q "9. JJ\Data\SaveText.Xml" "9. JJ Git\Data\SaveText.Xml\"
xcopy /s /v /r /q "9. JJ\Data\SaveText.Xml.Linq" "9. JJ Git\Data\SaveText.Xml.Linq\"
mkdir "9. JJ Git\Database\"
xcopy /s /v /r /q "9. JJ\Database\SaveTextDB" "9. JJ Git\Database\SaveTextDB\"
mkdir "9. JJ Git\Presentation\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText" "9. JJ Git\Presentation\SaveText\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Android" "9. JJ Git\Presentation\SaveText.Android\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.AppService" "9. JJ Git\Presentation\SaveText.AppService\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.AppService.Client" "9. JJ Git\Presentation\SaveText.AppService.Client\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.AppService.Interface" "9. JJ Git\Presentation\SaveText.AppService.Interface\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.AppService.Tests" "9. JJ Git\Presentation\SaveText.AppService.Tests\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.AppService.Tests.SoapUI" "9. JJ Git\Presentation\SaveText.AppService.Tests.SoapUI\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Html" "9. JJ Git\Presentation\SaveText.Html\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Interface" "9. JJ Git\Presentation\SaveText.Interface\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Mvc" "9. JJ Git\Presentation\SaveText.Mvc\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Unity.DotNet.Offline" "9. JJ Git\Presentation\SaveText.Unity.DotNet.Offline\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Unity.DotNet.OfflineWithSync" "9. JJ Git\Presentation\SaveText.Unity.DotNet.OfflineWithSync\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Unity.DotNet.Online" "9. JJ Git\Presentation\SaveText.Unity.DotNet.Online\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Unity.DotNet.Online.WwwObject" "9. JJ Git\Presentation\SaveText.Unity.DotNet.Online.WwwObject\"
rem xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Unity.Offline" "9. JJ Git\Presentation\SaveText.Unity.Offline\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Unity.OfflineWithSync" "9. JJ Git\Presentation\SaveText.Unity.OfflineWithSync\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Unity.Online" "9. JJ Git\Presentation\SaveText.Unity.Online\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.Unity.Online.WwwObject" "9. JJ Git\Presentation\SaveText.Unity.Online.WwwObject\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.WinForms.Offline" "9. JJ Git\Presentation\SaveText.WinForms.Offline\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.WinForms.OfflineWithSync" "9. JJ Git\Presentation\SaveText.WinForms.OfflineWithSync\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.WinForms.Online" "9. JJ Git\Presentation\SaveText.WinForms.Online\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.WinForms.Online.CustomSoapClient" "9. JJ Git\Presentation\SaveText.WinForms.Online.CustomSoapClient\"
xcopy /s /v /r /q "9. JJ\Presentation\SaveText.WinForms.OnlineOfflineSwitched" "9. JJ Git\Presentation\SaveText.WinForms.OnlineOfflineSwitched\"

REM COPY CODE FILES IN ROOT
xcopy /v /r /q "9. JJ\JJ.Demos.sln" "9. JJ Git"
xcopy /v /r /q "9. JJ\JJ.Framework.sln" "9. JJ Git"
xcopy /v /r /q "9. JJ\SaveText.sln" "9. JJ Git"
xcopy /v /r /q "9. JJ\LICENSE.TXT" "9. JJ Git"
xcopy /v /r /q "9. JJ\README.MD" "9. JJ Git"
xcopy /v /r /q "9. JJ\THIRD PARTY LICENSE.TXT" "9. JJ Git"

REM MOVE PDF's
xcopy /v /r /q "9. JJ Git\Architecture\Parts\*.pdf" "9. JJ Git\Architecture"
rd /s /q "9. JJ Git\Architecture\Parts"

pause
prompt