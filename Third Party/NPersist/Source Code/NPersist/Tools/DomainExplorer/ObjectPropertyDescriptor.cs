using System;
using System.ComponentModel;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Tools.DomainExplorer;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for WrappedProperty.
	/// </summary>
	public class ObjectPropertyDescriptor : PropertyDescriptor
	{
		public ObjectPropertyDescriptor(MemberDescriptor descr, IContext context, IPropertyMap propertyMap, object obj, Attribute[] attrs) : base(descr, attrs)
		{
			this.realPropertyDescriptor = (PropertyDescriptor) descr;
			this.name = propertyMap.Name;
			this.displayName = propertyMap.Name;

			Attribute[] attribs = new Attribute[descr.Attributes.Count + 4];

			int i = 0;
			foreach (Attribute attrib in descr.Attributes)
			{
				attribs[i] = attrib;
				i++;
			}
			attribs[i] = new DescriptionAttribute(propertyMap.Name + " is a property.");
			attribs[i + 1] = new CategoryAttribute("");
			attribs[i + 2] = new DefaultValueAttribute(context.ObjectManager.GetOriginalPropertyValue(obj, propertyMap.Name));
			attribs[i + 3] = new ReadOnlyAttribute(propertyMap.IsReadOnly);
			
			attributes = new AttributeCollection(attribs);
		}

		private PropertyDescriptor realPropertyDescriptor;
		private AttributeCollection attributes;
		private string name;
		private string displayName;

		private object GetActualObject(object component)
		{
			if (component is ObjectProperties)
				return ((ObjectProperties) component).GetObj();
			else
				return component;			
		}
		public override AttributeCollection Attributes
		{
			get
			{
				return this.attributes ;
			}
		}

		public override string Name
		{
			get
			{
				return this.name;
			}
		}

		public override string DisplayName
		{
			get
			{
				if (this.displayName.Length > 0)
					return this.displayName;
				return this.Name;
			}
		}


		public override bool CanResetValue(object component)
		{
			return this.realPropertyDescriptor.CanResetValue(GetActualObject(component));
		}

		public override object GetValue(object component)
		{
			return this.realPropertyDescriptor.GetValue(GetActualObject(component));
		}

		public override void ResetValue(object component)
		{
			this.realPropertyDescriptor.ResetValue(GetActualObject(component));
		}

		public override void SetValue(object component, object value)
		{
			this.realPropertyDescriptor.SetValue(GetActualObject(component), value);
		}

		public override bool ShouldSerializeValue(object component)
		{
			return this.realPropertyDescriptor.ShouldSerializeValue(GetActualObject(component));
		}

		public override Type ComponentType
		{
			get 
			{
				return this.realPropertyDescriptor.ComponentType;
			}
		}

		public override bool IsReadOnly
		{
			get 
			{
				return this.realPropertyDescriptor.IsReadOnly;
			}
		}

		public override Type PropertyType
		{
			get 
			{
				return this.realPropertyDescriptor.PropertyType;
			}
		}


	}
}
