// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com, Roger Alsing
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Reflection;
using System.Runtime.InteropServices;
[assembly : AssemblyTitle("Puzzle NPersist Framework")]
[assembly : AssemblyDescription("Persistence Framework for .NET")]
[assembly : AssemblyCompany("Puzzle")]
[assembly : AssemblyProduct("Puzzle NPersist Framework")]
[assembly : AssemblyCopyright("Mats Helander, Roger Alsing")]
[assembly : AssemblyTrademark("")]
//[assembly: CLSCompliant(true)]
[assembly : Guid("0DD94A98-25F4-4DAF-A85A-4A1257A814BE")]
[assembly : AssemblyVersion("1.0.10.0")]

[assembly: AssemblyDelaySign(false)]
#if !NET2
[assembly: AssemblyKeyFile(@"..\..\..\..\PuzzleKey.snk")]
#endif
