using System.Reflection;

namespace JJ.Framework.PlatformCompatibility.Core.Tests
{
    [TestClass]
    public class PlatformCompatibility_MemberType_Core_Tests
    {
        // ncrunch: no coverage start
        
        public class DummyClass(int parameter)
        {
            public event EventHandler Event;
            public int _field = parameter;
            public int Property { get; set; }
            public void Method() { }
        }
        
        private class UnsupportedMemberInfo : MemberInfo
        {
            public override object[] GetCustomAttributes(bool inherit) => [];
            public override object[] GetCustomAttributes(Type attributeType, bool inherit) => [];
            public override bool IsDefined(Type attributeType, bool inherit) => default;
            public override Type DeclaringType { get; }
            public override MemberTypes MemberType { get; }
            public override string Name { get; }
            public override Type ReflectedType { get; }
        }

        // ncrunch: no coverage end
        
        [TestMethod]
        public void MemberTypes_PlatformSafe_Enum_Core_Test()
        {
            AreEqual(MemberTypes.Constructor, (MemberTypes)MemberTypes_PlatformSafe.Constructor);
            AreEqual(MemberTypes.Event,       (MemberTypes)MemberTypes_PlatformSafe.Event      );
            AreEqual(MemberTypes.Field,       (MemberTypes)MemberTypes_PlatformSafe.Field      );
            AreEqual(MemberTypes.Method,      (MemberTypes)MemberTypes_PlatformSafe.Method     );
            AreEqual(MemberTypes.Property,    (MemberTypes)MemberTypes_PlatformSafe.Property   );
            AreEqual(MemberTypes.TypeInfo,    (MemberTypes)MemberTypes_PlatformSafe.TypeInfo   );
            AreEqual(MemberTypes.Custom,      (MemberTypes)MemberTypes_PlatformSafe.Custom     );
            AreEqual(MemberTypes.NestedType,  (MemberTypes)MemberTypes_PlatformSafe.NestedType );
            AreEqual(MemberTypes.All,         (MemberTypes)MemberTypes_PlatformSafe.All        );
        }

