global using System.Reflection;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using JJ.Framework.Reflection.Core;
global using JJ.Framework.Exceptions.Core;
global using JJ.Framework.Compilation.Core.Tests.Accessors;
global using static System.StringComparison;
global using static System.String;
global using static System.IO.File;
global using static System.Threading.Tasks.Task;
global using static JJ.Framework.Common.Core.NameHelper;

global using static JJ.Framework.Reflection.Core.Reflect;
global using static JJ.Framework.Testing.Core.AssertCore;
global using static JJ.Framework.Existence.Core.FilledInHelper;
global using static JJ.Framework.Compilation.Core.DotNetOptions;
global using static JJ.Framework.Compilation.Core.DotNetCommandEnum;
global using static JJ.Framework.Compilation.Core.DotNetVerbosity;
global using static JJ.Framework.Compilation.Core.DotNet;
global using static JJ.Framework.Compilation.Core.Tests.Accessors.DotNetOptionsAccessor;

// ReSharper disable RedundantUsingDirective.Global
global using JJ.Framework.Compilation.Core.Tests;
global using static System.Environment;
global using static System.Console;
global using static JJ.Framework.Testing.Core.TestRunner;
