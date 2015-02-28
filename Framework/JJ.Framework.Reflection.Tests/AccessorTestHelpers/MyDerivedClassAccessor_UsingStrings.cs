using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection.Tests.AccessorTestHelpers
{
    public class MyDerivedClassAccessor_UsingStrings
    {
        private MyDerivedClass Object;
        private Accessor Accessor;
        private Accessor BaseAccessor;

        public MyDerivedClassAccessor_UsingStrings(MyDerivedClass obj)
        {
            Object = obj;
            Accessor = new Accessor(Object);
            BaseAccessor = new Accessor(Object, typeof(MyClass));
        }

        public int MemberToHide
        {
            get { return (int)Accessor.GetPropertyValue("MemberToHide"); }
            set { Accessor.SetPropertyValue("MemberToHide", value); }
        }

        public int Field
        {
            get { return (int)BaseAccessor.GetFieldValue("Field"); }
            set { BaseAccessor.SetFieldValue("Field", value); }
        }

        public int Property
        {
            get { return (int)BaseAccessor.GetPropertyValue("Property"); }
            set { BaseAccessor.SetPropertyValue("Property", value); }
        }
    }
}
