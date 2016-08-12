using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Analysis.TestCode
{
    public class ClassWith_PublicMethod_WithStringParameter
    {
        public void PublicMethodWithStringParameter_string(string parameter)
        { }

        public void PublicMethodWithStringParameter_String(String parameter)
        { }

        public void PublicMethodWithStringParameter_System_String(System.String parameter)
        { }
    }
}