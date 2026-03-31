using System.Reflection;

namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class TrimShimUsage_TestBase
{
    public void Test_DynamicallyAccessedMembers()
    {
        var prop = GetPublicProp(typeof(SampleForDam), nameof(SampleForDam.Prop));
        IsTrue(prop != null);
    }

    private static PropertyInfo? GetPublicProp([Dyn(PublicProperties)] Type type, string name)
        => type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);

    private class SampleForDam { public string Prop { get; } = ""; }

    public void Test_DynamicallyAccessedMemberTypes()
    {
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
        AreEqual(8192, (int)Interfaces);
        AreEqual(-1,   (int)All);
        IsTrue(PublicConstructors.HasFlag(PublicParameterlessConstructor));
    }

    [Suppress("Trimming", "IL2026", Justification = "Testing the attribute.")]
    [NoTrim(PublicMethods, typeof(SampleForTrimWarn))]
    public void Test_RequiresUnreferencedCode()
    {
        var attr = typeof(SampleForTrimWarn)
            .GetMethod(nameof(SampleForTrimWarn.Method))!
            .GetCustomAttribute<RequiresUnreferencedCodeAttribute>()!;
        AreEqual("reason", attr.Message);
    }

    private class SampleForTrimWarn
    {
        [TrimWarn("reason")] public static void Method() { }
    }

    [Suppress("AOT", "IL3050", Justification = "Testing the attribute.")]
    [NoTrim(PublicMethods, typeof(SampleForAotWarn))]
    public void Test_RequiresDynamicCode()
    {
        var attr = typeof(SampleForAotWarn)
            .GetMethod(nameof(SampleForAotWarn.Method))!
            .GetCustomAttribute<RequiresDynamicCodeAttribute>()!;
        AreEqual("reason", attr.Message);
    }

    private class SampleForAotWarn
    {
        [AotWarn("reason")] public static void Method() { }
    }

    [NoTrim(PublicMethods, typeof(SampleForNoTrim))]
    public void Test_DynamicDependency()
    {
        var method = typeof(SampleForNoTrim).GetMethod(nameof(SampleForNoTrim.Method));
        IsTrue(method != null);
    }

    private class SampleForNoTrim { public void Method() { } }

    [NoTrim(PublicMethods, typeof(SampleForSuppress))]
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
        [Suppress("Trimming", "IL2026", Justification = "Safe here.")] public static void Method() { }
    }
}

