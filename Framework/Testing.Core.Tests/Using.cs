global using System;
global using System.Linq;
global using System.Globalization;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using JJ.Framework.Common.Legacy;
global using static System.Globalization.CultureInfo;
global using static JJ.Framework.Testing.Core.AssertCore;
global using static JJ.Framework.Testing.Core.DeltaDirectionEnum;
global using static JJ.Framework.Testing.Core.Tests.Mocks;

// Legacy variant is also global using static, 
// to check that it old doesn't clash with new, 
// in side-by-side scenarios.
// ReSharper disable once RedundantUsingDirective.Global
global using static JJ.Framework.Testing.Legacy.AssertHelper;
