﻿using System.Collections.Generic;

// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Global
#pragma warning disable 169
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0060 // Remove unused parameter

namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    public class ClassLegacy
    {
        private int _field;

        private int Property { get; set; }

        private void VoidMethod() { }

        private void VoidMethodInt(int parameter) { }

        private void VoidMethodIntInt(int parameter1, int parameter2) { }

        private int IntMethod() => 1;

        private int IntMethodInt(int parameter) => 1;

        private int IntMethodIntInt(int parameter1, int parameter2) => 1;

        private readonly Dictionary<int, int> _intDictionary = new Dictionary<int, int>();

        private int this[int index]
        {
            get => _intDictionary[index];
            set => _intDictionary[index] = value;
        }

        private readonly Dictionary<string, string> _stringDictionary = new Dictionary<string, string>();

        private string this[string key]
        {
            get => _stringDictionary[key];
            set => _stringDictionary[key] = value;
        }

        private static int _staticField;

        private static int StaticProperty { get; set; }

        private static int StaticMethod(int parameter) => 1;

        public int MemberToHide { get; set; }
    }
}
