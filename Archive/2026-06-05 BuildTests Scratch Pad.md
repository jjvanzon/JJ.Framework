

```cs

    //internal          DotNetOptions BasicOpt           { get; }
    //internal          DotNetOptions Opt                { get; }

    // TODO: Add Message ItBuilt as MSBuild scripting in CsprojContent and assert it's in the output.


        AssertResult(result, DebugDllFilePath);

    private void AssertResult(DotNetResult result, string dllFilePath = "")
    {
        if (Has(dllFilePath))
        {
            AssertExists(dllFilePath);
        }
        AssertResultOk(result);
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, ProjectName + " -> " + dllFilePath);
    }


        //AssertResultOk(result);
        //AssertContains(result, "dotnet build");
        //AssertContains(result, "build succeeded");
        //AssertContains(result, ProjectName + " -> " + DebugDllFilePath);
```