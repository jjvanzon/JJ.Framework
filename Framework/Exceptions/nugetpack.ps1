$codeRootFolderPath="D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ"
$releaseFolderPath="$($codeRootFolderPath)\Releases"
D:
cd "$($codeRootFolderPath)\Framework\Exceptions"
nuget pack -build JJ.Framework.Exceptions.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"
