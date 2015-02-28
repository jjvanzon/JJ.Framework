using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection.Tests.AccessorTestHelpers
{
    public class MyDerivedClass : MyClass
    {
        public override int MemberToHide
        {
            get { return base.MemberToHide; }
            set { base.MemberToHide = value; }
        }
    }
}
