using System;
using System.Diagnostics;
using System.Reflection;

namespace JJ.Demos.ReflectionCache.Tests
{
	public class MyTests
	{
		public static void Execute()
		{
			const int iterations = 1000;

			Console.WriteLine();

			Console.WriteLine("My Tests Comparing Property Get Methods");

			long direct = TestGetPropertiesDirect(iterations);
			long cached = TestGetPropertiesCached(iterations);

			Console.WriteLine(
				"Cached access is {0} times faster than reflection access",
				(double)direct / (double)cached);

			TestGetPropertiesCachedAndDirectInOneMethod(iterations);
		}

		private static long TestGetPropertiesDirect(int iterations)
		{
			Console.WriteLine("TestGetPropertiesDirect...");

			Type[] types = GetTestTypes();
			int gets = 0;

			var sw = Stopwatch.StartNew();
			for (int i = 0; i < iterations; i++)
			{
				foreach (Type type in types)
				{
					//PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
					PropertyInfo[] properties = type.GetProperties();
					gets++;
				}
			}
			sw.Stop();

			Console.WriteLine("type.GetProperties(): {0} ms / {1}x", sw.ElapsedMilliseconds, gets);

			return sw.ElapsedMilliseconds;
		}

		private static long TestGetPropertiesCached(int iterations)
		{
			Console.WriteLine("TestGetPropertiesCached...");

			Type[] types = GetTestTypes();
			int gets = 0;

			var sw = Stopwatch.StartNew();
			for (int i = 0; i < iterations; i++)
			{
				foreach (Type type in types)
				{
					PropertyInfo[] properties = GetCachedProperties(type);
					gets++;
				}
			}
			sw.Stop();

			Console.WriteLine("ReflectionCache.GetProperties(): {0} ms / {1}x", sw.ElapsedMilliseconds, gets);

			return sw.ElapsedMilliseconds;
		}

		// Caching

		private static ReflectionCache_Adapted _cache = new ReflectionCache_Adapted(BindingFlags.Public | BindingFlags.Instance);

		//private static Dictionary<Type, PropertyInfo[]> _propertyDictionary =
		//		   new Dictionary<Type, PropertyInfo[]>();

		private static object _propertyDictionaryLock = new object();

		private static PropertyInfo[] GetCachedProperties(Type type)
		{
			return _cache.GetProperties(type);

			//lock (_propertyDictionaryLock)
			//{
			//	PropertyInfo[] properties;
			//	if (_propertyDictionary.TryGetValue(type, out properties) == false)
			//	{
			//		properties = type.GetProperties();
			//		_propertyDictionary.Add(type, properties);
			//	}

			//	return properties;
			//}
		}

		/// <summary>
		/// Returns a list of types to use for the subsequent tests
		/// </summary>
		private static Type[] GetTestTypes()
		{
			return typeof(string).Assembly.GetTypes();
		}

		private static void TestGetPropertiesCachedAndDirectInOneMethod(int iterations)
		{
			Type[] types = GetTestTypes();

			var cacheStopwatch = Stopwatch.StartNew();
			for (int i = 0; i < iterations; i++)
			{
				foreach (Type type in types)
				{
					PropertyInfo[] properties = _cache.GetProperties(type);
				}
			}
			cacheStopwatch.Stop();

			types = GetTestTypes();

			var directStopwatch = Stopwatch.StartNew();
			for (int i = 0; i < iterations; i++)
			{
				foreach (Type type in types)
				{
					//PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
					PropertyInfo[] properties = type.GetProperties();
				}
			}
			directStopwatch.Stop();

			Console.WriteLine("TestGetPropertiesCachedAndDirectInOneMethod: cached is {0:0.0#} times faster", (double)directStopwatch.ElapsedTicks / (double)cacheStopwatch.ElapsedTicks);
		}
	}
}
