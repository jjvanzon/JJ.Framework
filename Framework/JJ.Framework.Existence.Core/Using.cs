global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Collections.Immutable;
global using System.Collections.Specialized;
global using System.Collections.ObjectModel;
global using System.Buffers;
global using System.Linq;
global using System.Text;
global using System.Runtime.CompilerServices;
global using System.Diagnostics.CodeAnalysis;
global using JJ.Framework.Common;
global using JJ.Framework.Existence.Core.docs;
global using static System.String;
global using static System.StringComparison;
global using static System.ArgumentException;
global using static System.ArgumentNullException;
global using static System.Runtime.CompilerServices.MethodImplOptions;
global using static JJ.Framework.PlatformCompatibility.Core.ExceptionSupport;
global using static JJ.Framework.Existence.Core.ExistenceUtil;
global using static JJ.Framework.Existence.Core.FilledInHelper;
global using UsedImplicitlyAttribute = JetBrains.Annotations.UsedImplicitlyAttribute;
global using Priority = System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute;
global using Prio     = System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute;
#if NET8_0_OR_GREATER
global using System.Collections.Frozen;
#endif