using System.Reflection;

namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class TrimShimUsage_TestBase
{
    // DynamicallyAccessedMembers / 'Dyn'

    public void Test_DynamicallyAccessedMembers()
    {
        var prop = GetPublicProp(typeof(SampleForDynMem), nameof(SampleForDynMem.Prop));
        IsTrue(prop != null);
    }

    private static PropertyInfo? GetPublicProp([DynamicallyAccessedMembers(PublicProperties)] Type type, string name)
        => type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);

    private class SampleForDynMem { public string Prop { get; } = ""; } // ncrunch: no coverage

    // DynamicallyAccessedMemberTypes

    public void Test_DynamicallyAccessedMemberTypes()
    {
        // Basic
        AreEqual(0,    (int)None);
        AreEqual(1,    (int)PublicParameterlessConstructor);
        AreEqual(3,    (int)PublicConstructors);
        AreEqual(4,    (int)NonPublicConstructors);
        AreEqual(8,    (int)PublicMethods);
        AreEqual(16,   (int)NonPublicMethods);
        AreEqual(32,   (int)PublicFields);
        AreEqual(64,   (int)NonPublicFields);
        AreEqual(128,  (int)PublicNestedTypes);
        AreEqual(256,  (int)NonPublicNestedTypes);
        AreEqual(512,  (int)PublicProperties);
        AreEqual(1024, (int)NonPublicProperties);
        AreEqual(2048, (int)PublicEvents);
        AreEqual(4096, (int)NonPublicEvents);
        AreEqual(-1,   (int)All);

        // WithInherited
        AreEqual((int)NonPublicConstructors | 0x4000,   (int)NonPublicConstructorsWithInherited);
        AreEqual((int)NonPublicMethods      | 0x8000,   (int)NonPublicMethodsWithInherited     );
        AreEqual((int)NonPublicFields       | 0x10000,  (int)NonPublicFieldsWithInherited      );
        AreEqual((int)NonPublicNestedTypes  | 0x20000,  (int)NonPublicNestedTypesWithInherited );
        AreEqual((int)NonPublicProperties   | 0x40000,  (int)NonPublicPropertiesWithInherited  );
        AreEqual((int)NonPublicEvents       | 0x80000,  (int)NonPublicEventsWithInherited      );
        AreEqual((int)PublicConstructors    | 0x100000, (int)PublicConstructorsWithInherited   );
        AreEqual((int)PublicNestedTypes     | 0x200000, (int)PublicNestedTypesWithInherited    );

        // All
        AreEqual(PublicConstructorsWithInherited | NonPublicConstructorsWithInherited, AllConstructors);
        AreEqual(PublicMethods | NonPublicMethodsWithInherited,                        AllMethods);
        AreEqual(PublicFields | NonPublicFieldsWithInherited,                          AllFields);
        AreEqual(PublicNestedTypesWithInherited | NonPublicNestedTypesWithInherited,   AllNestedTypes);
        AreEqual(PublicProperties | NonPublicPropertiesWithInherited,                  AllProperties);
        AreEqual(PublicEvents | NonPublicEventsWithInherited,                          AllEvents);

        // Platform-Dependent
        #if !NET5_0
        AreEqual(8192, (int)Interfaces);
        #endif
        #if NET5_0_OR_GREATER && !NET10_0
        AreEqual(AllProperties, PublicProperties | NonPublicProperties);
        AreEqual(AllFields, PublicFields | NonPublicFields);
        AreEqual(AllConstructors, PublicConstructors | NonPublicConstructors);
        AreEqual(AllMethods, PublicMethods | NonPublicMethods);
        #endif

        // Flag Inclusion
        IsTrue(PublicConstructors.HasFlag(PublicParameterlessConstructor));
    }

    // RequiresUnreferencedCode / 'TrimWarn'

    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Testing the attribute.")]
    [DynamicDependency(PublicMethods, typeof(SampleForRequiresUnreferencedCode))]
    public void Test_RequiresUnreferencedCode()
    {
        var attr = typeof(SampleForRequiresUnreferencedCode)
            .GetMethod(nameof(SampleForRequiresUnreferencedCode.Method))!
            .GetCustomAttribute<RequiresUnreferencedCodeAttribute>()!;
        AreEqual("reason", attr.Message);
    }

    private class SampleForRequiresUnreferencedCode
    {
        [RequiresUnreferencedCode("reason")] public static void Method() { } // ncrunch: no coverage
    }

    // RequiresDynamicCode / 'AotWarn'

    [UnconditionalSuppressMessage("AOT", "IL3050", Justification = "Testing the attribute.")]
    [DynamicDependency(PublicMethods, typeof(SampleForRequiresDynamicCode))]
    public void Test_RequiresDynamicCode()
    {
        var attr = typeof(SampleForRequiresDynamicCode)
            .GetMethod(nameof(SampleForRequiresDynamicCode.Method))!
            .GetCustomAttribute<RequiresDynamicCodeAttribute>()!;
        AreEqual("reason", attr.Message);
    }

    private class SampleForRequiresDynamicCode
    {
        [RequiresDynamicCode("reason")] public static void Method() { } // ncrunch: no coverage
    }

    // DynamicDependency / 'NoTrim'

    [DynamicDependency(PublicMethods, typeof(SampleForDynamicDependency))]
    public void Test_DynamicDependency()
    {
        var method = typeof(SampleForDynamicDependency).GetMethod(nameof(SampleForDynamicDependency.Method));
        IsTrue(method != null);
    }

    private class SampleForDynamicDependency { public void Method() { } } // ncrunch: no coverage

    // UnconditionalSuppressMessage / 'Suppress'

    [DynamicDependency(PublicMethods, typeof(SampleForSuppress))]
    public void Test_UnconditionalSuppressMessage()
    {
        var attr = typeof(SampleForSuppress)
            .GetMethod(nameof(SampleForSuppress.Method))!
            .GetCustomAttribute<UnconditionalSuppressMessageAttribute>()!;
        AreEqual("Trimming", attr.Category);
        AreEqual("IL2026",   attr.CheckId);
    }

    private class SampleForSuppress
    {
        [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Safe here.")] public static void Method() { } // ncrunch: no coverage
    }
}

