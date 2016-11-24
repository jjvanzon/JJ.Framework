using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
	public class RemoveExceptionInterceptor : IAroundInterceptor
	{
		public object HandleCall(MethodInvocation call)
		{
			Type returnType = call.ReturnType;
			object res = null;
			try
			{
				res = call.Proceed();
			}
			catch
			{
				if (returnType != null)
					res = GetDefaultValue(returnType);
			}

			return res;
		}

		public object GetDefaultValue(Type type)
		{
			Array array = Array.CreateInstance(type, 1);
			object value = array.GetValue(0);
			return value;
		}
	}
}