
### Packaging


  <ItemGroup>
    <PackageReference Update="JJ.Framework.Common" Version="[0.0.0,1.0.0)" />
  </ItemGroup>

### JJ.Framework.Configuration.Legacy

This package may clash with `JJ.Framework.Configuration`.
The assembly name and namespace of `ConfigurationSectionHandler` class have remained unchanged, so your configs won't break,

    <AssemblyName>JJ.Framework.Configuration</AssemblyName>
    <PackageId>JJ.Framework.Configuration.Legacy</PackageId>
