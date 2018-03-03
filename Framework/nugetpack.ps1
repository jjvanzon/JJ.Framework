D:
$codeRootFolderPath="D:\JJ\Dev\1. Products\2. Code\1. Software System\X\9. JJ"
$releaseFolderPath="$($codeRootFolderPath)\Releases"

cd "$($codeRootFolderPath)\Framework\Text"
nuget pack -build JJ.Framework.Text.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"

cd "$($codeRootFolderPath)\Framework\PlatformCompatibility"
nuget pack -build JJ.Framework.PlatformCompatibility.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"

cd "$($codeRootFolderPath)\Framework\Common"
nuget pack -build JJ.Framework.Common.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"

cd "$($codeRootFolderPath)\Framework\Reflection"
nuget pack -build JJ.Framework.Reflection.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"

cd "$($codeRootFolderPath)\Framework\Exceptions"
nuget pack -build JJ.Framework.Exceptions.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"

cd "$($codeRootFolderPath)\Framework\Conversion"
nuget pack -build JJ.Framework.Conversion.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"

cd "$($codeRootFolderPath)\Framework\Testing"
nuget pack -build JJ.Framework.Testing.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"
