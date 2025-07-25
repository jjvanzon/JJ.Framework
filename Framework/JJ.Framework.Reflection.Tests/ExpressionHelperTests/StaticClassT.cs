﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
    internal static class StaticClass<T>
    {
        // ncrunch: no coverage start
        public static string Name { get; set; }
        public static int Index { get; set; }

        public static Item Parent { get; set; }
        // ncrunch: no coverage end

        public static ComplexItem ComplexItem
        {
            get { return new ComplexItem(); }
        }

        public static string _field = "FieldResult";

        public static string Property
        {
            get { return "PropertyResult"; }
        }

        private static int[] _array = { 10, 11, 12 };
        public static int[] Array
        {
            get { return _array; }
        }

        public static string Method(int parameter)
        {
            return "MethodResult";
        }

        public static string MethodWithParams(params int[] array)
        {
            return "MethodWithParamsResult";
        }
    }
}
