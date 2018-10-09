using System;
using System.Reflection;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace DesignByContract1.DbC
{
	public class DbCInterceptor : IAroundInterceptor
	{
		public object HandleCall(MethodInvocation call)
		{
			ParameterInfo[] parameters =call.Method.GetParameters();
			int i=0;

			//validate each DBC attribute for each parameter
			foreach (ParameterInfo parameter in parameters)
			{
				InterceptedParameter interceptedParameter = (InterceptedParameter)call.Parameters[i];

				object[] parameterAttributes = parameter.GetCustomAttributes(typeof(DbCAttribute),true);
				foreach (DbCAttribute attribute in parameterAttributes)
				{					
					attribute.Validate(interceptedParameter.Name,interceptedParameter.Value) ;
				}
				i++;
			}
			object result = call.Proceed() ;

			object[] methodAttributes = call.Method.GetCustomAttributes(typeof(DbCAttribute),true);
			foreach (DbCAttribute attribute in methodAttributes)
			{					
				attribute.Validate("@result",result) ;
			}

			return result;
		}
	}
}
