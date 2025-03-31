using System;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [TestClass]
    public class PlatformCompatibility_MemberType_Tests
    {
        public class DummyClass(int parameter)
        {
            public event EventHandler Event;
            public int _field = parameter;
            public int Property { get; set; }
            public void Method() { }
        }
        
        [TestMethod]
        public void MemberTypes_PlatformSafe_Test()
        {
            Assert.AreEqual(MemberTypes.Constructor, (MemberTypes)MemberTypes_PlatformSafe.Constructor);
            Assert.AreEqual(MemberTypes.Event,       (MemberTypes)MemberTypes_PlatformSafe.Event      );
            Assert.AreEqual(MemberTypes.Field,       (MemberTypes)MemberTypes_PlatformSafe.Field      );
            Assert.AreEqual(MemberTypes.Method,      (MemberTypes)MemberTypes_PlatformSafe.Method     );
            Assert.AreEqual(MemberTypes.Property,    (MemberTypes)MemberTypes_PlatformSafe.Property   );
            Assert.AreEqual(MemberTypes.TypeInfo,    (MemberTypes)MemberTypes_PlatformSafe.TypeInfo   );
            Assert.AreEqual(MemberTypes.Custom,      (MemberTypes)MemberTypes_PlatformSafe.Custom     );
            Assert.AreEqual(MemberTypes.NestedType,  (MemberTypes)MemberTypes_PlatformSafe.NestedType );
            Assert.AreEqual(MemberTypes.All,         (MemberTypes)MemberTypes_PlatformSafe.All        );
        }

        [TestMethod]
        public void MemberInfo_MemberType_PlatformSafe_Test()
        {
            // TODO: NestedType and Constructor are not accurately detected.

            // Arrange
            
            Type            type            =             GetType       (                 );
            Type            nestedType      =       type .GetNestedType ("DummyClass"     );
            ConstructorInfo constructorInfo = nestedType!.GetConstructor( [ typeof(int) ] );
            FieldInfo       fieldInfo       = nestedType .GetField      ("_field"         );
            PropertyInfo    propertyInfo    = nestedType .GetProperty   ("Property"       );
            MethodInfo      methodInfo      = nestedType .GetMethod     ("Method"         );
            EventInfo       eventInfo       = nestedType .GetEvent      ("Event"          );
            
            // Check Nulls
            
            Assert.IsNotNull(type           );
            Assert.IsNotNull(nestedType     );
            Assert.IsNotNull(constructorInfo);
            Assert.IsNotNull(fieldInfo      );
            Assert.IsNotNull(propertyInfo   );
            Assert.IsNotNull(methodInfo     );
            Assert.IsNotNull(eventInfo      );
            
            // Act
            
            MemberTypes            type_MemberTypes = type           .MemberType;
            MemberTypes      nestedType_MemberTypes = nestedType     .MemberType;
            MemberTypes constructorInfo_MemberTypes = constructorInfo.MemberType;
            MemberTypes       fieldInfo_MemberTypes = fieldInfo      .MemberType;
            MemberTypes    propertyInfo_MemberTypes = propertyInfo   .MemberType;
            MemberTypes      methodInfo_MemberTypes = methodInfo     .MemberType;
            MemberTypes       eventInfo_MemberTypes = eventInfo      .MemberType;
            
            MemberTypes_PlatformSafe            type_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(type           );
            //MemberTypes_PlatformSafe      nestedType_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(nestedType     );
            //MemberTypes_PlatformSafe constructorInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(constructorInfo);
            MemberTypes_PlatformSafe       fieldInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(fieldInfo      );
            MemberTypes_PlatformSafe    propertyInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(propertyInfo   );
            MemberTypes_PlatformSafe      methodInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(methodInfo     );
            MemberTypes_PlatformSafe       eventInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(eventInfo      );
            
            MemberTypes_PlatformSafe            type_MemberTypes_PlatformSafe2 = type           .MemberType_PlatformSafe();
            //MemberTypes_PlatformSafe      nestedType_MemberTypes_PlatformSafe2 = nestedType     .MemberType_PlatformSafe();
            //MemberTypes_PlatformSafe constructorInfo_MemberTypes_PlatformSafe2 = constructorInfo.MemberType_PlatformSafe();
            MemberTypes_PlatformSafe       fieldInfo_MemberTypes_PlatformSafe2 = fieldInfo      .MemberType_PlatformSafe();
            MemberTypes_PlatformSafe    propertyInfo_MemberTypes_PlatformSafe2 = propertyInfo   .MemberType_PlatformSafe();
            MemberTypes_PlatformSafe      methodInfo_MemberTypes_PlatformSafe2 = methodInfo     .MemberType_PlatformSafe();
            MemberTypes_PlatformSafe       eventInfo_MemberTypes_PlatformSafe2 = eventInfo      .MemberType_PlatformSafe();
            
            // Assert (Literal Values)
            
            Assert.AreEqual(MemberTypes.TypeInfo,               type_MemberTypes);
            Assert.AreEqual(MemberTypes.NestedType,       nestedType_MemberTypes);
            Assert.AreEqual(MemberTypes.Constructor, constructorInfo_MemberTypes);
            Assert.AreEqual(MemberTypes.Field,             fieldInfo_MemberTypes);
            Assert.AreEqual(MemberTypes.Property,       propertyInfo_MemberTypes);
            Assert.AreEqual(MemberTypes.Method,           methodInfo_MemberTypes);
            Assert.AreEqual(MemberTypes.Event,             eventInfo_MemberTypes);

            Assert.AreEqual(MemberTypes_PlatformSafe.TypeInfo,               type_MemberTypes_PlatformSafe);
            //Assert.AreEqual(MemberTypes_PlatformSafe.NestedType,       nestedType_MemberTypes_PlatformSafe);
            //Assert.AreEqual(MemberTypes_PlatformSafe.Constructor, constructorInfo_MemberTypes_PlatformSafe);
            Assert.AreEqual(MemberTypes_PlatformSafe.Field,             fieldInfo_MemberTypes_PlatformSafe);
            Assert.AreEqual(MemberTypes_PlatformSafe.Property,       propertyInfo_MemberTypes_PlatformSafe);
            Assert.AreEqual(MemberTypes_PlatformSafe.Method,           methodInfo_MemberTypes_PlatformSafe);
            Assert.AreEqual(MemberTypes_PlatformSafe.Event,             eventInfo_MemberTypes_PlatformSafe);

            Assert.AreEqual(MemberTypes_PlatformSafe.TypeInfo,               type_MemberTypes_PlatformSafe2);
            //Assert.AreEqual(MemberTypes_PlatformSafe.NestedType,       nestedType_MemberTypes_PlatformSafe2);
            //Assert.AreEqual(MemberTypes_PlatformSafe.Constructor, constructorInfo_MemberTypes_PlatformSafe2);
            Assert.AreEqual(MemberTypes_PlatformSafe.Field,             fieldInfo_MemberTypes_PlatformSafe2);
            Assert.AreEqual(MemberTypes_PlatformSafe.Property,       propertyInfo_MemberTypes_PlatformSafe2);
            Assert.AreEqual(MemberTypes_PlatformSafe.Method,           methodInfo_MemberTypes_PlatformSafe2);
            Assert.AreEqual(MemberTypes_PlatformSafe.Event,             eventInfo_MemberTypes_PlatformSafe2);
            
            // Assert (Correlations)
            
            Assert.AreEqual(           type_MemberTypes_PlatformSafe,            type_MemberTypes_PlatformSafe2);
            //Assert.AreEqual(     nestedType_MemberTypes_PlatformSafe,      nestedType_MemberTypes_PlatformSafe2);
            //Assert.AreEqual(constructorInfo_MemberTypes_PlatformSafe, constructorInfo_MemberTypes_PlatformSafe2);
            Assert.AreEqual(      fieldInfo_MemberTypes_PlatformSafe,       fieldInfo_MemberTypes_PlatformSafe2);
            Assert.AreEqual(   propertyInfo_MemberTypes_PlatformSafe,    propertyInfo_MemberTypes_PlatformSafe2);
            Assert.AreEqual(     methodInfo_MemberTypes_PlatformSafe,      methodInfo_MemberTypes_PlatformSafe2);
            Assert.AreEqual(      eventInfo_MemberTypes_PlatformSafe,       eventInfo_MemberTypes_PlatformSafe2);
            
            Assert.AreEqual(           type_MemberTypes, (MemberTypes)           type_MemberTypes_PlatformSafe);
            //Assert.AreEqual(     nestedType_MemberTypes, (MemberTypes)     nestedType_MemberTypes_PlatformSafe);
            //Assert.AreEqual(constructorInfo_MemberTypes, (MemberTypes)constructorInfo_MemberTypes_PlatformSafe);
            Assert.AreEqual(      fieldInfo_MemberTypes, (MemberTypes)      fieldInfo_MemberTypes_PlatformSafe);
            Assert.AreEqual(   propertyInfo_MemberTypes, (MemberTypes)   propertyInfo_MemberTypes_PlatformSafe);
            Assert.AreEqual(     methodInfo_MemberTypes, (MemberTypes)     methodInfo_MemberTypes_PlatformSafe);
            Assert.AreEqual(      eventInfo_MemberTypes, (MemberTypes)      eventInfo_MemberTypes_PlatformSafe);
        }
    }
}
