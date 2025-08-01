
  <ItemGroup>
    <PackageReference Update="JJ.Framework.Common" Version="[0.0.0,1.0.0)" />
  </ItemGroup>

This package may clash with `JJ.Framework.Configuration`.
The assembly name and namespace of `ConfigurationSectionHandler` class have remained unchanged, so your configs won't break,

```xml
    <AssemblyName>JJ.Framework.Configuration</AssemblyName>
    <PackageId>JJ.Framework.Configuration.Legacy</PackageId>
```

```cs
#pragma warning disable CS1584
#pragma warning disable CS1581
#pragma warning disable CS1580
```

```xml
  <PropertyGroup Condition="$(TargetFramework)!='net461'">

          Condition="'$(PublishDir)'!='' And '$(Configuration)'=='Release'">

             Properties="PublishProfile=Properties\PublishProfiles\FolderProfile.pubxml;NoBuild=true" />
             Properties="PublishProfile=Properties\PublishProfiles\FolderProfile.pubxml" />

    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Helpers\CustomMemberInfo.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Helpers\MemberTypes_TestHelper.cs" />

    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\CultureInfo_PlatformSafe_Obsolete_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\Encoding_PlatformSafe_Accessor.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\Encoding_PlatformSafe_Obsolete_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\PlatformExtensions_Accessor.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\PlatformExtensions_Obsolete_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\PlatformHelper_Accessor.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\PlatformHelper_Obsolete_Tests.cs" />

    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\CultureInfo_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Encoding_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\MemberTypes_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\PropertyInfo_GetValue_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Type_GetInterface_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\XDocument_XElement_PlatformSafe_Tests.cs" />


    <TrimmerRootDescriptor>notrim.xml</TrimmerRootDescriptor>
```

```cs

namespace JJ.Framework.Tests.Trimming.Core;

public class Program
{
    // ReSharper disable once UnusedParameter.Global
    public static void Main(string[] args)
    {
        WriteLine("Hello world!");
        ReadKey();
    }
}

// TODO: Move to MSTestless.cs


Assembly assembly = Assembly.GetExecutingAssembly();

Type[] types = assembly.GetExportedTypes()
                       //.Where(x => x.Name.EndsWith("Tests"))
                       .Where(x => x.GetCustomAttribute<TestClassAttribute>() != null)
                       .ToArray();

foreach (Type type in types)
{
    var methods = type.GetMethods(Public | Instance)
                      .Where(x => x.GetCustomAttribute<TestMethodAttribute>() != null)
                      .ToArray();

    foreach (MethodInfo method in methods)
    {
        try
        {
            object? instance = Activator.CreateInstance(type);
            method.Invoke(instance, null);
            WriteLine($"Test {type.Name}.{method.Name} passed.");
        }
        catch (Exception ex)
        {
            WriteLine($"Test {type.Name}.{method.Name} failed: {ex.Message}");
        }
    }
}

            #pragma warning disable IL2026 // Requires unreferenced code
            #pragma warning restore IL2026


                #pragma warning disable IL2072 // Dyn(PublicMethods)
                #pragma warning restore IL2072 // Dyn(PublicMethods)
    
    [UnconditionalSuppressMessage("Trimmer", "IL2026", Justification = "stackFrame.GetMethod() heuristic inspection; Dyn(PublicMethods) omitted.")]
    [UnconditionalSuppressMessage("Trimmer", "IL2072", Justification = "Dyn(PublicMethods) hard to enforce for specific types 
    here.")]

RunTests<Obsolete.CultureInfo_PlatformSafe_Obsolete_Tests >().ForEach(WriteLine); WriteLine();
RunTests<Obsolete.Encoding_PlatformSafe_Obsolete_Tests    >().ForEach(WriteLine); WriteLine();
RunTests<Obsolete.PlatformExtensions_Obsolete_Tests       >().ForEach(WriteLine); WriteLine();
RunTests<Obsolete.PlatformHelper_Obsolete_Tests           >().ForEach(WriteLine); WriteLine();

=> NotNull(testClasses).ForEach(x => RunTests(x, messages));

    private static string FormatMessages(IList<string> messages)
    {
        var sb = new StringBuilder();

        foreach (string message in messages)
        {
            if (message != null)
            {
                sb.Append($"{message}, ");
            }
            else
            {
                sb.Append("<null>, ");
            }
        }

        string formattedMessages = sb.ToString().TrimEnd(", ");

        return formattedMessages;
    }

    } = EmptyMessages;
    private static string[] EmptyMessages = [ ];

namespace JJ.Framework.Business.Core;

public interface IResult
{
    bool Successful { get; set; }

    /// <summary> not nullable, auto-instantiated </summary>
    
    #if NETFRAMEWORK || NETSTANDARD2_0
    
    IList<string> Messages { get; set; }
    
    #else
    
    IList<string> Messages { get => [ ]; set { } } 
    
    #endif
}

    //private static readonly IList<string> DefaultMessages = Empty<string>();

```

