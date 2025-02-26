using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JJ.Framework.Wishes.Collections;
using static JJ.Framework.Reflection.ExpressionHelper;

namespace JJ.Framework.Wishes.Common
{
    public static class FilledInWishes
    {
        public static bool FilledIn(string      value)                  => FilledIn(value, false);
        public static bool FilledIn(string      value, bool trimSpace)  => trimSpace ? !string.IsNullOrWhiteSpace(value): !string.IsNullOrEmpty(value);
        public static bool FilledIn<T>(T[]      arr)                    => arr  != null && arr.Length > 0;
        public static bool FilledIn<T>(IList<T> coll)                   => coll != null && coll.Count > 0;
        public static bool FilledIn<T>(T        value)                  => !Equals(value, default(T));
        public static bool FilledIn<T>(T?       value) where T : struct => !Equals(value, default(T?)) && !Equals(value, default(T));
        
        public static bool Has(string      value)                  => FilledIn(value);
        public static bool Has(string      value, bool trimSpace)  => FilledIn(value, trimSpace);
        public static bool Has<T>(T[]      arr)                    => FilledIn(arr);
        public static bool Has<T>(IList<T> coll)                   => FilledIn(coll);
        public static bool Has<T>(T        value)                  => FilledIn(value);
        public static bool Has<T>(T?       value) where T : struct => FilledIn(value);
        
        public static bool IsNully(string      value)                  => !FilledIn(value);
        public static bool IsNully(string      value, bool trimSpace)  => !FilledIn(value, trimSpace);
        public static bool IsNully<T>(T[]      arr)                    => !FilledIn(arr);
        public static bool IsNully<T>(IList<T> coll)                   => !FilledIn(coll);
        public static bool IsNully<T>(T        value)                  => !FilledIn(value);
        public static bool IsNully<T>(T?       value) where T : struct => !FilledIn(value);
        
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
        
        // With Nullables

        public static T Coalesce<T>(T? value, T  defaultValue)             where T : struct => Has(value) ? value.Value : defaultValue;
        public static T Coalesce<T>(T? value, T? defaultValue, T fallback) where T : struct => Coalesce(value, Coalesce(defaultValue, fallback));

        // With Strings
        
        public static string Coalesce(string value, string defaultValue)                                  => Has(value) ? value : defaultValue;
        public static string Coalesce(string value, string defaultValue, string fallback)                 => Coalesce(value, Coalesce(defaultValue, fallback));
        public static string Coalesce(string value, string defaultValue, bool   trimSpace)                => Has(value, trimSpace) ? value : defaultValue;
        public static string Coalesce(string value, string defaultValue, string fallback, bool trimSpace) => Coalesce(value, Coalesce(defaultValue, fallback, trimSpace), trimSpace);
        
        // Stringy Mix
        
        public static string Coalesce<T>(T  value, string defaultValue)                                   => Has(value) ? $"{value}" : defaultValue;
        public static string Coalesce<T>(T  value, T      defaultValue, string fallback)                  => Coalesce(Coalesce(value, defaultValue), fallback);
        public static string Coalesce<T>(T? value, string defaultValue)                  where T : struct => Has(value) ? $"{value}" : defaultValue;
        public static string Coalesce<T>(T? value, T?     defaultValue, string fallback) where T : struct => Coalesce(Coalesce(value, defaultValue), fallback);

        public static T NotNull<T>(Expression<Func<T>> expression) => NoNull(expression);

        // TODO: Syntax examples.
        /// <summary>
        /// Perhaps slightly less fast than a literal check for null,
        /// but shorter in syntax, especially useful inlined.
        /// </summary>
        public static T NoNull<T>(Expression<Func<T>> expression)
        {
            T obj = GetValue(expression);
            
            if (obj== null)
            {
                string str = GetText(expression);
                throw new Exception(str + " not specified.");
            }
            
            return obj;
        }

    }
}