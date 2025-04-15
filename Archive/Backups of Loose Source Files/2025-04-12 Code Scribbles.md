
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