        [TestMethod]
        public void MemberType_PlatformSafe_Method_Core_Test()
        {
            // Arrange
            
            Type            type            =             GetType       (                 );
            Type            nestedType      =       type .GetNestedType ("DummyClass"     );
            ConstructorInfo constructorInfo = nestedType!.GetConstructor( [ typeof(int) ] );
            FieldInfo       fieldInfo       = nestedType .GetField      ("_field"         );
            PropertyInfo    propertyInfo    = nestedType .GetProperty   ("Property"       );
            MethodInfo      methodInfo      = nestedType .GetMethod     ("Method"         );
            EventInfo       eventInfo       = nestedType .GetEvent      ("Event"          );
            
            // Check Nulls
            
            IsNotNull(type           );
            IsNotNull(nestedType     );
            IsNotNull(constructorInfo);
            IsNotNull(fieldInfo      );
            IsNotNull(propertyInfo   );
            IsNotNull(methodInfo     );
            IsNotNull(eventInfo      );
            
            // Act
            
            MemberTypes            type_MemberTypes = type           .MemberType;
            MemberTypes      nestedType_MemberTypes = nestedType     .MemberType;
            MemberTypes constructorInfo_MemberTypes = constructorInfo.MemberType;
            MemberTypes       fieldInfo_MemberTypes = fieldInfo      .MemberType;
            MemberTypes    propertyInfo_MemberTypes = propertyInfo   .MemberType;
            MemberTypes      methodInfo_MemberTypes = methodInfo     .MemberType;
            MemberTypes       eventInfo_MemberTypes = eventInfo      .MemberType;
            
            MemberTypes_PlatformSafe            type_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(type           );
            MemberTypes_PlatformSafe      nestedType_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(nestedType     );
            MemberTypes_PlatformSafe constructorInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(constructorInfo);
            MemberTypes_PlatformSafe       fieldInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(fieldInfo      );
            MemberTypes_PlatformSafe    propertyInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(propertyInfo   );
            MemberTypes_PlatformSafe      methodInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(methodInfo     );
            MemberTypes_PlatformSafe       eventInfo_MemberTypes_PlatformSafe = PlatformHelper.MemberInfo_MemberType_PlatformSafe(eventInfo      );
            
            MemberTypes_PlatformSafe            type_MemberTypes_PlatformSafe2 = type           .MemberType_PlatformSafe();
            MemberTypes_PlatformSafe      nestedType_MemberTypes_PlatformSafe2 = nestedType     .MemberType_PlatformSafe();
            MemberTypes_PlatformSafe constructorInfo_MemberTypes_PlatformSafe2 = constructorInfo.MemberType_PlatformSafe();
            MemberTypes_PlatformSafe       fieldInfo_MemberTypes_PlatformSafe2 = fieldInfo      .MemberType_PlatformSafe();
            MemberTypes_PlatformSafe    propertyInfo_MemberTypes_PlatformSafe2 = propertyInfo   .MemberType_PlatformSafe();
            MemberTypes_PlatformSafe      methodInfo_MemberTypes_PlatformSafe2 = methodInfo     .MemberType_PlatformSafe();
            MemberTypes_PlatformSafe       eventInfo_MemberTypes_PlatformSafe2 = eventInfo      .MemberType_PlatformSafe();
            
            // Assert (Literal Values)
            
            AreEqual(MemberTypes.TypeInfo,               type_MemberTypes);
            AreEqual(MemberTypes.NestedType,       nestedType_MemberTypes);
            AreEqual(MemberTypes.Constructor, constructorInfo_MemberTypes);
            AreEqual(MemberTypes.Field,             fieldInfo_MemberTypes);
            AreEqual(MemberTypes.Property,       propertyInfo_MemberTypes);
            AreEqual(MemberTypes.Method,           methodInfo_MemberTypes);
            AreEqual(MemberTypes.Event,             eventInfo_MemberTypes);

            AreEqual(MemberTypes_PlatformSafe.TypeInfo,               type_MemberTypes_PlatformSafe);
            AreEqual(MemberTypes_PlatformSafe.NestedType,       nestedType_MemberTypes_PlatformSafe);
            AreEqual(MemberTypes_PlatformSafe.Constructor, constructorInfo_MemberTypes_PlatformSafe);
            AreEqual(MemberTypes_PlatformSafe.Field,             fieldInfo_MemberTypes_PlatformSafe);
            AreEqual(MemberTypes_PlatformSafe.Property,       propertyInfo_MemberTypes_PlatformSafe);
            AreEqual(MemberTypes_PlatformSafe.Method,           methodInfo_MemberTypes_PlatformSafe);
            AreEqual(MemberTypes_PlatformSafe.Event,             eventInfo_MemberTypes_PlatformSafe);

            AreEqual(MemberTypes_PlatformSafe.TypeInfo,               type_MemberTypes_PlatformSafe2);
            AreEqual(MemberTypes_PlatformSafe.NestedType,       nestedType_MemberTypes_PlatformSafe2);
            AreEqual(MemberTypes_PlatformSafe.Constructor, constructorInfo_MemberTypes_PlatformSafe2);
            AreEqual(MemberTypes_PlatformSafe.Field,             fieldInfo_MemberTypes_PlatformSafe2);
            AreEqual(MemberTypes_PlatformSafe.Property,       propertyInfo_MemberTypes_PlatformSafe2);
            AreEqual(MemberTypes_PlatformSafe.Method,           methodInfo_MemberTypes_PlatformSafe2);
            AreEqual(MemberTypes_PlatformSafe.Event,             eventInfo_MemberTypes_PlatformSafe2);
            
            // Assert (Correlations)
            
            AreEqual(           type_MemberTypes_PlatformSafe,            type_MemberTypes_PlatformSafe2);
            AreEqual(     nestedType_MemberTypes_PlatformSafe,      nestedType_MemberTypes_PlatformSafe2);
            AreEqual(constructorInfo_MemberTypes_PlatformSafe, constructorInfo_MemberTypes_PlatformSafe2);
            AreEqual(      fieldInfo_MemberTypes_PlatformSafe,       fieldInfo_MemberTypes_PlatformSafe2);
            AreEqual(   propertyInfo_MemberTypes_PlatformSafe,    propertyInfo_MemberTypes_PlatformSafe2);
            AreEqual(     methodInfo_MemberTypes_PlatformSafe,      methodInfo_MemberTypes_PlatformSafe2);
            AreEqual(      eventInfo_MemberTypes_PlatformSafe,       eventInfo_MemberTypes_PlatformSafe2);
            
            AreEqual(           type_MemberTypes, (MemberTypes)           type_MemberTypes_PlatformSafe);
            AreEqual(     nestedType_MemberTypes, (MemberTypes)     nestedType_MemberTypes_PlatformSafe);
            AreEqual(constructorInfo_MemberTypes, (MemberTypes)constructorInfo_MemberTypes_PlatformSafe);
            AreEqual(      fieldInfo_MemberTypes, (MemberTypes)      fieldInfo_MemberTypes_PlatformSafe);
            AreEqual(   propertyInfo_MemberTypes, (MemberTypes)   propertyInfo_MemberTypes_PlatformSafe);
            AreEqual(     methodInfo_MemberTypes, (MemberTypes)     methodInfo_MemberTypes_PlatformSafe);
            AreEqual(      eventInfo_MemberTypes, (MemberTypes)      eventInfo_MemberTypes_PlatformSafe);
        }
        
        [TestMethod]
        public void MemberInfo_MemberType_PlatformSafe_NotSupportedException()
        {
            MemberInfo memberInfo = new UnsupportedMemberInfo();
            ThrowsException<NotSupportedException>(() => PlatformHelper.MemberInfo_MemberType_PlatformSafe(memberInfo));
        }
    }
}