### Syntax sugar for TestRunner

```cs
var result = RunTests<CultureInfo_PlatformSafe_Tests,
                      Encoding_PlatformSafe_Tests,
                      MemberTypes_PlatformSafe_Tests,
                      PropertyInfo_GetValue_PlatformSafe_Tests,
                      Type_GetInterface_PlatformSafe_Tests,
                      XDocument_XElement_PlatformSafe_Tests>();

```


```cs
    [UnconditionalSuppressMessage("Trimming", "IL2075", Justification = "No reflection")]
    public const DynamicallyAccessedMemberTypes DefaultConstructor = PublicParameterlessConstructor;
```

### MSBuild Targeting Options

```xml
    <TargetFramework>net9.0</TargetFramework>
    <TargetFrameworks>net9.0</TargetFrameworks>

    <Combo>$(TargetFramework)|$(RuntimeIdentifier)</Combo>
  <PropertyGroup Condition="'$(Combo)'=='net9.0|win-x64'">
  <PropertyGroup Condition="'$(Combo)'=='net8.0|win-x64'">

  <PropertyGroup Condition="'$(Combo)'=='net9.0|linux-arm64'">
    <SelfContained>True</SelfContained>
    <PublishTrimmed>True</PublishTrimmed>
    <PublishAot>True</PublishAot>
    <!--<PublishSingleFile>True</PublishSingleFile>-->
    <PublishReadyToRun>True</PublishReadyToRun>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Combo)'=='net8.0|linux-arm64'">
    <SelfContained>True</SelfContained>
    <PublishTrimmed>True</PublishTrimmed>
    <PublishAot>True</PublishAot>
    <!--<PublishSingleFile>True</PublishSingleFile>-->
    <PublishReadyToRun>True</PublishReadyToRun>
  </PropertyGroup>


    <TargetFramework>net7.0</TargetFramework>

```

### Dyn(Interfaces) on PropertyInfo and Such (does not work)

```cs
        
        [return: Dyn(Interfaces)]
        static Type DynInterfaces([Dyn(Interfaces)] Type type) => type;

        [Suppress("Trimmer", "IL2026", Justification = ExpressionsWithArrays)]

        #if !NET9_0_OR_GREATER
        [Suppress("Trimmer", "IL3050", Justification = ExpressionsWithArrays)]
        #endif

        [Suppress("Trimmer", "IL2026", Justification = ExpressionsWithArrays)]

```

### MSBuild Targeting

```xml
  <PropertyGroup Condition="'$(TargetFramework)'=='net8.0'">
    <SelfContained>True</SelfContained>
    <PublishTrimmed>True</PublishTrimmed>
    <PublishAot>True</PublishAot>
    <!--<PublishSingleFile>True</PublishSingleFile>-->
    <PublishReadyToRun>True</PublishReadyToRun>
  </PropertyGroup>
```

### Trimmability Annotations

```cs
    // TODO: Rename to Assembly or something?
  //public const string Types = GetTypes;
```

### NuGet Restore Alternative

```xml
  <!-- Experimental NuGet restore alternative, hopefully faster. -->
  <!-- No speed gain. Gave error while publishing a console app. -->
  <PropertyGroup>
    <RestoreUseStaticGraphEvaluation>true</RestoreUseStaticGraphEvaluation>
  </PropertyGroup>
```

### Directory.Build.props variablization

```xml
  <PropertyGroup Condition="$(MSBuildProjectName.Contains('Core'))">
  <PropertyGroup Condition="$(MSBuildProjectName.Contains('Core')) And !$(MSBuildProjectName.Contains('Tests'))">
  <PropertyGroup Condition="$(IsCore) And !$(MSBuildProjectName.Contains('Tests'))">

    <IsNet8>$('$(TargetFramework)'=='net8.0')</IsNet8>

    <IsOuterBuild>$(TargetFramework.Equals(''))</IsOuterBuild>
    <IsOuterBuild>$([System.String]::IsNullOrEmpty('$(TargetFramework)')) == false</IsOuterBuild>
    <IsOuterBuild>$([System.String]::IsNullOrEmpty('$(TargetFramework)') == false)</IsOuterBuild>
    <IsOuterBuild>$(![System.String]::IsNullOrEmpty('$(TargetFramework)'))</IsOuterBuild>
    <IsOuterBuild>$(!([System.String]::IsNullOrEmpty('$(TargetFramework)')))</IsOuterBuild>
    <IsInnerBuild>$([System.String]::IsNullOrEmpty('$(TargetFramework)'))</IsInnerBuild>
```

