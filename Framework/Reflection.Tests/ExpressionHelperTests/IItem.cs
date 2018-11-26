﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
    internal interface IItem
    {
        int Property { get; set; }
        [IndexerName("Indexer")]
        string this[int index] { get; }
        string MethodWithParameter(int parameter);
        string MethodWithParams(params int[] array);
    }
}
