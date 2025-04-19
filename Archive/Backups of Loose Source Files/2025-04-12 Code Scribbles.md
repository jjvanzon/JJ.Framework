
```cs
Assert.IsTrue(list.Any(x => x.Key == "Name1" && x.Value.Equals(3)));
Assert.IsTrue(list.Any(x => x.Key == "Name2" && x.Value.Equals(5)));
Assert.IsTrue(list.Any(x => x.Key == "Name3" && x.Value.Equals(6)));
```

```cs
// Redundant. Should use char variant.
[TestMethod]
public void CutLeft_NoMatch_Test() 
    => AreEqual("Lalalaa", () => "Lalalaa".CutLeft("laa"));
```

```cs
Assert.AreEqual(expected.Length, actual.Length);
for (int i = 0; i < expected.Length; i++)
{
    Assert.AreEqual(expected[i], actual[i]);
}
```


```cs
        IsNotNull(() => split1);
        IsNotNull(() => split2);
        AreEqual(1, () => split1.Length);
        AreEqual(1, () => split2.Length);
        IsNotNull(() => split1[0]);
        IsNotNull(() => split2[0]);
        AreEqual("a, b, c", () => split1[0]);
        AreEqual("a, b, c", () => split2[0]);
    
    [TestMethod]
    public void Split_StringSepAndOptions_EmptySepException()
    {
    }
```

```cs
    if (string.IsNullOrEmpty(input)) return input; // Is lenient about indices.
    
    if (startIndex < 0) throw new Exception("startIndex is less than 0.");
    if (endIndex   < 0) throw new Exception("endIndex is less than 0.");
    if (startIndex >= input.Length) throw new Exception("startIndex lies after the input string.");
    if (endIndex   >= input.Length) throw new Exception("endIndex lies after the input string.");
```

```
    `"Lalalaa".CutRight('a')` = `"Lalala"`  
```

```cs
    AreEqual("abcGHI", "abcDEF".Replace("def", "GHI", ignoreCase: true));
```


```xml
  <ItemGroup Condition="$(MSBuildProjectName.StartsWith('JJ.'))
                   And '$(MSBuildProjectName)' != 'JJ.Framework.Build' 
                   And '$(MSBuildProjectName)' != 'JJ.Framework.Versioning.Core'">
    <ProjectReference Include="$(SolutionDir)\Framework\JJ.Framework.Build\JJ.Framework.Build.csproj" />
  </ItemGroup>
```