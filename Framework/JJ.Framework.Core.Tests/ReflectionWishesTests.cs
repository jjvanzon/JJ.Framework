using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using JJ.Framework.Testing;
using JJ.Framework.Wishes.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.String;
using static JJ.Framework.Testing.AssertHelper;
using static JJ.Framework.Wishes.Reflection.ReflectionWishes;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace JJ.Framework.Wishes.Tests
{
    [TestClass]
    public class ReflectionWishesTests
    {
        // Assemblies
        
        [TestMethod]
        public void GetAssemblyNameTest()
        {
            AreEqual("JJ.Framework.Core", () => GetAssemblyName<ReflectionWishes>());
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
        public void GetTypesRecursiveTest()
        {
            Type type = typeof(Exception);
            
            var synonyms = new Func<ICollection<Type>>[]
            {
                () => GetTypesRecursive(type),
                () => GetTypesRecursive<Exception>(),
                () => type.GetTypesRecursive(),
                () => { var types = new HashSet<Type>(); AddTypesRecursive(type, types);      return types; },
                () => { var types = new HashSet<Type>(); AddTypesRecursive<Exception>(types); return types; },
                () => { var types = new HashSet<Type>(); type.AddTypesRecursive(types);       return types; }
            };
            
            foreach (var synonym in synonyms)
            {
                var types = synonym();
                IsTrue(() => types.Contains(type));
                IsTrue(() => types.Contains(typeof(object)));            // Base class of all classes
                IsTrue(() => types.Contains(typeof(ISerializable)));     // Interface of Exception
                IsFalse(() => types.Contains(typeof(ReflectionWishes))); // ReflectionWishes not part of Exception's hierarchy.
            }
        }

        [TestMethod]
        public void HasTypeRecursiveTest()
        {
            Type type = typeof(Exception);
            Type secondType = typeof(ISerializable);

            var trueSynonyms = new Func<bool>[]
            {
                () => HasTypeRecursive(type, secondType),
                () => HasTypeRecursive<Exception>(secondType),
                () => HasTypeRecursive<Exception, ISerializable>(),
                () => type.HasTypeRecursive(secondType),
                () => type.HasTypeRecursive<ISerializable>()
            };
            
            foreach (var trueSynonym in trueSynonyms)
            {
                IsTrue(trueSynonym());
            }
            
            Type wrongType = typeof(ReflectionWishes); // Not part of Exception's hierarchy.
            
            var falseSynonyms = new Func<bool>[]
            { 
                () => HasTypeRecursive(type, wrongType),
                () => HasTypeRecursive<Exception>(wrongType),
                () => HasTypeRecursive<Exception, ReflectionWishes>(),
                () => type.HasTypeRecursive(wrongType),
                () => type.HasTypeRecursive<ReflectionWishes>()
            };
            
            foreach (var falseSynonym in falseSynonyms)
            {
                IsFalse(falseSynonym());
            }
        }

        // Classes

        [TestMethod]
        public void GetClassesRecursiveTest_New()
        {
            Type type = typeof(Exception);
            
            var synonyms = new Func<ICollection<Type>>[]
            {
                () => GetClassesRecursive(type),
                () => GetClassesRecursive<Exception>(),
                () => type.GetClassesRecursive(),
                () => { var types = new HashSet<Type>(); AddClassesRecursive(type, types);      return types; },
                () => { var types = new HashSet<Type>(); AddClassesRecursive<Exception>(types); return types; },
                () => { var types = new HashSet<Type>(); type.AddClassesRecursive(types);       return types; }
            };
            
            foreach (var synonym in synonyms)
            {
                var types = synonym();
                IsTrue (() => types.Contains(type));
                IsTrue (() => types.Contains(typeof(object)));           // Base class
                IsFalse(() => types.Contains(typeof(ISerializable)));    // Not a class
                IsFalse(() => types.Contains(typeof(ReflectionWishes))); // Not part of Exception's list of base classes
            }
        }

        
        [TestMethod]
        public void HasClassRecursiveTest()
        {
            Type type = typeof(Exception);
            Type secondType = typeof(object);
            
            var trueSynonyms = new Func<bool>[]
            {
                () => HasClassRecursive(type, secondType),
                () => HasClassRecursive<Exception>(secondType),
                () => HasClassRecursive<Exception, object>(),
                () => type.HasClassRecursive(secondType),
                () => type.HasClassRecursive<object>()
            };

            foreach (var trueSynonym in trueSynonyms)
            {
                IsTrue(trueSynonym());
            }
            
            Type wrongType = typeof(ReflectionWishes); // Not part of Exception's hierarchy.
            
            var falseSynonyms = new Func<bool>[]
            {
                () => HasClassRecursive(type, wrongType),
                () => HasClassRecursive<Exception>(wrongType),
                () => HasClassRecursive<Exception, ReflectionWishes>(),
                () => type.HasClassRecursive(wrongType),
                () => type.HasClassRecursive<ReflectionWishes>()
            };

            foreach (var falseSynonym in falseSynonyms)
            {
                IsFalse(falseSynonym());
            }
            
            ThrowsException(
                () => HasClassRecursive(type, typeof(ISerializable)),
                "secondType 'ISerializable' is not a class.");
        }
        
        // Interfaces

        [TestMethod]
        public void GetInterfacesRecursiveTest()
        {
            Type type = typeof(Exception);
            
            var synonyms = new Func<ICollection<Type>>[]
            {
                () => GetInterfacesRecursive(type),
                () => GetInterfacesRecursive<Exception>(),
                () => type.GetInterfacesRecursive(),
                () => { var types = new HashSet<Type>(); AddInterfacesRecursive(type, types); return types; },
                () => { var types = new HashSet<Type>(); AddInterfacesRecursive<Exception>(types); return types; },
                () => { var types = new HashSet<Type>(); type.AddInterfacesRecursive(types); return types; }
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
        public void HasInterfaceRecursiveTest()
        {
            Type type = typeof(Exception);
            Type secondType = typeof(ISerializable);
            
            var trueSynonyms = new Func<bool>[]
            {
                () => HasInterfaceRecursive(type, secondType),
                () => HasInterfaceRecursive<Exception>(secondType),
                () => HasInterfaceRecursive<Exception, ISerializable>(),
                () => type.HasInterfaceRecursive(secondType),
                () => type.HasInterfaceRecursive<ISerializable>()
            };
            
            foreach (var trueSynonym in trueSynonyms)
            {
                IsTrue(trueSynonym());
            }
            
            Type wrongType = typeof(IEnumerable); // Not part of Exception's interface list

            var falseSynonyms = new Func<bool>[]
            {
                () => HasInterfaceRecursive(type, wrongType),
                () => HasInterfaceRecursive<Exception>(wrongType),
                () => HasInterfaceRecursive<Exception, IEnumerable>(),
                () => type.HasInterfaceRecursive(wrongType),
                () => type.HasInterfaceRecursive<IEnumerable>()
            };
            
            foreach (var falseSynonym in falseSynonyms)
            {
                IsFalse(falseSynonym());
            }
        }

        // Duplicate Tests

        [TestMethod]
        public void GetRecursive_DuplicatesTest()
        {
            Type type = typeof(List<int>);
            
            var synonyms = new Func<IList<Type>>[]
            {
                // Use List preventing duplicates masked by HashSet.
                () => { var x = new List<Type>(); AddClassesRecursive   (type, x); return x; },
                () => { var x = new List<Type>(); AddInterfacesRecursive(type, x); return x; },
                () => { var x = new List<Type>(); AddTypesRecursive     (type, x); return x; },
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
}
