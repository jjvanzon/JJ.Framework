namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertCore_Type_Tests
{
    private static readonly int? _nullableOne = 1;
    private static readonly Type _intType      = typeof(int);
    private static readonly Type _stringType   = typeof(string);

    // Type

    [TestMethod]
    public void Test_AssertCore_IsType_WithValue()
    {
        IsType(typeof(int?), _nullableOne);
        IsType(typeof(int?), _nullableOne, "oops");

        Throws(() => IsType(typeof(int), _nullableOne),         "IsType failed", "NullableOne");
        Throws(() => IsType(typeof(int), _nullableOne, "oops"), "IsType failed", "NullableOne", "oops");
    }

    [TestMethod]
    public void Test_AssertCore_IsType_TwoTypes()
    {
        IsType(typeof(int?), _nullableOne);
        IsType(typeof(int?), _nullableOne, "oops");

        Throws(() => IsType(typeof(int), _stringType),         "IsType failed", "StringType");
        Throws(() => IsType(typeof(int), _stringType, "oops"), "IsType failed", "StringType", "oops");
    }

    // NotType

    [TestMethod]
    public void Test_AssertCore_NotType_WithValue()
    {
        NotType(typeof(int), _nullableOne);
        NotType(typeof(int), _nullableOne, "oops");

        Throws(() => NotType(typeof(int?), _nullableOne),         "NotType failed", "NullableOne");
        Throws(() => NotType(typeof(int?), _nullableOne, "oops"), "NotType failed", "NullableOne", "oops");
    }

    [TestMethod]
    public void Test_AssertCore_NotType_WithTwoTypes()
    {
        NotType(typeof(string), _intType);
        NotType(typeof(string), _intType, "oops");

        Throws(() => NotType(typeof(int), _intType),         "NotType failed", "IntType");
        Throws(() => NotType(typeof(int), _intType, "oops"), "NotType failed", "IntType", "oops");
    }
}