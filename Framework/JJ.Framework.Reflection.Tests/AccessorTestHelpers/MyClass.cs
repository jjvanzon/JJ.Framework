using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.AccessorTestHelpers
{
    public class MyClass
    {
        private int Field;

        private int Property { get; set; }

        private void VoidMethod()
        { }

        private void VoidMethodInt(int parameter)
        { }

        private void VoidMethodIntInt(int parameter1, int parameter2)
        { }

        private int IntMethod()
        {
            return 1;
        }

        private int IntMethodInt(int parameter)
        {
            return 1;
        }

        private int IntMethodIntInt(int parameter1, int paremeter2)
        {
            return 1;
        }

        private Dictionary<int, int> _intDictionary = new Dictionary<int, int>();

        private int this[int index]
        {
            get { return _intDictionary[index]; }
            set { _intDictionary[index] = value; }
        }

        private Dictionary<string, string> _stringDictionary = new Dictionary<string, string>();

        private string this[string key]
        {
            get { return _stringDictionary[key]; }
            set { _stringDictionary[key] = value; }
        }

        private static int StaticField;

        private static int StaticProperty { get; set; }

        private static int StaticMethod(int parameter)
        {
            return 1;
        }

        public virtual int MemberToHide { get; set; }
    }
}
