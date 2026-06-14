global using System.Reflection;
global using System.Diagnostics.CodeAnalysis;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using JJ.Framework.Reflection.Core;
global using JJ.Framework.Existence.Core;
global using JJ.Framework.Compilation.Core.Primitives;
global using JJ.Framework.Compilation.Core.Tests.Accessors;
global using JJ.Framework.Compilation.Core.Tests.docs;
global using static System.String;
global using static System.StringComparison;
global using static System.IO.File;
global using static System.Threading.Tasks.Task;
global using static JJ.Framework.Common.Core.NameHelper;
global using static JJ.Framework.Existence.Core.FilledInHelper;
global using static JJ.Framework.Testing.Core.AssertCore;
global using static JJ.Framework.Compilation.Core.DotNet;
global using static JJ.Framework.Compilation.Core.DotNetFilledInHelper;
global using static JJ.Framework.Compilation.Core.Primitives.DotNetOptions;
global using static JJ.Framework.Compilation.Core.Primitives.DotNetCommandEnum;
global using static JJ.Framework.Compilation.Core.Primitives.DotNetVerbosity;
global using static JJ.Framework.Compilation.Core.Tests.TestHelper;

// ReSharper disable RedundantUsingDirective.Global
global using JJ.Framework.Compilation.Core.Tests;
global using JJ.Framework.Compilation.Core.Tests.FormatterTests;
global using JJ.Framework.Compilation.Core.Tests.PrimitivesTests;
global using static System.Environment;
global using static System.Console;
global using static JJ.Framework.Testing.Core.TestRunner;
