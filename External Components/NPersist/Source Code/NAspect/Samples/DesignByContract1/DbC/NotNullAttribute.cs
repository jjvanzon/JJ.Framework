using System;

namespace DesignByContract1.DbC
{
	[AttributeUsage(AttributeTargets.Method|AttributeTargets.Parameter)]
	public class NotNullAttribute : DbCAttribute
	{
		public override void Validate(string parameterName, object parameterValue)
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException(parameterName,string.Format("Parameter '{0}' may not be null!",parameterName) );
			}
		}
	}
}
