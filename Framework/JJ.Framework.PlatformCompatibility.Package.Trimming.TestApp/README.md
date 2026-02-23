JJ.Framework.PlatformCompatibility.Legacy
=========================================

Package.Trimming.TestApp
------------------------

This inner-most component has basically no dependencies.  
But its tests fails to trim, because the test project itself 
uses untrimmable test-helper libraries.

For that reason, it is excluded from the solution `JJ.Framework.Package.Tests` for now.