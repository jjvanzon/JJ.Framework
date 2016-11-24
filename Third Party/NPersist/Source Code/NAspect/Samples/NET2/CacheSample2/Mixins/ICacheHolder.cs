using System;
using System.Collections;

namespace CacheSample
{
	/// <summary>
	/// Summary description for ICache.
	/// </summary>
	public interface ICacheHolder
	{
		Hashtable Cache { get; }
	}
}
