﻿using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests.Obsolete
{
    [TestClass]
    public class CultureHelper_Obsolete_Tests
    {
        [TestMethod]
        public void Test_CultureHelper_Obsolete_SetThreadCultureName_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => CultureHelper_Obsolete_Accessor.SetThreadCultureName("nl-NL"),
                "Use SetCurrentCultureName instead.");
    }
}
