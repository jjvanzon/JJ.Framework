using System;

namespace DesignByContract1.DbC
{
	[AttributeUsage(AttributeTargets.Method|AttributeTargets.Parameter)]
	public abstract class DbCAttribute : Attribute
	{
		public abstract void Validate(string parameterName,object parameterValue);		
	}
}
