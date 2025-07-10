// ncrunch: no coverage start

#if NETFRAMEWORK || NETSTANDARD2_0 || NETSTANDARD2_1

namespace System.Runtime.CompilerServices;

[AttributeUsage(
    AttributeTargets.Class | 
    AttributeTargets.Struct | 
    AttributeTargets.Property | 
    AttributeTargets.Field,
    Inherited = false)]
internal class RequiredMemberAttribute : Attribute;

#endif

// ncrunch: no coverage end