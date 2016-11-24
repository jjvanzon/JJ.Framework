using System;
using System.Collections;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class DomainMapCache
	{
		private static Hashtable cache = new Hashtable() ;
		private static volatile object syncRoot = new object() ;

		public static bool ContainsKey (string key)
		{
			lock (syncRoot)
			{
				return cache.ContainsKey(key);
			}
		}

		public static IDomainMap GetMap(string key)
		{
			lock (syncRoot)
			{
				if (ContainsKey(key))
				{
					return (IDomainMap)cache[key];
				}
				else
				{
					throw new Exception(string.Format("DomainMap for cache key '' was not found.",key)) ;
				}				
			}
		}

		public static void AddMap(string key,IDomainMap map)
		{
			lock (syncRoot)
			{
				if (!ContainsKey(key))
				{
					cache.Add(key,map) ;				
				}
			}			
		}
	}
}
