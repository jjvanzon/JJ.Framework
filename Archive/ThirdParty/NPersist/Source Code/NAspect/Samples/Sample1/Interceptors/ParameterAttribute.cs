using System;

namespace ConsoleApplication1
{
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = true, AllowMultiple = true)]
	public class ParameterAttribute : Attribute
	{
		public virtual void Validate(string name, Type type, object value)
		{
		}
	}

	public class NotNullParameterAttribute : ParameterAttribute
	{
		public override void Validate(string name, Type type, object value)
		{
			if (value == null)
				throw new Exception(string.Format("Parameter '{0}' may not be null!", name));
		}

	}
}