namespace JJ.Framework.Reflection.Core;

public static class NoTrimReasons
{ 
    public const string StackTraceMethod = "StackTrace method might removed or incomplete.";
    public const string GenericMethods = "Closing a generic method may not work, if this closed type isn't natively compiled.";
}