using System;

namespace ConsoleApplication1
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
	public class AopAttribute : Attribute
	{
	}
}