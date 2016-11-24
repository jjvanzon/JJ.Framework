using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Puzzle.NAspect.Framework.Aop;
using AopDraw.Interfaces;
using Puzzle.NAspect.Framework;
using System.Collections;
using System.Reflection;

namespace AopDraw.Mixins
{
    public class CustomTypeDescriptorMixin : ICustomTypeDescriptor , IProxyAware
    {
        private object proxy;

        public void SetProxy(IAopProxy target)
        {
            this.proxy = target;
        }    


        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] filter)
        {
            Type proxyType = proxy.GetType();
            Type[] interfaces = proxyType.GetInterfaces();


            Hashtable allProerties = new Hashtable();
            
            PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(proxy.GetType ());
            foreach (PropertyDescriptor propDesc in baseProps)
            {
                allProerties.Add(propDesc.Name,propDesc);
            }            

            foreach (Type interfaceType in interfaces)
            {
                PropertyDescriptorCollection ifaceProps = TypeDescriptor.GetProperties(interfaceType);
                foreach (PropertyDescriptor propDesc in ifaceProps)
                {
                    PropertyInfo propInfo = interfaceType.GetProperty(propDesc.Name,BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                    
                    object[] customAttribs = propInfo.GetCustomAttributes(typeof(BrowsableAttribute),true);
                    if (customAttribs.Length > 0)
                    {
                        BrowsableAttribute browsable = (BrowsableAttribute)customAttribs[0];
                        if (browsable.Browsable)
                        {
                            if (!allProerties.ContainsKey(propDesc.Name))
                                allProerties.Add(propDesc.Name, propDesc);
                        }
                    }                    
                }
            }

            PropertyDescriptor[] allPropertiesArray = new PropertyDescriptor[allProerties.Count];
            int i = 0;
            foreach (PropertyDescriptor propDesc in allProerties.Values)
            {
                allPropertiesArray[i] = propDesc;
                i++;
            }            

            return new PropertyDescriptorCollection (allPropertiesArray);

        }

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        { return TypeDescriptor.GetAttributes(proxy, true); }

        string ICustomTypeDescriptor.GetClassName()
        { return TypeDescriptor.GetClassName(proxy, true); }

        string ICustomTypeDescriptor.GetComponentName()
        { return TypeDescriptor.GetComponentName(proxy, true); }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        { return TypeDescriptor.GetConverter(proxy, true); }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        { return TypeDescriptor.GetDefaultEvent(proxy, true); }

        EventDescriptorCollection
          ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        { return TypeDescriptor.GetEvents(proxy, attributes, true); }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        { return TypeDescriptor.GetEvents(proxy, true); }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        { return TypeDescriptor.GetDefaultProperty(proxy, true); }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        { return TypeDescriptor.GetProperties(proxy, true); }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        { return TypeDescriptor.GetEditor(proxy, editorBaseType, true); }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        { return proxy; }
    }
}
