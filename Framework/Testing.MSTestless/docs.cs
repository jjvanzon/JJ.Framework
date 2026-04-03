/// <summary>
/// A simple test runner that discovers and runs tests.
/// Use this if other test tech is out of the question.
/// </summary>
public struct _testrunner;

/// <summary>
/// Replacement for the TestClass attribute from MSTest,
/// for in places where you can't rely on MSTest,
/// but still have to include code that relies on it somehow.
/// </summary>
public struct _testclass;

/// <summary>
/// Replacement for the TestMethod attribute from MSTest,
/// for in places where you can't rely on MSTest,
/// but still have to include code that relies on it somehow.
/// </summary>
public struct _testmethod;

/// <summary>
/// Replacement for the Assert class from MSTest,
/// for in places where you can't rely on MSTest,
/// but still have to include code that relies on it somehow.
/// </summary>
public struct _assert;

/// <summary>
/// Verifies that two objects are equal.
/// </summary>
public struct _areequal;

/// <summary>
/// Verifies that two objects are the same instance.
/// </summary>
public struct _aresame;

/// <summary>
/// Verifies that the specified condition is true.
/// </summary>
public struct _istrue;