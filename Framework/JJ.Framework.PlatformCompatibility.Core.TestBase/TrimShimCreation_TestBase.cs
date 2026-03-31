namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class TrimShimCreation_TestBase
{
    public void Test_DynamicallyAccessedMembers()
    {
        var attr = new DynamicallyAccessedMembersAttribute(PublicMethods);
        AreEqual(PublicMethods, attr.MemberTypes);
    }

    public void Test_DynamicallyAccessedMemberTypes()
    {
        AreEqual(0,  (int)None);
        AreEqual(1,  (int)PublicParameterlessConstructor);
        AreEqual(3,  (int)PublicConstructors);
        AreEqual(8,  (int)PublicMethods);
        AreEqual(-1, (int)All);
        IsTrue(PublicConstructors.HasFlag(PublicParameterlessConstructor));
    }

    public void Test_RequiresUnreferencedCode()
    {
        var attr = new RequiresUnreferencedCodeAttribute("message") { Url = "https://example.com" };
        AreEqual("message",             attr.Message);
        AreEqual("https://example.com", attr.Url);
    }

    public void Test_RequiresDynamicCode()
    {
        var attr = new RequiresDynamicCodeAttribute("message") { Url = "https://example.com" };
        AreEqual("message",             attr.Message);
        AreEqual("https://example.com", attr.Url);
    }

    public void Test_DynamicDependency()
    {
        var attr1 = new DynamicDependencyAttribute("MemberSig");
        AreEqual("MemberSig", attr1.MemberSignature);

        var attr2 = new DynamicDependencyAttribute("MemberSig", typeof(string));
        AreEqual("MemberSig",    attr2.MemberSignature);
        AreEqual(typeof(string), attr2.Type);

        var attr3 = new DynamicDependencyAttribute("MemberSig", "TypeName", "AssemblyName");
        AreEqual("MemberSig",    attr3.MemberSignature);
        AreEqual("TypeName",     attr3.TypeName);
        AreEqual("AssemblyName", attr3.AssemblyName);

        var attr4 = new DynamicDependencyAttribute(PublicMethods, typeof(string));
        AreEqual(PublicMethods, attr4.MemberTypes);
        AreEqual(typeof(string), attr4.Type);

        var attr5 = new DynamicDependencyAttribute(PublicMethods, "TypeName", "AssemblyName");
        AreEqual(PublicMethods, attr5.MemberTypes);
        AreEqual("TypeName",     attr5.TypeName);
        AreEqual("AssemblyName", attr5.AssemblyName);
    }

    public void Test_UnconditionalSuppressMessage()
    {
        var attr = new UnconditionalSuppressMessageAttribute("category", "checkId")
        {
            Scope       = "member",
            Target      = "~M:Type.Method",
            MessageId   = "MSG001",
            Justification = "reason"
        };
        AreEqual("category",        attr.Category);
        AreEqual("checkId",         attr.CheckId);
        AreEqual("member",          attr.Scope);
        AreEqual("~M:Type.Method",  attr.Target);
        AreEqual("MSG001",          attr.MessageId);
        AreEqual("reason",          attr.Justification);
    }
}
