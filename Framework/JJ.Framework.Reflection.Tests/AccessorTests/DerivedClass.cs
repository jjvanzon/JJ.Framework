using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    public class DerivedClass : Class
    {
        public new int MemberToHide { get; set; }
    }
}
