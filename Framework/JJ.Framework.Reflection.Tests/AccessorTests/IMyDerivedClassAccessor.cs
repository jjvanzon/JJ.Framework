using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    public interface IMyDerivedClassAccessor
    {
        int MemberToHide { get; set; }
        int Base_MemberToHide { get; set; }
    }
}
