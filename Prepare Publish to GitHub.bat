prompt @
echo off
cls

chdir "D:\Source\JJs Software"

rem /s: Removes all directories and files in the specified directory in addition to the directory itself.  Used to remove a directory tree.
rem /q: Quiet mode, do not ask if ok to remove a directory tree with /s

echo DELETE CODE FOLDERS
rd /s /q "JJ GitHub\Business"
rd /s /q "JJ GitHub\Data"
rd /s /q "JJ GitHub\Database"
rd /s /q "JJ GitHub\Demos"
rd /s /q "JJ GitHub\Framework"
rd /s /q "JJ GitHub\Presentation"

rem /q: Quiet mode, do not ask if ok to delete on global wildcard
rem /f: Force deleting of read-only files.

echo DELETE CODE FILES IN ROOT
del /q /f "JJ GitHub\*.sln"
del /q /f "JJ GitHub\*.txt"
del /q /f "JJ GitHub\*.md"
del /q /f "JJ GitHub\*.png"

rem /s: Copies directories and subdirectories except empty ones.
rem /v: Verifies the size of each new file.
rem /r: Overwrites read-only files.
rem /q: Does not display file names while copying
rem Slash at the end of dest is needed, otherwise it asks if it is a directory or file.
rem Slash should not be put at the end of source, because then it gives an error message.

echo COPY CODE FOLDERS
xcopy /s /v /r /q "JJ TFS\Demos" "JJ GitHub\Demos\"
xcopy /s /v /r /q "JJ TFS\Framework" "JJ GitHub\Framework\"
mkdir "JJ GitHub\Business\"
xcopy /s /v /r /q "JJ TFS\Business\Canonical" "JJ GitHub\Business\Canonical\"
xcopy /s /v /r /q "JJ TFS\Business\SaveText" "JJ GitHub\Business\SaveText\"
mkdir "JJ GitHub\Data\"
xcopy /s /v /r /q "JJ TFS\Data\Canonical" "JJ GitHub\Data\Canonical\"
xcopy /s /v /r /q "JJ TFS\Data\SaveText" "JJ GitHub\Data\SaveText\"
xcopy /s /v /r /q "JJ TFS\Data\SaveText.DefaultRepositories" "JJ GitHub\Data\SaveText.DefaultRepositories\"
xcopy /s /v /r /q "JJ TFS\Data\SaveText.EntityFramework" "JJ GitHub\Data\SaveText.EntityFramework\"
xcopy /s /v /r /q "JJ TFS\Data\SaveText.Memory" "JJ GitHub\Data\SaveText.Memory\"
xcopy /s /v /r /q "JJ TFS\Data\SaveText.NHibernate" "JJ GitHub\Data\SaveText.NHibernate\"
xcopy /s /v /r /q "JJ TFS\Data\SaveText.Xml" "JJ GitHub\Data\SaveText.Xml\"
xcopy /s /v /r /q "JJ TFS\Data\SaveText.Xml.Linq" "JJ GitHub\Data\SaveText.Xml.Linq\"
mkdir "JJ GitHub\Database\"
xcopy /s /v /r /q "JJ TFS\Database\SaveTextDB" "JJ GitHub\Database\SaveTextDB\"
mkdir "JJ GitHub\Presentation\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText" "JJ GitHub\Presentation\SaveText\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Android" "JJ GitHub\Presentation\SaveText.Android\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.AppService" "JJ GitHub\Presentation\SaveText.AppService\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.AppService.Client" "JJ GitHub\Presentation\SaveText.AppService.Client\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.AppService.Interface" "JJ GitHub\Presentation\SaveText.AppService.Interface\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.AppService.Tests" "JJ GitHub\Presentation\SaveText.AppService.Tests\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.AppService.Tests.SoapUI" "JJ GitHub\Presentation\SaveText.AppService.Tests.SoapUI\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Html" "JJ GitHub\Presentation\SaveText.Html\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Interface" "JJ GitHub\Presentation\SaveText.Interface\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Mvc" "JJ GitHub\Presentation\SaveText.Mvc\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Unity.DotNet.Offline" "JJ GitHub\Presentation\SaveText.Unity.DotNet.Offline\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Unity.DotNet.OfflineWithSync" "JJ GitHub\Presentation\SaveText.Unity.DotNet.OfflineWithSync\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Unity.DotNet.Online" "JJ GitHub\Presentation\SaveText.Unity.DotNet.Online\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Unity.DotNet.Online.WwwObject" "JJ GitHub\Presentation\SaveText.Unity.DotNet.Online.WwwObject\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Unity.Offline" "JJ GitHub\Presentation\SaveText.Unity.Offline\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Unity.OfflineWithSync" "JJ GitHub\Presentation\SaveText.Unity.OfflineWithSync\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Unity.Online" "JJ GitHub\Presentation\SaveText.Unity.Online\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.Unity.Online.WwwObject" "JJ GitHub\Presentation\SaveText.Unity.Online.WwwObject\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.WinForms.Offline" "JJ GitHub\Presentation\SaveText.WinForms.Offline\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.WinForms.OfflineWithSync" "JJ GitHub\Presentation\SaveText.WinForms.OfflineWithSync\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.WinForms.Online" "JJ GitHub\Presentation\SaveText.WinForms.Online\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.WinForms.Online.CustomSoapClient" "JJ GitHub\Presentation\SaveText.WinForms.Online.CustomSoapClient\"
xcopy /s /v /r /q "JJ TFS\Presentation\SaveText.WinForms.OnlineOfflineSwitched" "JJ GitHub\Presentation\SaveText.WinForms.OnlineOfflineSwitched\"

echo COPY CODE FILES IN ROOT
xcopy /v /r /q "JJ TFS\JJ.Demos.sln" "JJ GitHub"
xcopy /v /r /q "JJ TFS\JJ.Framework.sln" "JJ GitHub"
xcopy /v /r /q "JJ TFS\JJ.SaveText.sln" "JJ GitHub"
xcopy /v /r /q "JJ TFS\LICENSE.TXT" "JJ GitHub"
xcopy /v /r /q "JJ TFS\README.MD" "JJ GitHub"
xcopy /v /r /q "JJ TFS\THIRD PARTY LICENSE.TXT" "JJ GitHub"
xcopy /v /r /q "JJ TFS\*.png" "JJ GitHub"

echo WARNING: CANONICAL DATA / BUSINESS IS PUBLISHED.
echo CONSIDER IF IT CONTAINS DATA MODELING YOU DO NOT WANT TO OPEN SOURCE.

pause
prompt