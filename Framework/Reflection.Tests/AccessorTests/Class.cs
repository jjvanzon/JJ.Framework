using System.Collections.Generic;
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local
#pragma warning disable 169

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    public class Class
    {
        private int _field;

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

        private readonly Dictionary<int, int> _intDictionary = new Dictionary<int, int>();

        private int this[int index]
        {
            get { return _intDictionary[index]; }
            set { _intDictionary[index] = value; }
        }

        private readonly Dictionary<string, string> _stringDictionary = new Dictionary<string, string>();

        private string this[string key]
        {
            get { return _stringDictionary[key]; }
            set { _stringDictionary[key] = value; }
        }

        private static int _staticField;

        private static int StaticProperty { get; set; }

        private static int StaticMethod(int parameter)
        {
            return 1;
        }

        public int MemberToHide { get; set; }
    }
}
