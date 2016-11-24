using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for ObjectProperties.
	/// </summary>
	public class MethodProperties : ICustomTypeDescriptor, IObjectGuiItem
	{
		public MethodProperties(IContext context, object obj, MethodInfo methodInfo)
		{
			this.context = context;
			this.obj = obj;
			this.methodInfo = methodInfo;
			this.ClassMap = context.DomainMap.MustGetClassMap(obj.GetType() );
			SetSignature();
		}

		private void SetSignature()
		{
			string text = methodInfo.Name + "(";
			ParameterInfo[] paramInfos = methodInfo.GetParameters();
			foreach (ParameterInfo paramInfo in paramInfos )
			{
				text += paramInfo.ParameterType.ToString()  + " " + paramInfo.Name + ", ";
			}
			if (paramInfos.Length > 0)
			{
				text = text.Substring(0, text.Length - 2);
			}
			this.signature = text + ")";
		}

		#region Property  Signature
		
		private string signature;
		
		public string Signature
		{
			get { return this.signature; }
			set { this.signature = value; }
		}
		
		#endregion

		#region Property  Context
		
		private IContext context;
		
		public IContext Context
		{
			get { return this.context; }
			set { this.context = value; }
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

		#region Property  ClassMap
		
		private IClassMap classMap;
		
		public IClassMap ClassMap
		{
			get { return this.classMap; }
			set { this.classMap = value; }
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
		
		#region Property  PropertyMap
		
		private IPropertyMap propertyMap = null;
		
		public IPropertyMap PropertyMap
		{
			get { return this.propertyMap; }
			set { this.propertyMap = value; }
		}
		
		#endregion

		#region Property  ReferencedByObj
		
		private object referencedByObj = null;
		
		public object ReferencedByObj
		{
			get { return this.referencedByObj; }
			set { this.referencedByObj = value; }
		}
		
		#endregion

		#region Property  ReferencedByClassMap
		
		private IClassMap referencedByClassMap= null;
		
		public IClassMap ReferencedByClassMap
		{
			get { return this.referencedByClassMap; }
			set { this.referencedByClassMap = value; }
		}
		
		#endregion

		#region Property  ReferencedByPropertyMap
		
		private IPropertyMap referencedByPropertyMap= null;
		
		public IPropertyMap ReferencedByPropertyMap
		{
			get { return this.referencedByPropertyMap; }
			set { this.referencedByPropertyMap = value; }
		}
		
		#endregion

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this.obj,  true);
		}

		public string GetClassName()
		{
			return TypeDescriptor.GetClassName(this.obj,  true);
		}

		public string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this.obj,  true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this.obj,  true);
		}

		public EventDescriptor GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this.obj,  true);
		}

		public PropertyDescriptor GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this.obj,  true);
		}

		public object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this.obj, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this.obj,  true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this.obj,  true);
		}

		public PropertyDescriptorCollection GetProperties()
		{
			return GetProperties(null);
		}

		private PropertyDescriptorCollection propertyDescriptorCollection = null;

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			//PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this.obj, attributes, true);

//			IList addProps = new ArrayList() ;
//
//			foreach (PropertyDescriptor baseProp in baseProps)
//			{
//				IPropertyMap propertyMap = this.ClassMap.GetPropertyMap(baseProp.Name);
//				if (propertyMap != null)
//				{
//					if (propertyMap.ReferenceType == ReferenceType.None)
//					{
//						addProps.Add(baseProp);
//					}					
//				}
//			}

			ParameterInfo[] paramInfos = methodInfo.GetParameters() ;

			if (propertyDescriptorCollection == null)
			{
				PropertyDescriptor[] newProps = new PropertyDescriptor[paramInfos.Length];

				for (int i = 0; i < paramInfos.Length; i++)
				{
					newProps[i] = new MethodParameterTypeDescriptor(this.obj, paramInfos[i], this.methodInfo)  ;
				}

				propertyDescriptorCollection = new PropertyDescriptorCollection(newProps);

			}
			return propertyDescriptorCollection;

		}

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this.obj;
		}
	}
}
