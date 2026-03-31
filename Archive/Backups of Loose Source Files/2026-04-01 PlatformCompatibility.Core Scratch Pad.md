
```cs
    IsTrue(PublicConstructors.HasFlag(PublicParameterlessConstructor));

    public string? Condition { get; set; } // Apparently obsolete

    [TestMethod]
    public void Test_DynamicallyAccessedMemberTypes() => _testBase.Test_DynamicallyAccessedMemberTypes();

    public void Test_DynamicallyAccessedMemberTypes()
    {
        AreEqual(0,  (int)None);
        AreEqual(1,  (int)PublicParameterlessConstructor);
        AreEqual(3,  (int)PublicConstructors);
        AreEqual(8,  (int)PublicMethods);
        AreEqual(-1, (int)All);
        IsTrue(PublicConstructors.HasFlag(PublicParameterlessConstructor));
    }
```