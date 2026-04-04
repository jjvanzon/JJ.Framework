using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Testing
{
    internal static class DebuggerDisplayFormatter
    {
        internal static string DebuggerDisplay<T>(CaseBase<T> testCase) where T : struct
            => "{Case} " + testCase;

        internal static string DebuggerDisplay<T>(CaseProp<T> caseProp) where T : struct
            => "{" + nameof(CaseProp<T>) + "} " + caseProp;
        
        internal static string DebuggerDisplay<T>(NullyPair<T> values) where T : struct 
            => "{" + nameof(NullyPair<T>) + "} " + values;

        internal static string DebuggerDisplay<TMainPropNully, TMainPropCoalesced>(CaseBase<TMainPropNully, TMainPropCoalesced> testCase)
            => "{Case} " + testCase;
        
        internal static string DebuggerDisplay<TNully, TCoalesced>(CaseProp<TNully, TCoalesced> caseProp) //where T : struct
            => "{" + nameof(CaseProp<TNully, TCoalesced>) + "} " + caseProp;
        
        internal static string DebuggerDisplay<TNully, TCoalesced>(NullyPair<TNully, TCoalesced> values) //where TCoalesced : struct 
            => "{" + nameof(NullyPair<TNully, TCoalesced>) + "} " + values;
    }
}
