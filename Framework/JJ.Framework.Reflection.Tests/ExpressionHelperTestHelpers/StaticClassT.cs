using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTestHelpers
{
    public static class StaticClass<T>
    {
        public static string Name;
        public static int Index;

        public static Item Parent;

        public static ComplexItem ComplexItem
        {
            get { return new ComplexItem(); }
        }

        public static string Field = "FieldResult";

        public static string Property
        {
            get { return "PropertyResult"; }
        }

        public static int[] Array = { 0, 1, 2 };

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
