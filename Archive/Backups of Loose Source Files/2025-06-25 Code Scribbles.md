
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
