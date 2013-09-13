using System;
using System.ComponentModel;
using System.Reflection;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for MethodParameterTypeDescriptor.
	/// </summary>
	public class MethodParameterTypeDescriptor : PropertyDescriptor
	{

		public MethodParameterTypeDescriptor(object obj, ParameterInfo parameterInfo, MethodInfo methodInfo) : this(obj, parameterInfo, methodInfo, null)
		{
		}

		public MethodParameterTypeDescriptor(object obj, ParameterInfo parameterInfo, MethodInfo methodInfo, object value) : base(parameterInfo.Name, null)
		{
			this.obj = obj;
			this.parameterInfo = parameterInfo;
			this.methodInfo = methodInfo;
			this.value = value;
		}

		#region Property  IsReadOnly
		
		private bool isReadOnly = false;
				
		#endregion

		#region Property  Value
		
		private object value;
		
		public object Value
		{
			get { return this.value; }
			set
			{
				this.value = value;
			}
		}
		
		#endregion

		#region Property  Obj
		
		private object obj;
		
		public object Obj
		{
			get { return this.obj; }
			set { this.obj = value; }
		}
		
		#endregion

		#region Property  ParameterInfo
		
		private ParameterInfo parameterInfo;
		
		public ParameterInfo ParameterInfo
		{
			get { return this.parameterInfo; }
			set { this.parameterInfo = value; }
		}
		
		#endregion

		#region Property  MethodInfo
		
		private MethodInfo methodInfo;
		
		public MethodInfo MethodInfo
		{
			get { return this.methodInfo; }
			set { this.methodInfo = value; }
		}
		
		#endregion

		public override bool CanResetValue(object component)
		{
			return false;
		}

		public override object GetValue(object component)
		{
			return this.value ;
		}

		public override void ResetValue(object component)
		{
			throw new NotImplementedException();
		}

		public override void SetValue(object component, object value)
		{
			this.value = value;
		}

		public override bool ShouldSerializeValue(object component)
		{
			return true;
		}

		public override Type ComponentType
		{
			get { return this.obj.GetType();  }
		}

		public override bool IsReadOnly
		{
			get { return this.isReadOnly; }
		}

		public override Type PropertyType
		{
			get { return parameterInfo.ParameterType; }
		}

//		public override string Name
//		{
//			get
//			{
//				return this.parameterInfo.Name ;
//			}
//		}

	}
}
