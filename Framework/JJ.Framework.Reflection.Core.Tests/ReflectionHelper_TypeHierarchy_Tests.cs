namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionHelper_TypeHierarchy_Tests
{
    // Assemblies
    
    [TestMethod]
    public void GetAssemblyNameTest()
    {
        AreEqual("JJ.Framework.Reflection.Core", () => GetAssemblyName<ReflectionHelperCore>());
    }

    // Fields
    
    private string _field = "value";
    
    [TestMethod]
    public void GetFieldOrExceptionTest()
    {
        var synonyms = new Func<string, FieldInfo>[]
        {
            fieldName => GetType().GetFieldOrException(fieldName),
            fieldName => GetFieldOrException(GetType(), fieldName)
        };

        foreach (var synonym in synonyms)
        {
            FieldInfo field = synonym("_field");

            IsNotNull(() => field);
            AreEqual("_field", () => field.Name);
            AreEqual("value", () => field.GetValue(this));
            AreEqual(typeof(string), () => field.FieldType);

            ThrowsException(
                () => synonym("❌"),
                $"Field '❌' not found on type '{GetType().FullName}'.");
        }
    }
    
    // Types

    [TestMethod]
    public void GetTypesInHierarchyTest()
    {
        Type type = typeof(Exception);
        
        var synonyms = new []
        {
            () => GetTypesInHierarchy(type),
            () => GetTypesInHierarchy<Exception>(),
            () => type.GetTypesInHierarchy(),
            () => { var types = new HashSet<Type>(); AddTypesInHierarchy(type, types);      return types; },
            () => { var types = new HashSet<Type>(); AddTypesInHierarchy<Exception>(types); return types; },
            () => { var types = new HashSet<Type>(); type.AddTypesInHierarchy(types);       return types; }
        };
        
        foreach (var synonym in synonyms)
        {
            var types = synonym();
            IsTrue(() => types.Contains(type));
            IsTrue(() => types.Contains(typeof(object)));                // Base class of all classes
            IsTrue(() => types.Contains(typeof(ISerializable)));         // Interface of Exception
            IsFalse(() => types.Contains(typeof(ReflectionHelperCore))); // ReflectionHelperCore not part of Exception's hierarchy.
        }
    }

    [TestMethod]
    public void HasTypeInHierarchyTest()
    {
        Type type = typeof(Exception);
        Type secondType = typeof(ISerializable);

        var trueSynonyms = new[]
        {
            () => HasTypeInHierarchy(type, secondType),
            () => HasTypeInHierarchy<Exception>(secondType),
            () => HasTypeInHierarchy<Exception, ISerializable>(),
            () => type.HasTypeInHierarchy(secondType),
            () => type.HasTypeInHierarchy<ISerializable>()
        };
        
        foreach (var trueSynonym in trueSynonyms)
        {
            IsTrue(trueSynonym());
        }
        
        Type wrongType = typeof(ReflectionHelperCore); // Not part of Exception's hierarchy.
        
        var falseSynonyms = new[]
        { 
            () => HasTypeInHierarchy(type, wrongType),
            () => HasTypeInHierarchy<Exception>(wrongType),
            () => HasTypeInHierarchy<Exception, ReflectionHelperCore>(),
            () => type.HasTypeInHierarchy(wrongType),
            () => type.HasTypeInHierarchy<ReflectionHelperCore>()
        };
        
        foreach (var falseSynonym in falseSynonyms)
        {
            IsFalse(falseSynonym());
        }
    }

    // Classes

    [TestMethod]
    public void GetClassesInHierarchyTest_New()
    {
        Type type = typeof(Exception);
        
        var synonyms = new[]
        {
            () => GetClassesInHierarchy(type),
            () => GetClassesInHierarchy<Exception>(),
            () => type.GetClassesInHierarchy(),
            () => { var types = new HashSet<Type>(); AddClassesInHierarchy(type, types);      return types; },
            () => { var types = new HashSet<Type>(); AddClassesInHierarchy<Exception>(types); return types; },
            () => { var types = new HashSet<Type>(); type.AddClassesInHierarchy(types);       return types; }
        };
        
        foreach (var synonym in synonyms)
        {
            var types = synonym();
            IsTrue (() => types.Contains(type));
            IsTrue (() => types.Contains(typeof(object)));           // Base class
            IsFalse(() => types.Contains(typeof(ISerializable)));    // Not a class
            IsFalse(() => types.Contains(typeof(ReflectionHelperCore))); // Not part of Exception's list of base classes
        }
    }

    
    [TestMethod]
    public void HasClassInHierarchyTest()
    {
        Type type = typeof(Exception);
        Type secondType = typeof(object);
        
        var trueSynonyms = new[]
        {
            () => HasClassInHierarchy(type, secondType),
            () => HasClassInHierarchy<Exception>(secondType),
            () => HasClassInHierarchy<Exception, object>(),
            () => type.HasClassInHierarchy(secondType),
            () => type.HasClassInHierarchy<object>()
        };

        foreach (var trueSynonym in trueSynonyms)
        {
            IsTrue(trueSynonym());
        }
        
        Type wrongType = typeof(ReflectionHelperCore); // Not part of Exception's hierarchy.
        
        var falseSynonyms = new[]
        {
            () => HasClassInHierarchy(type, wrongType),
            () => HasClassInHierarchy<Exception>(wrongType),
            () => HasClassInHierarchy<Exception, ReflectionHelperCore>(),
            () => type.HasClassInHierarchy(wrongType),
            () => type.HasClassInHierarchy<ReflectionHelperCore>()
        };

        foreach (var falseSynonym in falseSynonyms)
        {
            IsFalse(falseSynonym());
        }
        
        ThrowsException(
            () => HasClassInHierarchy(type, typeof(ISerializable)),
            "secondType 'ISerializable' is not a class.");
    }
    
    // Interfaces

    [TestMethod]
    public void GetInterfacesInHierarchyTest()
    {
        Type type = typeof(Exception);
        
        var synonyms = new[]
        {
            () => GetInterfacesInHierarchy(type),
            () => GetInterfacesInHierarchy<Exception>(),
            () => type.GetInterfacesInHierarchy(),
            () => { var types = new HashSet<Type>(); AddInterfacesInHierarchy(type, types); return types; },
            () => { var types = new HashSet<Type>(); AddInterfacesInHierarchy<Exception>(types); return types; },
            () => { var types = new HashSet<Type>(); type.AddInterfacesInHierarchy(types); return types; }
        };
        
        foreach (var synonym in synonyms)
        {
            var types = synonym();  
            IsTrue(() => types.Contains(typeof(ISerializable)));
            IsFalse(() => types.Contains(typeof(Exception)));    // Not an interface
            IsFalse(() => types.Contains(typeof(object)));       // Not an interface
        }
    }

    [TestMethod]
    public void HasInterfaceInHierarchyTest()
    {
        Type type = typeof(Exception);
        Type secondType = typeof(ISerializable);
        
        var trueSynonyms = new[]
        {
            () => HasInterfaceInHierarchy(type, secondType),
            () => HasInterfaceInHierarchy<Exception>(secondType),
            () => HasInterfaceInHierarchy<Exception, ISerializable>(),
            () => type.HasInterfaceInHierarchy(secondType),
            () => type.HasInterfaceInHierarchy<ISerializable>()
        };
        
        foreach (var trueSynonym in trueSynonyms)
        {
            IsTrue(trueSynonym());
        }
        
        Type wrongType = typeof(IEnumerable); // Not part of Exception's interface list

        var falseSynonyms = new[]
        {
            () => HasInterfaceInHierarchy(type, wrongType),
            () => HasInterfaceInHierarchy<Exception>(wrongType),
            () => HasInterfaceInHierarchy<Exception, IEnumerable>(),
            () => type.HasInterfaceInHierarchy(wrongType),
            () => type.HasInterfaceInHierarchy<IEnumerable>()
        };
        
        foreach (var falseSynonym in falseSynonyms)
        {
            IsFalse(falseSynonym());
        }
    }

    // Duplicates Tests

    [TestMethod]
    public void GetInHierarchy_DuplicatesTest()
    {
        Type type = typeof(List<int>);
        
        var synonyms = new Func<IList<Type>>[]
        {
            // Use List preventing duplicates masked by HashSet.
            () => { var x = new List<Type>(); AddClassesInHierarchy   (type, x); return x; },
            () => { var x = new List<Type>(); AddInterfacesInHierarchy(type, x); return x; },
            () => { var x = new List<Type>(); AddTypesInHierarchy     (type, x); return x; },
        };

        foreach (var synonym in synonyms)
        {
            IList<Type> types = synonym();

            // Group by key to detect duplicates
            IList<Type> duplicates = types.GroupBy(x => x)
                                          .Where(x => x.Count() > 1)
                                          .Select(x => x.Key)
                                          .ToArray();
            if (duplicates.Count > 0)
            {
                Fail($"Found duplicate types: {Join(", ", duplicates.Select(t => t.Name))}");
            }
        }
    }
}
