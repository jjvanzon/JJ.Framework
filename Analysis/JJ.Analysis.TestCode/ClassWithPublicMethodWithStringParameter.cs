using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class ClassWithPublicMethodWithStringParameter
    {
        public void PublicMethodWithStringParameter_string(string parameter)
        {
        }
         
        public void PublicMethodWithStringParameter_String(String parameter)
        {
        }

        public void PublicMethodWithStringParameter_System_String(System.String parameter)
        {
        }
    }
}
