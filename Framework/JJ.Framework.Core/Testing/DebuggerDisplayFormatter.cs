using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Core.Testing
{
    internal static class DebuggerDisplayFormatter
    {
        internal static string DebuggerDisplay<T>(CaseBase<T> testCase) where T : struct
            => "{Case} " + testCase;

        internal static string DebuggerDisplay<T>(CaseProp<T> caseProp) where T : struct
            => "{" + nameof(CaseProp<T>) + "} " + caseProp;
        
        internal static string DebuggerDisplay<T>(NullyPair<T> values) where T : struct 
            => "{" + nameof(NullyPair<T>) + "} " + values;
    }
}
