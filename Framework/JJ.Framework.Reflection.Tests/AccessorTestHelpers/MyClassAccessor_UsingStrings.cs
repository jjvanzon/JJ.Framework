using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.AccessorTestHelpers
{
    public class MyClassAccessor_UsingStrings
    {
        private MyClass Object = new MyClass();
        private Accessor Accessor;
        private static Accessor StaticAccessor;

        public MyClassAccessor_UsingStrings()
        {
            Accessor = new Accessor(Object);
        }

        static MyClassAccessor_UsingStrings()
        {
            StaticAccessor = new Accessor(typeof(MyClass));
        }

        public int Field
        {
            get { return (int)Accessor.GetFieldValue("Field"); }
            set { Accessor.SetFieldValue("Field", value); }
        }

        public int Property
        {
            get { return (int)Accessor.GetPropertyValue("Property"); }
            set { Accessor.SetPropertyValue("Property", value); }
        }

        public int Method(int parameter)
        {
            return (int)Accessor.InvokeMethod("Method", parameter);
        }

        public int this[int index]
        {
            get { return (int)Accessor.GetIndexerValue(index); }
            set { Accessor.SetIndexerValue(index, value); }
        }

        public string this[string key]
        {
            get { return (string)Accessor.GetIndexerValue(key); }
            set { Accessor.SetIndexerValue(key, value); }
        }

        public static int StaticField
        {
            get { return (int)StaticAccessor.GetFieldValue("StaticField"); }
            set { StaticAccessor.SetFieldValue("StaticField", value); }
        }

        public static int StaticProperty
        {
            get { return (int)StaticAccessor.GetPropertyValue("StaticProperty"); }
            set { StaticAccessor.SetPropertyValue("StaticProperty", value); }
        }

        private static int StaticMethod(int parameter)
        {
            return (int)StaticAccessor.InvokeMethod("StaticMethod", parameter);
        }
    }
}
