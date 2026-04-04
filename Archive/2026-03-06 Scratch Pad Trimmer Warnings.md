```cs
    //[Suppress("Trimmer", "IL2075", Justification = TypeLoaded)]

  //[Dyn(DynamicallyAccessedMemberTypes.PublicFields)]
    //[DynamicDependency(PublicFields, typeof(IsStatic_CoreTests))]
    //[DynamicDependency("_staticField", typeof(IsStatic_CoreTests))]
    //[DynamicDependency("_field", typeof(IsStatic_CoreTests))]


//#if DEBUG && !IsNCrunch
```

```xml
  <!-- MSBuild props => compiler directives -->

  <PropertyGroup Condition="'$(IsNCrunch)'=='True'">
    <DefineConstants>$(DefineConstants);IsNCrunch</DefineConstants>
  </PropertyGroup>
```