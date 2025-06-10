global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using JJ.Framework.Testing;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using static JJ.Framework.Testing.AssertHelper;
global using static JJ.Framework.Testing.Core.AssertCore;
global using static JJ.Framework.Testing.Core.AssertHelperLegacy;
#if !NET8_0_OR_GREATER
global using static JJ.Framework.PlatformCompatibility.Core.ExceptionSupport;
#else
global using static System.ArgumentException;
global using static System.ArgumentNullException;
#endif

//global using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;



