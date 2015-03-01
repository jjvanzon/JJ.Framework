using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal abstract class MyDerivedClassAccessorBase : IMyDerivedClassAccessor
    {
        protected readonly Accessor _accessor;
        protected readonly Accessor _baseAccessor;

        public MyDerivedClassAccessorBase(MyDerivedClass obj)
        {
            _accessor = new Accessor(obj);
            _baseAccessor = new Accessor(obj, typeof(MyClass));
        }

        public abstract int MemberToHide { get; set; }
        public abstract int Base_MemberToHide { get; set; }
    }
}
