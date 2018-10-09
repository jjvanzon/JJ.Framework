using System;
using System.Collections;

namespace CacheSample
{
	/// <summary>
	/// Summary description for CacheMixin.
	/// </summary>
	public class CacheHolderMixin : ICacheHolder
	{
		public CacheHolderMixin()
		{
		}

		private Hashtable cache = new Hashtable();

		public Hashtable Cache
		{
			get { return cache; }
		}
	}
}
