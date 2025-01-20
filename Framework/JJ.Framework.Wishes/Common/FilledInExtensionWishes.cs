using System.Collections.Generic;

namespace JJ.Framework.Wishes.Common
{
    public static class FilledInExtensionWishes
    {
        public static bool FilledIn(this    string   value)                 => FilledInWishes.FilledIn(value, false);
        public static bool FilledIn(this    string   value, bool trimSpace) => FilledInWishes.FilledIn(value, trimSpace);
        public static bool FilledIn<T>(this T[]      arr)                    => FilledInWishes.FilledIn(arr);
        public static bool FilledIn<T>(this IList<T> coll)                   => FilledInWishes.FilledIn(coll);
        public static bool FilledIn<T>(this T        value)                  => FilledInWishes.FilledIn(value);
        public static bool FilledIn<T>(this T?       value) where T : struct => FilledInWishes.FilledIn(value);
        
        public static bool Is(this string value, string comparison)                  => FilledInWishes.Is(value, comparison);
        public static bool Is(this string value, string comparison, bool ignoreCase) => FilledInWishes.Is(value, comparison, ignoreCase);
        
        public static bool In<T>(this T      value, params T     [] comparisons                 ) => FilledInWishes.In(value, comparisons);
        public static bool In   (this string value, params string[] comparisons                 ) => FilledInWishes.In(value, comparisons);
        public static bool In   (this string value, string[]        comparisons, bool ignoreCase) => FilledInWishes.In(value, comparisons, ignoreCase);
        
        public static T      Coalesce<T>(T   value, T      defaultValue)            => FilledInWishes.Coalesce(value, defaultValue);
        public static T      Coalesce<T>(T   value, T      defaultValue, T falback) => FilledInWishes.Coalesce(value, defaultValue, falback);
        public static T      Coalesce<T>(T?  value, T      defaultValue) where T : struct             => FilledInWishes.Coalesce(value, defaultValue);
        public static T      Coalesce<T>(T?  value, T?     defaultValue, T fallback) where T : struct => FilledInWishes.Coalesce(value, defaultValue, fallback);
        public static string Coalesce(string value, string defaultValue)                                  => FilledInWishes.Coalesce(value, defaultValue);
        public static string Coalesce(string value, string defaultValue, bool   trimSpace)                => FilledInWishes.Coalesce(value, defaultValue, trimSpace);
        public static string Coalesce(string value, string defaultValue, string fallback, bool trimSpace) => FilledInWishes.Coalesce(value, defaultValue, fallback, trimSpace);
    }
}