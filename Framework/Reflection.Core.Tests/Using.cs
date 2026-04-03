global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Globalization;
global using System.Linq;
global using System.Reflection;
global using System.Runtime.Serialization;
global using JJ.Framework.Common.Core;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using static System.Convert;
global using static System.DayOfWeek;
global using static System.Globalization.CultureInfo;
global using static System.Reflection.BindingFlags;
global using static System.String;
global using static JJ.Framework.Collections.Core.StaticEnumerable;
global using static JJ.Framework.Common.Core.FlagHelper;
global using static JJ.Framework.Common.Core.NameHelper;
global using static JJ.Framework.Existence.Core.FilledInHelper;
global using static JJ.Framework.Reflection.Core.MatchCaseFlag;
global using static JJ.Framework.Reflection.Core.NullFlag;
global using static JJ.Framework.Reflection.Core.Reflect;
global using static JJ.Framework.Reflection.Core.Tests.Helpers.FormatHelper;
global using static JJ.Framework.Testing.Core.AssertCore;
global using static JJ.Framework.Testing.Legacy.AssertHelper;

#if !NET9_0_OR_GREATER
global using static JJ.Framework.SharedProject.Core.NoTrimReasons;
#endif