### TestRunner

```cs
          result.Messages.Add($"{method.Name} starting.");
```

### Trim Test Batch File

```powershell
Get-ChildItem -Recurse | foreach {attrib.exe -s -h $_.FullName}

/c for /R "%Build.SourcesDirectory%\publish" %F in (*.Trimming.TestApp.exe) do @echo Running %F & "%F" || exit /b %ERRORLEVEL%

Build.Repository.LocalPath

/c for /R "%Build.Repository.LocalPath%" %F in (*.Trimming.TestApp.exe) do "%F" || exit /b %ERRORLEVEL%

/c for /R "%Build.Repository.LocalPath%\Framework" %F in (*.Trimming.TestApp.exe) do "%F" || exit /b %ERRORLEVEL%

for /R "%~dp0Framework" %%F in (*.Trimming.TestApp.exe) do "%%F" || exit /b %%ERRORLEVEL%%
```

### RunTrimTests.bat

```bat
REM 1st attempt (doesn't insist on "publish" folder)
REM ------------------------------------------------
for /R "%~dp0Framework" %%FILE in (*.Trimming.TestApp.exe) do "%%FILE" || exit /b %%ERRORLEVEL%%

REM 2nd attempt (* is AI BS, doesn't work)
REM --------------------------------------
REM /F = Run items as commands
REM /B = Dir bare output = file paths
REM /S = Recursive
REM /b = Exit bat, but prevent quit cmd
REM %%F = File path
REM %~dp0 = Folder path of bat file
REM "delims=" = Don't split tokens, keep whole lines

for /F "delims=" %%F in ('dir /B /S "%~dp0Framework\*\publish\*.Trimming.TestApp.exe"') do "%%F" || exit /b %%ERRORLEVEL%%

REM 3rd attempt
REM -----------
```

### Azure Pipelines Command Line Task Swallows Error

```bat
echo call "$(Build.SourcesDirectory)\RunTrimTests.bat"
echo exit %ERRORLEVEL%

call "$(Build.SourcesDirectory)\RunTrimTests.bat"
exit %ERRORLEVEL%
```

```bat
echo call "$(Build.SourcesDirectory)\RunTrimTests.bat"
echo exit %%ERRORLEVEL%%

call "$(Build.SourcesDirectory)\RunTrimTests.bat"
exit %%ERRORLEVEL%%
```


```bat
for /R "%~dp0Framework" %%F in (*.Trimming.TestApp.exe) do (
  for %%D in ("%%~dpF\.") do (
    if /I "%%~nxD"=="publish" (
      echo %%F
      echo(
      "%%F" || (call echo Error code %%ERRORLEVEL%% & exit /b %%ERRORLEVEL%%)
      echo(
    )
  )
)
```

```bat
      REM "%%F" || (echo Error code %ERRORLEVEL% & goto Failed)
```

```cs
// Temporary test if CI fails upon error code
// TODO: Remove the following code line
Exit(1);
```

### RunTrimTests.bat Outtakes

```bat
    rem if /I "%%~nxD"=="publish" (
      REM echo(
      REM echo(

echo Error code %ERRORLEVEL%
echo Error code %ERRORLEVEL%
```

### Test Code Remnants

```cs
//file enum CustomerType
//{
//    Undefined,
//    Subscriber,
//    Customer
//}
```

### Trimming Annotations

Linked won't use these:

```cs
#pragma warning disable IL2026 // RequiresUnreferencedCode (for ExpressionsWithArrays)

#pragma warning disable IL2026 // Requires unreferenced code: Trim warning only applies to Expressions with arrays.
#pragma warning restore IL2026 
                #pragma warning disable IL2026 // Requires unreferenced code: Trim warning only applies to Expressions with arrays.
                #pragma warning restore IL2026 
                #pragma warning disable IL2026 // Requires unreferenced code: Trim warning only applies to Expressions with arrays.
                #pragma warning restore IL2026 
```