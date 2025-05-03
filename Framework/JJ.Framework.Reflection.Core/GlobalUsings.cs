global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Linq.Expressions;
global using System.Text;
global using System.Reflection;
global using System.Runtime.CompilerServices;
global using JJ.Framework.Reflection.Core.docs;
global using CallerAttribute = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using static System.Array;
global using static JJ.Framework.Reflection.ExpressionHelper;
global using static JJ.Framework.Reflection.ReflectionHelper;
global using static JJ.Framework.Reflection.Core.ReflectionHelperCore;

// TODO: Adapt and move to JJ.Framework.PlatformCompatibility.Core.

#if NET9_0_OR_GREATER
global using OverloadPrio = System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute;
#else
global using OverloadPrio = JJ.Framework.Common.Core.EmptyAttribute;
#endif
