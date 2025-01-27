using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Testing;
using JJ.Framework.Wishes.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static JJ.Framework.Testing.AssertHelper;
using static JJ.Framework.Wishes.Reflection.ReflectionWishes;

#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace JJ.Framework.Wishes.Tests
{
    [TestClass]
    [TestCategory("Framework")]
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
            //throw new NotImplementedException();
        }
        
        [TestMethod]
        public void AddTypesRecursiveTest()
        {
            //throw new NotImplementedException();
        }
        
        [TestMethod]
        public void HasTypeRecursiveTest()
        {
            //throw new NotImplementedException();
        }

        // Classes
        
        [TestMethod]
        public void GetClassesRecursiveTest()
        {
            //throw new NotImplementedException();
        }
        
        [TestMethod]
        public void AddClassesRecursiveTest()
        {
            //throw new NotImplementedException();
        }
        
        [TestMethod]
        public void HasClassRecursiveTest()
        {
            //throw new NotImplementedException();
        }

        // Interfaces
        
        [TestMethod]
        public void GetInterfacesRecursiveTest()
        {
            //throw new NotImplementedException();
        }
        
        [TestMethod]
        public void AddInterfacesRecursiveTest()
        {
            //throw new NotImplementedException();
        }
        
        [TestMethod]
        public void HasInterfaceRecursiveTest()
        {
            //throw new NotImplementedException();
        }
    }
}
