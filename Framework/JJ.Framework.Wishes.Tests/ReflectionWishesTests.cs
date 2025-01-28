using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using JJ.Framework.Testing;
using JJ.Framework.Wishes.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            AreEqual("JJ.Framework.Wishes", () => GetAssemblyName<ReflectionWishes>());
        }

        // Fields
        
        private string _field = "value";
        
        [TestMethod]
        public void GetFieldOrExceptionTest()
        {
            var synonyms = new List<Func<string, FieldInfo>>
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
            var types = GetTypesRecursive(typeof(Exception));
            IsTrue(() => types.Contains(typeof(Exception)));
            IsTrue(() => types.Contains(typeof(object))); // Base class of all classes
            IsTrue(() => types.Contains(typeof(ISerializable))); // Interface of Exception
            IsFalse(() => types.Contains(typeof(ReflectionWishes)));
        }

        [TestMethod]
        public void AddTypesRecursiveTest()
        {
            var types = new HashSet<Type>();
            AddTypesRecursive(typeof(Exception), types);

            IsTrue(() => types.Contains(typeof(Exception)));
            IsTrue(() => types.Contains(typeof(object)));
            IsTrue(() => types.Contains(typeof(ISerializable)));
            IsFalse(() => types.Contains(typeof(ReflectionWishes)));
        }

        [TestMethod]
        public void HasTypeRecursiveTest()
        {
            IsTrue(() => HasTypeRecursive(typeof(Exception), typeof(ISerializable)));
            IsFalse(() => HasTypeRecursive(typeof(Exception), typeof(ReflectionWishes))); // ReflectionWishes is not part of Exception's hierarchy
        }

        // Classes

        [TestMethod]
        public void GetClassesRecursiveTest()
        {
            var types = GetClassesRecursive(typeof(Exception));
            IsTrue (() => types.Contains(typeof(Exception)));
            IsTrue (() => types.Contains(typeof(object)));           // Base class
            IsFalse(() => types.Contains(typeof(ISerializable)));    // Not a class
            IsFalse(() => types.Contains(typeof(ReflectionWishes))); // Not part of Exception's list of base classes
        }

        [TestMethod]
        public void AddClassesRecursiveTest()
        {
            var types = new HashSet<Type>();
            AddClassesRecursive(typeof(Exception), types);
            IsTrue(() => types.Contains(typeof(Exception)));
            IsTrue(() => types.Contains(typeof(object)));
            IsFalse(() => types.Contains(typeof(ISerializable)));    // Not a class
            IsFalse(() => types.Contains(typeof(ReflectionWishes))); // Not part of Exception's list of base classes
        }

        [TestMethod]
        public void HasClassRecursiveTest()
        {
            IsTrue(() => HasClassRecursive(typeof(Exception), typeof(object)));
            IsFalse(() => HasClassRecursive(typeof(Exception), typeof(ReflectionWishes)));
            
            ThrowsException(
                () => HasClassRecursive(typeof(Exception), typeof(ISerializable)),
                "cls 'ISerializable' is not a class.");
        }

        // Interfaces

        [TestMethod]
        public void GetInterfacesRecursiveTest()
        {
            var types = GetInterfacesRecursive(typeof(Exception));
            IsTrue(() => types.Contains(typeof(ISerializable)));
            IsFalse(() => types.Contains(typeof(Exception))); // Not an interface
            IsFalse(() => types.Contains(typeof(object))); // Not an interface
        }

        [TestMethod]
        public void AddInterfacesRecursiveTest()
        {
            var types = new HashSet<Type>();
            AddInterfacesRecursive(typeof(Exception), types);
            IsTrue(() => types.Contains(typeof(ISerializable)));
            IsFalse(() => types.Contains(typeof(Exception))); // Not an interface
            IsFalse(() => types.Contains(typeof(object))); // Not an interface
        }

        [TestMethod]
        public void HasInterfaceRecursiveTest()
        {
            IsTrue(() => HasInterfaceRecursive(typeof(Exception), typeof(ISerializable)));
            IsFalse(() => HasInterfaceRecursive(typeof(Exception), typeof(IEnumerable))); // Not part of Exception's interface list
        }
    }
}
