RestoreTests Scratch Pad
========================

```cs        
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