
namespace JJ.Framework.PlatformCompatibility.Legacy
{
    /// <inheritdoc cref="_membertype" />
    public enum MemberTypes_PlatformSafe
    {
        // Summary:
        //     Specifies that the member is a constructor, representing a System.Reflection.ConstructorInfo
        //     member. Hexadecimal value of 0x01.
        /// <inheritdoc cref="_membertype" />
        Constructor = 1,
        //
        // Summary:
        //     Specifies that the member is an event, representing an System.Reflection.EventInfo
        //     member. Hexadecimal value of 0x02.
        /// <inheritdoc cref="_membertype" />
        Event = 2,
        //
        // Summary:
        //     Specifies that the member is a field, representing a System.Reflection.FieldInfo
        //     member. Hexadecimal value of 0x04.
        /// <inheritdoc cref="_membertype" />
        Field = 4,
        //
        // Summary:
        //     Specifies that the member is a method, representing a System.Reflection.MethodInfo
        //     member. Hexadecimal value of 0x08.
        /// <inheritdoc cref="_membertype" />
        Method = 8,
        //
        // Summary:
        //     Specifies that the member is a property, representing a System.Reflection.PropertyInfo
        //     member. Hexadecimal value of 0x10.
        /// <inheritdoc cref="_membertype" />
        Property = 16,
        //
        // Summary:
        //     Specifies that the member is a type, representing a System.Reflection.MemberTypes.TypeInfo
        //     member. Hexadecimal value of 0x20.
        /// <inheritdoc cref="_membertype" />
        TypeInfo = 32,
        //
        // Summary:
        //     Specifies that the member is a custom member type. Hexadecimal value of 0x40.
        /// <inheritdoc cref="_membertype" />
        Custom = 64,
        //
        // Summary:
        //     Specifies that the member is a nested type, extending System.Reflection.MemberInfo.
        /// <inheritdoc cref="_membertype" />
        NestedType = 128,
        //
        // Summary:
        //     Specifies all member types.
        /// <inheritdoc cref="_membertype" />
        All = 191,
    }
}
