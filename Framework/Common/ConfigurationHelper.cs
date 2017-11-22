using System;
using System.Collections.Generic;

namespace JJ.Framework.Common
{
	/// <summary>
	/// For using configuration settings when you cannot be dependent on System.Configuration.
	/// </summary>
	public static class ConfigurationHelper
	{
		private static readonly object _sectionsLock = new object();
		private static readonly IDictionary<Type, object> _sections = new Dictionary<Type, object>();

		// TODO: Low priority: Make the overloads with the explicit section name.

		public static T GetSection<T>()
		{
			lock (_sectionsLock)
			{
				object section = TryGetSection<T>();
				if (section == null)
				{
					// ReSharper disable once UseStringInterpolation
					throw new Exception(string.Format(
						"Configuration section of type '{0}' was not set. To allow {1} to use this configuration section, call {2}.SetSection.",
						typeof(T).FullName,
						typeof(ConfigurationHelper).Assembly.GetName().Name,
						typeof(ConfigurationHelper).FullName));
				}
				return (T)section;
			}
		}

		public static T TryGetSection<T>()
		{
			lock (_sectionsLock)
			{
				object section;
				_sections.TryGetValue(typeof(T), out section);
				return (T)section;
			}
		}

		public static void SetSection<T>(T section)
		{
			if (section == null) throw new ArgumentNullException(nameof(section));

			lock (_sectionsLock)
			{
				if (_sections.ContainsKey(typeof(T)))
				{
					throw new Exception($"Configuration section of type '{typeof(T).FullName}' was already set.");
				}
				_sections.Add(typeof(T), section);
			}
		}
	}
}
