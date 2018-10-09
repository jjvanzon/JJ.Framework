using System;

namespace OneWayAsyncCalls
{
	[AttributeUsage(AttributeTargets.Method)]
	public class OneWayAttribute : Attribute
	{
	}
}