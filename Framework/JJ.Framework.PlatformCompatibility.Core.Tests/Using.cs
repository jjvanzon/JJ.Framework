global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using JJ.Framework.Testing;
global using JJ.Framework.PlatformCompatibility.Legacy;
global using static JJ.Framework.Testing.Legacy.AssertHelper;
global using static JJ.Framework.Testing.Core.AssertCore;
global using static JJ.Framework.Testing.Core.AssertHelperLegacy;
global using static JJ.Framework.Common.Core.NameHelper;
#if !NET8_0_OR_GREATER
global using static JJ.Framework.PlatformCompatibility.Core.ExceptionSupport;
#else
global using static System.ArgumentException;
global using static System.ArgumentNullException;
#endif
global using ArgExpress = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;
global using Prio       = System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute;
