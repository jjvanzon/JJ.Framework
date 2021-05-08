using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("JJ.Framework.JavaScript")]
[assembly: AssemblyDescription(@"Several JavaScript helpers that may be used in private projects. 
This may be added to a post build events:
copy """"$(TargetDir)*.js"""" """"$(ProjectDir)Scripts""""
May depend on jQuery(version 2.0.3).
")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Jan Joost van Zon")]
[assembly: AssemblyProduct("JJ.Framework")]
[assembly: AssemblyCopyright("Copyright © 2014 - 2021 Jan Joost van Zon")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("90f1cfdb-f583-4896-967a-d28c63f39638")]

// Version information for an assembly consists of the following four values:
//
//	  Major Version
//	  Minor Version 
//	  Build Number
//	  Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.7.*")]
