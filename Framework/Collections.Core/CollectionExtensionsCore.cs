 namespace JJ.Framework.Collections.Core;

 public static class CollectionExtensionsCore
 {
     /// <inheritdoc cref="_sumoftimespan" />
     public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
     {
         if (timeSpans == null) throw new ArgumentNullException(nameof(timeSpans));
         return timeSpans.Aggregate((x, y) => x + y);
     }
        
     /// <inheritdoc cref="_sumoftimespan" />
     public static TimeSpan Sum<T>(this IEnumerable<T> source, Func<T, TimeSpan> selector)
     {
         return source.Select(selector).Sum();
     }

     // TODO: Port to legacy from here.
        
     public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
     {
         if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
         if (action == null) throw new ArgumentNullException(nameof(action));

         int i = 0;
         foreach (var x in enumerable)
         {
             action(x, i++);
         }
     }

     public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
     {
         ThrowIfNull(collection);
         ThrowIfNull(items);
            
         foreach (var x in items)
         {
             collection.Add(x);
         }
     }

     /// <summary> AddRange is a member of List&lt;T&gt;. Here is an overload for ICollection&lt;T&gt;. </summary>
     public static void RemoveRange<T>(this ICollection<T> dest, IEnumerable<T> source)
     {
         if (dest == null) throw new ArgumentNullException(nameof(dest));
         if (source == null) throw new ArgumentNullException(nameof(source));

         foreach (T item in source)
         {
             dest.Remove(item);
         }
     }
        
     public static void Add<T>(this ICollection<T> collection, params T[] items)
     {
         ThrowIfNull(collection);
         ThrowIfNull(items);
            
         foreach (var x in items)
         {
             collection.Add(x);
         }
     }

 }