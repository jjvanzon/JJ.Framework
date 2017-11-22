using System;

namespace JJ.Framework.Reflection
{
	public class MethodCallParameterInfo
	{
		internal MethodCallParameterInfo(Type parameterType, string name, object value)
		{
			ParameterType = parameterType;
			Name = name;
			Value = value;
		}

		public Type ParameterType { get; }
		public string Name { get; }
		public object Value { get; }
	}
}
