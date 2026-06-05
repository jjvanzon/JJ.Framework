Restore Tests Scratch Pad
=========================

```cs
        string formattedFile = TryFormatFile(opt.File, args.CommandEnum);
        formattedFile, 

    [TestMethod] public void Test_Restore_ByMethod()                => TestRestore_ChDir(() => Restore());
    [TestMethod] public void Test_Restore_ByMethod_WithOpt()        => TestRestore      (() => Restore(GetOpt()));
    [TestMethod] public void Test_Restore_ByMethod_WithArgs()       => TestRestore_ChDir(() => Restore("--no-cache"));
    [TestMethod] public void Test_Restore_ByMethod_WithArgsAndOpt() => TestRestore      (() => Restore("--no-cache", GetOpt()));
    [TestMethod] public void Test_Restore_ByEnum()                  => TestRestore_ChDir(() => Exe(restore));
    [TestMethod] public void Test_Restore_ByEnum_WithOpt()          => TestRestore      (() => Exe(restore, GetOpt()));
    [TestMethod] public void Test_Restore_ByEnum_WithArgs()         => TestRestore_ChDir(() => Exe(restore, "--no-cache"));
    [TestMethod] public void Test_Restore_ByEnum_WithArgsAndOpt()   => TestRestore      (() => Exe(restore, "--no-cache", GetOpt()));
    [TestMethod] public void Test_Restore_ByName()                  => TestRestore_ChDir(() => Exe("restore"));
    [TestMethod] public void Test_Restore_ByName_WithOpt()          => TestRestore      (() => Exe("restore", GetOpt()));
    [TestMethod] public void Test_Restore_ByName_WithArgs()         => TestRestore_ChDir(() => Exe("restore", "--no-cache"));
    [TestMethod] public void Test_Restore_ByName_WithArgsAndOpt()   => TestRestore      (() => Exe("restore", "--no-cache", GetOpt()));

        string exceptionMessage = "";
        try
        {
            var build = Build(opt);
        }
        catch (Exception ex)
        {
            exceptionMessage = ex.Message;
        }


        var parallelOpts = new ParallelOptions { MaxDegreeOfParallelism = count };
        For(0, count, parallelOpts, i =>
        {
            try
            {
                results[i] = Restore(opts[i]);
            }
            catch (Exception ex)
            {
                exceptions[i] = ex;
            }
        });


        public void Deconstruct(
            out DotNetTestHelper helper, 
            out DotNetResult? result, 
            out Exception? exception)
        {
            helper = Helper;
            result = Result;
            exception = Exception;
        }
```