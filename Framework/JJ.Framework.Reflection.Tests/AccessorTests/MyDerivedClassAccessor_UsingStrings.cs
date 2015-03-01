using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class MyDerivedClassAccessor_UsingStrings : MyDerivedClassAccessorBase
    {
        public MyDerivedClassAccessor_UsingStrings(MyDerivedClass obj)
            : base(obj)
        { }

        public override int MemberToHide
        {
            get { return (int)_accessor.GetPropertyValue("MemberToHide"); }
            set { _accessor.SetPropertyValue("MemberToHide", value); }
        }

        public override int Base_MemberToHide
        {
            get { return (int)_baseAccessor.GetPropertyValue("MemberToHide"); }
            set { _baseAccessor.SetPropertyValue("MemberToHide", value); }
        }
    }
}
