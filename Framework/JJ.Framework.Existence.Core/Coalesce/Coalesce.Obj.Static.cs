// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_existencecore"/>
public static partial class FilledInHelper
{ 
    // 2 Args (for some)
    
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     object? obj,  string? fallback                          ) => CoalesceObjectToText(obj,  fallback              );
    
    // 3 Args (for some)
    
    /// <inheritdoc cref="_coalesce" /> 
    public static string Coalesce   (     object? obj,  object? fallback, string? fallback2                           )                  => CoalesceObjectToText  (obj,  CoalesceObjectToText  (fallback, fallback2));

    // N Args (for all others)
    
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(                                    params IEnumerable<T?>?      fallbacks   ) where T : new()  => CoalesceManyObjects(fallbacks);
}
