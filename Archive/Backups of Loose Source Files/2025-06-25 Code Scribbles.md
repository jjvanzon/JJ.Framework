
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
//#pragma warning disable CS1584
//#pragma warning disable CS1581
//#pragma warning disable CS1580
```

```xml
  <!--<PropertyGroup Condition="$(TargetFramework)!='net461'">-->

          <!--Condition="'$(PublishDir)'!='' And '$(Configuration)'=='Release'">-->

             <!--Properties="PublishProfile=Properties\PublishProfiles\FolderProfile.pubxml;NoBuild=true" />-->
             <!--Properties="PublishProfile=Properties\PublishProfiles\FolderProfile.pubxml" />-->

    <!--<Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Helpers\CustomMemberInfo.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Helpers\MemberTypes_TestHelper.cs" />-->

    <!--<Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\CultureInfo_PlatformSafe_Obsolete_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\Encoding_PlatformSafe_Accessor.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\Encoding_PlatformSafe_Obsolete_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\PlatformExtensions_Accessor.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\PlatformExtensions_Obsolete_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\PlatformHelper_Accessor.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Obsolete\PlatformHelper_Obsolete_Tests.cs" />-->

    <!--<Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\CultureInfo_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Encoding_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\MemberTypes_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\PropertyInfo_GetValue_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\Type_GetInterface_PlatformSafe_Tests.cs" />
    <Compile Include="..\JJ.Framework.PlatformCompatibility.Tests\XDocument_XElement_PlatformSafe_Tests.cs" />-->


    <!--<TrimmerRootDescriptor>notrim.xml</TrimmerRootDescriptor>-->
```

```cs

//namespace JJ.Framework.Tests.Trimming.Core;

//public class Program
//{
//    // ReSharper disable once UnusedParameter.Global
//    public static void Main(string[] args)
//    {
//        WriteLine("Hello world!");
//        ReadKey();
//    }
//}

// TODO: Move to MSTestless.cs


// Assembly assembly = Assembly.GetExecutingAssembly();

//Type[] types = assembly.GetExportedTypes()
//                       //.Where(x => x.Name.EndsWith("Tests"))
//                       .Where(x => x.GetCustomAttribute<TestClassAttribute>() != null)
//                       .ToArray();

//foreach (Type type in types)
//{
//    var methods = type.GetMethods(Public | Instance)
//                      .Where(x => x.GetCustomAttribute<TestMethodAttribute>() != null)
//                      .ToArray();

//    foreach (MethodInfo method in methods)
//    {
//        try
//        {
//            object? instance = Activator.CreateInstance(type);
//            method.Invoke(instance, null);
//            WriteLine($"Test {type.Name}.{method.Name} passed.");
//        }
//        catch (Exception ex)
//        {
//            WriteLine($"Test {type.Name}.{method.Name} failed: {ex.Message}");
//        }
//    }
//}

            #pragma warning disable IL2026 // Requires unreferenced code
            #pragma warning restore IL2026


                #pragma warning disable IL2072 // Dyn(PublicMethods)
                #pragma warning restore IL2072 // Dyn(PublicMethods)
    
    [UnconditionalSuppressMessage("Trimmer", "IL2026", Justification = "stackFrame.GetMethod() heuristic inspection; Dyn(PublicMethods) omitted.")]
    [UnconditionalSuppressMessage("Trimmer", "IL2072", Justification = "Dyn(PublicMethods) hard to enforce for specific types 
    here.")]

//RunTests<Obsolete.CultureInfo_PlatformSafe_Obsolete_Tests >().ForEach(WriteLine); WriteLine();
//RunTests<Obsolete.Encoding_PlatformSafe_Obsolete_Tests    >().ForEach(WriteLine); WriteLine();
//RunTests<Obsolete.PlatformExtensions_Obsolete_Tests       >().ForEach(WriteLine); WriteLine();
//RunTests<Obsolete.PlatformHelper_Obsolete_Tests           >().ForEach(WriteLine); WriteLine();

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


