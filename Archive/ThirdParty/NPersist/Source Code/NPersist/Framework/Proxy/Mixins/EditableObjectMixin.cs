// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *


using System.Collections;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NAspect.Framework;
using System.ComponentModel;
using Puzzle.NAspect.Framework.Aop;
using System.Reflection;
using System;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Proxy.Mixins
{
    public class EditableObjectMixin : IEditableObject , IProxyAware
    {
        private object target = null;
        private Hashtable properties = new Hashtable ();

        public EditableObjectMixin()
        {
        }		

        public object GetPropertyValue (string name)
		{
			PropertyInfo property = (PropertyInfo)properties[name];
			return property.GetValue (target,null);
		}

		public void SetPropertyValue (string name,object value)
		{
			PropertyInfo property = (PropertyInfo)properties[name];
			property.SetValue (target,value,null);
		}

		private Hashtable propertyStore = new Hashtable();

        #region IEditableObject Members

		public void EndEdit()
		{
			propertyStore.Clear ();
		}

		public void CancelEdit()
		{
			foreach (PropertyInfo property in properties.Values)
			{
                object value = propertyStore[property.Name];
				property.SetValue (target,value,null);					
			}
		}

		public void BeginEdit()
		{
            InitProperties();
			propertyStore.Clear ();
			foreach (PropertyInfo property in properties.Values)
			{
                object value = property.GetValue (target,null);
				propertyStore[property.Name] = value;
			}
		}

		#endregion

        #region IProxyAware Members


        public void SetProxy(IAopProxy target)
        {            
            this.target = target;
            
        }

        private void InitProperties()
        {
            Type baseType = target.GetType().BaseType;
            PropertyInfo[] propertyArray = baseType.GetProperties();
            properties.Clear();

            IProxy proxy = (IProxy)target;
            IContext context = proxy.GetInterceptor().Context;
            foreach (PropertyInfo property in propertyArray)
            {
                if (property.PropertyType.IsInterface)
                    continue;

                if (!property.CanWrite)
                    continue;

                IClassMap classmap = context.DomainMap.GetClassMap(property.PropertyType);
                if (classmap != null)
                    continue;

                properties[property.Name] = property;
            }
        }

        #endregion
    }
}
