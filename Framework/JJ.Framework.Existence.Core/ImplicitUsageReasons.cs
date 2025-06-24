﻿namespace JJ.Framework.Existence.Core;

internal static class ImplicitUsageReasons
{
    public const string MagicBool = 
        "This magic boolean can only take on one value. " +
        "It's not used by the implementation. " +
        "But it does affect overload resolution. " + 
        "It makes the right flag lead to the right specialized method.";
    
    public const string OverloadByName =
        "Adding optional parameters that aren't used, " +
        "can allow a certain kind of overload by parameter name, " +
        "which you can normally not do. " +
        "E.g. MyMethod(10, arg: true); MyMethod(10, arg2: true)";
}