
  <ItemGroup>
    <PackageReference Update="JJ.Framework.Common" Version="[0.0.0,1.0.0)" />
  </ItemGroup>

This package may clash with `JJ.Framework.Configuration`.
The assembly name and namespace of `ConfigurationSectionHandler` class have remained unchanged, so your configs won't break,

    <AssemblyName>JJ.Framework.Configuration</AssemblyName>
    <PackageId>JJ.Framework.Configuration.Legacy</PackageId>


//#pragma warning disable CS1584
//#pragma warning disable CS1581
//#pragma warning disable CS1580


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
