Compilation.Core.Tests Scratch Pad
==================================

```log
System.Exception: Assert.IsTrue failed. Tested: 'Expected 'C:\Users\janjo\AppData\Local\Temp\JJ.CompilationCoreTests\dlg2rd5dsdc\Temp.csproj' in: 

Output =   Determining projects to restore...
  All projects are up-to-date for restore.'.
   at JJ.Framework.Testing.Core.AssertCore.Check(Boolean condition, String message, String methodName) in D:\Repositories\JJ.Framework\Framework\Testing.Core\AssertCore.Base.cs:line 104
   at JJ.Framework.Testing.Core.AssertCore.IsTrue(Boolean value, String message) in D:\Repositories\JJ.Framework\Framework\Testing.Core\AssertCore.Misc.cs:line 9
   at JJ.Framework.Compilation.Core.Tests.DotNetTests.AssertOutputText(String outputText, String expectedInOutput) in D:\Repositories\JJ.Framework\Framework\Compilation.Core.Tests\DotNetTests.cs:line 97
   at JJ.Framework.Compilation.Core.Tests.DotNetTests.TestRestore(Func`1 call) in D:\Repositories\JJ.Framework\Framework\Compilation.Core.Tests\DotNetTests.cs:line 143
   at JJ.Framework.Compilation.Core.Tests.DotNetTests.Test_Restore_ByEnum_Opt() in D:\Repositories\JJ.Framework\Framework\Compilation.Core.Tests\DotNetTests.cs:line 158
   at System.Reflection.MethodBaseInvoker.InterpretedInvoke_Method(Object obj, IntPtr* args)
   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
```

```cs


            Log("Saved CurDir:        " + saved);
                Log("Set CurDir to temp:  " + _tempDir);
                        Log("Set CurDir to saved: " + saved);
                    else
                    {
                        Log("Saved CurDir gone:   " + saved);
                    }
```