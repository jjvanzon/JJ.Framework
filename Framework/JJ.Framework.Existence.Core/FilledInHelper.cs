using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Collections.Core;

namespace JJ.Framework.Existence.Core
{
    public static class FilledInHelper
    {
        
        public static bool FilledIn<T>(T      value)                  => !Equals(value, default(T));
        public static bool FilledIn<T>(T?     value) where T : struct => !Equals(value, default(T?)) && !Equals(value, default(T));
        public static bool FilledIn   (string value)                  => FilledIn(value, false);
        public static bool FilledIn   (string value, bool trimSpace)  => trimSpace ? !string.IsNullOrWhiteSpace(value): !string.IsNullOrEmpty(value);
        public static bool FilledIn<T>(params             T[] coll) => coll != null && coll.Length > 0;
        public static bool FilledIn<T>(List               <T> coll) => coll != null && coll.Count > 0;
        public static bool FilledIn<T>(HashSet            <T> coll) => coll != null && coll.Count > 0;
        public static bool FilledIn<T>(IList              <T> coll) => coll != null && coll.Count > 0;
        public static bool FilledIn<T>(ISet               <T> coll) => coll != null && coll.Count > 0;
        public static bool FilledIn<T>(ICollection        <T> coll) => coll != null && coll.Count > 0;
        public static bool FilledIn<T>(IReadOnlyList      <T> coll) => coll != null && coll.Count > 0;
        public static bool FilledIn<T>(IReadOnlyCollection<T> coll) => coll != null && coll.Count > 0;
        public static bool FilledIn<T>(IEnumerable        <T> coll) => coll != null && coll.Count() > 0;
        
        public static bool Has<T>(T              value)                  => FilledIn(value);
        public static bool Has<T>(T?             value) where T : struct => FilledIn(value);
        public static bool Has   (string         value)                  => FilledIn(value);
        public static bool Has   (string         value, bool trimSpace)  => FilledIn(value, trimSpace);
        public static bool Has<T>(T[]            coll)                   => FilledIn(coll);
        public static bool Has<T>(IList<T>       coll)                   => FilledIn(coll);
        public static bool Has<T>(ICollection<T> coll)                   => FilledIn(coll);
        public static bool Has<T>(HashSet<T>     coll)                   => FilledIn(coll);
        
        public static bool IsNully   (string         value)                  => !FilledIn(value);
        public static bool IsNully   (string         value, bool trimSpace)  => !FilledIn(value, trimSpace);
        public static bool IsNully<T>(T[]            coll)                   => !FilledIn(coll);
        public static bool IsNully<T>(IList<T>       coll)                   => !FilledIn(coll);
        public static bool IsNully<T>(ICollection<T> coll)                   => !FilledIn(coll);
        public static bool IsNully<T>(HashSet<T>     coll)                   => !FilledIn(coll);
        public static bool IsNully<T>(T              value)                  => !FilledIn(value);
        public static bool IsNully<T>(T?             value) where T : struct => !FilledIn(value);
        
