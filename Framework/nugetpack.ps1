D:
$codeRootFolderPath="D:\Source\JJs Software\JJ TFS"
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

cd "$($codeRootFolderPath)\Framework\IO"
nuget pack -build JJ.Framework.IO.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"

cd "$($codeRootFolderPath)\Framework\Collections"
nuget pack -build JJ.Framework.Collections.csproj -Prop Configuration=Release -OutputDirectory "$releaseFolderPath"
