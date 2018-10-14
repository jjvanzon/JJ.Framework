using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for ObjectProperties.
	/// </summary>
	public class ObjectProperties : ICustomTypeDescriptor, IObjectGuiItem
	{
		public ObjectProperties(IContext context, object obj)
		{
			this.context = context;
			this.obj = obj;
			this.ClassMap = context.DomainMap.MustGetClassMap(obj.GetType() );
		}

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

		public object GetObj()
		{
			return obj;
		}

		#region Property  ClassMap
		
		private IClassMap classMap;
		
		public IClassMap ClassMap
		{
			get { return this.classMap; }
			set { this.classMap = value; }
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
			return TypeDescriptor.GetProperties(this.obj,  true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this.obj, attributes, true);

			IList addProps = new ArrayList() ;

			foreach (PropertyDescriptor baseProp in baseProps)
			{
				IPropertyMap propertyMap = this.ClassMap.GetPropertyMap(baseProp.Name);
				if (propertyMap != null)
				{
					if (propertyMap.ReferenceType == ReferenceType.None)
					{
						addProps.Add(new ObjectPropertyDescriptor(baseProp, this.context, propertyMap, this.obj, attributes));
					}					
				}
			}

			PropertyDescriptor[] newProps = new PropertyDescriptor[addProps.Count];

			for (int i = 0; i < addProps.Count; i++)
			{
				newProps[i] = (PropertyDescriptor) addProps[i];
			}

			return new PropertyDescriptorCollection(newProps);
		}

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this.obj;
		}
	}
}