        public static bool Is(string value, string comparison)                  => Is(value, comparison, ignoreCase: true);
        public static bool Is(string value, string comparison, bool ignoreCase) => string.Equals(value, comparison, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        
        public static bool In<T>(T      value, params T         [] comparisons                 ) => comparisons.Contains(value);
        public static bool In<T>(T      value, ICollection<T>      comparisons                 ) => comparisons.Contains(value);
        public static bool In<T>(T?     value, params T?        [] comparisons) where T : struct => comparisons.Contains(value);
        public static bool In<T>(T?     value, ICollection<T?>     comparisons) where T : struct => comparisons.Contains(value);
        public static bool In<T>(T?     value, params T         [] comparisons) where T : struct => value.HasValue && comparisons.Contains(value.Value);
        public static bool In<T>(T?     value, ICollection<T>      comparisons) where T : struct => value.HasValue && comparisons.Contains(value.Value);
        public static bool In   (string value, params string    [] comparisons                 ) => comparisons.Contains(value, ignoreCase: true);
        public static bool In   (string value, ICollection<string> comparisons                 ) => comparisons.Contains(value, ignoreCase: true);
        public static bool In   (string value, string[]            comparisons, bool ignoreCase) => comparisons.Contains(value, ignoreCase);
        
        // With Non-Nullables
        
        public static T Coalesce<T>(T value, T defaultValue)             => Has(value) ? value : defaultValue;
        public static T Coalesce<T>(T value, T defaultValue, T fallback) => Coalesce(value, Coalesce(defaultValue, fallback));
        
        public static T Coalesce<T>(params             T[] fallbacks) => Coalesce((IEnumerable<T>)fallbacks);
        public static T Coalesce<T>(List               <T> fallbacks) => Coalesce((IEnumerable<T>)fallbacks);
        public static T Coalesce<T>(HashSet            <T> fallbacks) => Coalesce((IEnumerable<T>)fallbacks);
        public static T Coalesce<T>(IList              <T> fallbacks) => Coalesce((IEnumerable<T>)fallbacks);
        public static T Coalesce<T>(ISet               <T> fallbacks) => Coalesce((IEnumerable<T>)fallbacks);
        public static T Coalesce<T>(ICollection        <T> fallbacks) => Coalesce((IEnumerable<T>)fallbacks);
        public static T Coalesce<T>(IReadOnlyList      <T> fallbacks) => Coalesce((IEnumerable<T>)fallbacks);
        public static T Coalesce<T>(IReadOnlyCollection<T> fallbacks) => Coalesce((IEnumerable<T>)fallbacks);
        public static T Coalesce<T>(IEnumerable        <T> fallbacks)
        {
            if (fallbacks == null) throw new ArgumentNullException(nameof(fallbacks));
            
            foreach (var fallback in fallbacks)
            {
                if (Has(fallback)) return fallback;
            }
            
            return fallbacks.LastOrDefault();
        }
        
        // With Nullables

        public static T Coalesce<T>(T? value, T  defaultValue)             where T : struct => Has(value) ? value.Value : defaultValue;
        public static T Coalesce<T>(T? value, T? defaultValue, T fallback) where T : struct => Coalesce(value, Coalesce(defaultValue, fallback));
        
        public static T Coalesce<T>(params             T?[] fallbacks) where T: struct => Coalesce((IEnumerable<T?>)fallbacks);
        public static T Coalesce<T>(List               <T?> fallbacks) where T: struct => Coalesce((IEnumerable<T?>)fallbacks);
        public static T Coalesce<T>(HashSet            <T?> fallbacks) where T: struct => Coalesce((IEnumerable<T?>)fallbacks);
        public static T Coalesce<T>(IList              <T?> fallbacks) where T: struct => Coalesce((IEnumerable<T?>)fallbacks);
        public static T Coalesce<T>(ISet               <T?> fallbacks) where T: struct => Coalesce((IEnumerable<T?>)fallbacks);
        public static T Coalesce<T>(ICollection        <T?> fallbacks) where T: struct => Coalesce((IEnumerable<T?>)fallbacks);
        public static T Coalesce<T>(IReadOnlyList      <T?> fallbacks) where T: struct => Coalesce((IEnumerable<T?>)fallbacks);
        public static T Coalesce<T>(IReadOnlyCollection<T?> fallbacks) where T: struct => Coalesce((IEnumerable<T?>)fallbacks);
        public static T Coalesce<T>(IEnumerable        <T?> fallbacks) where T: struct 
        {
            // TODO: Reduce repetition.
            // TODO: Maybe return default(T) as a last resort instead? Is that error hiding or actually just convenient?
            if (fallbacks == null) throw new ArgumentNullException(nameof(fallbacks));
            
            foreach (var fallback in fallbacks)
            {
                if (Has(fallback))
                {
                    if (fallback is T ret)
                    {
                        return ret;
                    }
                    else
                    {
                        throw new Exception("Last item of collection of fallbacks should be non-null value.");
                    }
                }
            }

            {
                T? fallback = fallbacks.LastOrDefault();
                if (fallback is T ret)
                {
                    return ret;
                }
                else
                {
                    throw new Exception("Last item of collection of fallbacks should be non-null value.");
                }
            }
        }
        
        // With Collections
        
        public static T          [ ] Coalesce<T>(T          [ ] coll, T          [ ] fallback) => Has(coll) ? coll : fallback ?? Array.Empty<T>();
        public static IList      <T> Coalesce<T>(IList      <T> coll, IList      <T> fallback) => Has(coll) ? coll : fallback ?? new List   <T>();
        public static ICollection<T> Coalesce<T>(ICollection<T> coll, ICollection<T> fallback) => Has(coll) ? coll : fallback ?? new List   <T>();
        public static HashSet    <T> Coalesce<T>(HashSet    <T> coll, HashSet    <T> fallback) => Has(coll) ? coll : fallback ?? new HashSet<T>();

        // With Strings
        
        public static string Coalesce(string value, string defaultValue)                                  => Has(value) ? value : defaultValue;
        public static string Coalesce(string value, string defaultValue, string fallback)                 => Coalesce(value, Coalesce(defaultValue, fallback));
        public static string Coalesce(string value, string defaultValue, bool   trimSpace)                => Has(value, trimSpace) ? value : defaultValue;
        public static string Coalesce(string value, string defaultValue, string fallback, bool trimSpace) => Coalesce(value, Coalesce(defaultValue, fallback, trimSpace), trimSpace);
        
        public static string Coalesce(params             string[] fallbacks) => Coalesce((IEnumerable<string>)fallbacks);
        public static string Coalesce(List               <string> fallbacks) => Coalesce((IEnumerable<string>)fallbacks);
        public static string Coalesce(HashSet            <string> fallbacks) => Coalesce((IEnumerable<string>)fallbacks);
        public static string Coalesce(IList              <string> fallbacks) => Coalesce((IEnumerable<string>)fallbacks);
        public static string Coalesce(ISet               <string> fallbacks) => Coalesce((IEnumerable<string>)fallbacks);
        public static string Coalesce(ICollection        <string> fallbacks) => Coalesce((IEnumerable<string>)fallbacks);
        public static string Coalesce(IReadOnlyList      <string> fallbacks) => Coalesce((IEnumerable<string>)fallbacks);
        public static string Coalesce(IReadOnlyCollection<string> fallbacks) => Coalesce((IEnumerable<string>)fallbacks);
        public static string Coalesce(IEnumerable        <string> fallbacks)
        {
            if (fallbacks == null) throw new ArgumentNullException(nameof(fallbacks));
            
            foreach (var fallback in fallbacks)
            {
                if (Has(fallback)) return fallback;
            }
            
            return fallbacks.LastOrDefault();
        }

        // Stringy Mix
        
        public static string Coalesce<T>(T  value, string defaultValue)                                   => Has(value) ? $"{value}" : defaultValue;
        public static string Coalesce<T>(T  value, T      defaultValue, string fallback)                  => Coalesce(Coalesce(value, defaultValue), fallback);
        public static string Coalesce<T>(T? value, string defaultValue)                  where T : struct => Has(value) ? $"{value}" : defaultValue;
        public static string Coalesce<T>(T? value, T?     defaultValue, string fallback) where T : struct => Coalesce(Coalesce(value, defaultValue), fallback);
   }
}