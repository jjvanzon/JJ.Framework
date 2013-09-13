using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;


namespace NAspectProxyFactory
{
	public class NPersistPropertyInterceptor : IInterceptor
	{
		IContext context;
		public NPersistPropertyInterceptor(IContext context)
		{
			this.context = context;
		}

		public object HandleCall(MethodInvokation call)
		{		
			if (call.Method.Name.StartsWith("get_") )
				return HandleGetProperty(call);

			if (call.Method.Name.StartsWith("set_") )
				return HandleSetProperty(call);

			throw new Exception ("Blame Roger for this bug!");
		}

		/*          
			set
			{
				object refValue = (object) value;
				bool cancel = false;
				MatsSoft.NPersist.Framework.IInterceptor interceptor = ((MatsSoft.NPersist.Framework.IInterceptable) this).GetInterceptor();
				if (interceptor != null) { interceptor.NotifyPropertySet(this, "Name", ref refValue, ref cancel); }
				if (cancel) { return; }
				m_Name = (System.String) refValue;
			}
		*/
		private object HandleSetProperty(MethodInvokation call)
		{
			bool cancel = false;
			object value = ((InterceptedParameter)call.Parameters[0]).Value;
			string propertyName = call.Method.Name.Substring(4);
			object refValue = value;
			Puzzle.NPersist.Framework.Interfaces.IInterceptor interceptor = context.Interceptor;
			if (interceptor != null) { interceptor.NotifyPropertySet(call.Target, propertyName, ref refValue, ref cancel); }
			if (cancel) { return null; }
			((InterceptedParameter)call.Parameters[0]).Value = refValue;
			call.Proceed();		
			return null;
		}



		/*
		 get
            {
                System.String value = m_Name;
                object refValue = (object) value;
                bool cancel = false;
                MatsSoft.NPersist.Framework.IInterceptor interceptor = ((MatsSoft.NPersist.Framework.IInterceptable) this).GetInterceptor();
                if (interceptor != null) { interceptor.NotifyPropertyGet(this, "Name", ref refValue, ref cancel); }
                if (cancel) { return null; }
                value = (System.String) refValue;
                return value;
            }
		*/
		private object HandleGetProperty(MethodInvokation call)
		{
			string propertyName = call.Method.Name.Substring(4);
			object value = call.Proceed();
			bool cancel = false;
			Puzzle.NPersist.Framework.Interfaces.IInterceptor interceptor = context.Interceptor;
			if (interceptor != null) {interceptor.NotifyPropertyGet(call.Target,propertyName,ref value,ref cancel) ;}
			if (cancel) {return GetDefaultValue(call.ReturnType);}
			return value;
		}

		private static object GetDefaultValue(Type dataType)
		{
			Array array = Array.CreateInstance(dataType, 1);
			return array.GetValue(0);
		}
	}
}
