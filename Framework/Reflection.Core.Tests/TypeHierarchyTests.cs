namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class TypeHierarchyTests
{
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
            IsTrue(() => types.Contains(typeof(object)));        // Base class of all classes
            IsTrue(() => types.Contains(typeof(ISerializable))); // Interface of Exception
            IsFalse(() => types.Contains(typeof(Reflector)));    // Reflector not part of Exception's hierarchy.
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
        
        Type wrongType = typeof(Reflector); // Not part of Exception's hierarchy.
        
        var falseSynonyms = new[]
        { 
            () => HasTypeInHierarchy(type, wrongType),
            () => HasTypeInHierarchy<Exception>(wrongType),
            () => HasTypeInHierarchy<Exception, Reflector>(),
            () => type.HasTypeInHierarchy(wrongType),
            () => type.HasTypeInHierarchy<Reflector>()
        };
        
        foreach (var falseSynonym in falseSynonyms)
        {
            IsFalse(falseSynonym());
        }
    }

    // Classes

    [TestMethod]
    public void GetStateTypesInHierarchyTest_New()
    {
        Type type = typeof(Exception);
        
        var synonyms = new[]
        {
            () => GetStateTypesInHierarchy(type),
            () => GetStateTypesInHierarchy<Exception>(),
            () => type.GetStateTypesInHierarchy(),
            () => { var types = new HashSet<Type>(); AddStateTypesInHierarchy(type, types);      return types; },
            () => { var types = new HashSet<Type>(); AddStateTypesInHierarchy<Exception>(types); return types; },
            () => { var types = new HashSet<Type>(); type.AddStateTypesInHierarchy(types);       return types; }
        };
        
        foreach (var synonym in synonyms)
        {
            var types = synonym();
            IsTrue (() => types.Contains(type));
            IsTrue (() => types.Contains(typeof(object)));           // Base class
            IsFalse(() => types.Contains(typeof(ISerializable)));    // Not a class
            IsFalse(() => types.Contains(typeof(Reflector))); // Not part of Exception's list of base classes
        }
    }

    
    [TestMethod]
    public void HasStateTypeInHierarchyTest()
    {
        Type type = typeof(Exception);
        Type secondType = typeof(object);
        
        var trueSynonyms = new[]
        {
            () => HasStateTypeInHierarchy(type, secondType),
            () => HasStateTypeInHierarchy<Exception>(secondType),
            () => HasStateTypeInHierarchy<Exception, object>(),
            () => type.HasStateTypeInHierarchy(secondType),
            () => type.HasStateTypeInHierarchy<object>()
        };

        foreach (var trueSynonym in trueSynonyms)
        {
            IsTrue(trueSynonym());
        }
        
        Type wrongType = typeof(Reflector); // Not part of Exception's hierarchy.
        
        var falseSynonyms = new[]
        {
            () => HasStateTypeInHierarchy(type, wrongType),
            () => HasStateTypeInHierarchy<Exception>(wrongType),
            () => HasStateTypeInHierarchy<Exception, Reflector>(),
            () => type.HasStateTypeInHierarchy(wrongType),
            () => type.HasStateTypeInHierarchy<Reflector>()
        };

        foreach (var falseSynonym in falseSynonyms)
        {
            IsFalse(falseSynonym());
        }
        
        ThrowsException(
            () => HasStateTypeInHierarchy(type, typeof(ISerializable)),
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
            () => { var x = new List<Type>(); AddStateTypesInHierarchy   (type, x); return x; },
            () => { var x = new List<Type>(); AddInterfacesInHierarchy(type, x); return x; },
            () => { var x = new List<Type>(); AddTypesInHierarchy     (type, x); return x; },
        };

        foreach (var synonym in synonyms)
        {
            IList<Type> types = synonym();

            
            // Group by key to detect duplicates
            IList<Type> duplicates = types.GroupBy(x => x)
                                          .Where(x => x.Count() > 1)
                                          .Select(x => x.Key)  // ncrunch: no coverage start
                                          .ToArray();

            IsTrue(duplicates.Count == 0, $"Found duplicate types: {Join(", ", duplicates.Select(t => t.Name))}");
        }
    }
}
