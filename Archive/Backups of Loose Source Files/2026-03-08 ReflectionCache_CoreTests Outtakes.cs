
   
    [TestMethod]
    public void StaticReflectionCache_TryGetProperty_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            PropertyInfo field = StaticReflectionCache.TryGetProperty(typeof(TestClass), "TestProperty");
            IsNotNull(() => field);
            AreEqual("TestProperty", () => field.Name);
            AreEqual(typeof(int), () => field.PropertyType);

            PropertyInfo field2 = StaticReflectionCache.TryGetProperty(typeof(TestClass), "TestProperty2");
            IsNotNull(() => field2);
            AreEqual("TestProperty2", () => field2.Name);
            AreEqual(typeof(string), () => field2.PropertyType);
        }
    }

    
    [TestMethod]
    public void StaticReflectionCache_GetProperties()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            IList<PropertyInfo> properties = StaticReflectionCache.GetProperties(typeof(TestClass), BINDING_FLAGS_ALL);
            AssertProperties(properties);
        }
    }
    
    [TestMethod]
    public void StaticReflectionCache_GetFields()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<FieldInfo[]>[] synonyms =
        [
            () => reflectionCache       .GetFields(typeof(TestClass)),
            () => reflectionCacheLegacy .GetFields(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetFields(typeof(TestClass)),
            () => StaticReflectionCache .GetFields(typeof(TestClass), BINDING_FLAGS_ALL)
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < REPEATS; i++)
            {
                FieldInfo[] fields = func();
                AssertFields(fields);
            }
        }
    }

    
    [TestMethod]
    public void ReflectionCache_GetMethod_Test()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<MethodInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetMethod(typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy2.TryGetMethod(typeof(TestClass), "TestMethod"),
            () => StaticReflectionCache .TryGetMethod(typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy .GetMethod   (typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy2.GetMethod   (typeof(TestClass), "TestMethod"),
            () => StaticReflectionCache .GetMethod   (typeof(TestClass), "TestMethod"),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < REPEATS; i++)
            {
                MethodInfo method = func();
                AssertMethod(method);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetMethod_Test_WithArgypes()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        // NOTE:It's pretty strict that you must supply parameter types.
        Func<MethodInfo>[] synonyms2 =
        [
            () => reflectionCacheLegacy .TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => StaticReflectionCache .TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy .GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => StaticReflectionCache .GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
        ];

        foreach (var func in synonyms2)
        {
            for (int i = 0; i < REPEATS; i++)
            {
                MethodInfo method2 = func();
                AssertMethod2(method2);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetIndexer_Test()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<PropertyInfo>[] synonyms1 =
        [
            () => reflectionCacheLegacy .TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy2.TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
            () => StaticReflectionCache .TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy .GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy2.GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
            () => StaticReflectionCache .GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
        ];

        foreach (var func in synonyms1)
        {
            for (int i = 0; i < REPEATS; i++)
            {
                PropertyInfo indexer = func();
                AssertIndexer1(indexer);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetIndexer_Test2()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<PropertyInfo>[] synonyms2 =
        [
            () => reflectionCacheLegacy .TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => StaticReflectionCache .TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy .GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => StaticReflectionCache .GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
        ];

        foreach (var func in synonyms2)
        {
            for (int i = 0; i < REPEATS; i++)
            {
                PropertyInfo indexer2 = func();
                AssertIndexer2(indexer2);
            }
        }
    }
