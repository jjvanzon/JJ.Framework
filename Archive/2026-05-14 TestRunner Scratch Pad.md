TestRunner Scratch Pad
======================

```cs

    /*
    private static ParallelOptions GetParallelOptions(Assembly asm)
    {
        if (DoNotParallelize(asm)) 
        {
            return new ParallelOptions() { MaxDegreeOfParallelism = 1 };
        }

        return new();
    }
    */

    private static bool DoNotParallelize(MethodInfo method)
        => NotNull(method).GetCustomAttributes().Any(x => x.GetType().Name.Equals("DoNotParallelize", Ordinal)) &&
           DoNotParallelize(method.DeclaringType);
```