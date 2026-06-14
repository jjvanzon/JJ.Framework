// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable ReturnTypeCanBeNotNullable

// ReSharper disable RedundantSuppressNullableWarningExpression
namespace JJ.Framework.Compilation.Core.Tests.FilledInTests;

[TestClass]
public class DotNetOptionsFilledInTests
{
    // TODO: Test nullable opts explicitly for coverage.

    [TestMethod]
    public void Test_DotNetOptions_Nully()
    {
        {
            DotNetOptions? @null = null;
            AssertNully(@null);
        }
        {
            DotNetOptions @new = new();
            AssertNully(@new);
        }
        {
            DotNetOptions? nullyNew = new();
            AssertNully(nullyNew);
        }
        {
            DotNetOptions @default = default;
            AssertNully(@default);
        }
        {
            DotNetOptions? nullyDefault = default;
            AssertNully(nullyDefault);
        }
    }

    [TestMethod]
    public void Test_DotNetOptions_OnePropFilled()
    {
        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetOptions { Dir = filled });
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetOptions { File = filled });
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetOptions { BuildConf = filled });
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetOptions { Args = filled });
        }

        AssertFilled(new DotNetOptions { AutoRestore = true });
        AssertFilled(new DotNetOptions { ParallelRestore = true });
        AssertFilled(new DotNetOptions { NodeReuse = true });

        foreach (var filled in FilledTimeOuts)
        {
            AssertFilled(new DotNetOptions { TimeOutSec = filled });
        }
        
        foreach (var filled in FilledVerbosities)
        {
            AssertFilled(new DotNetOptions { Verbosity = filled });
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetOptions { LogFile = filled });
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetOptions { BinLog = filled });
        }

        foreach (var filled in FilledLogActions)
        {
            AssertFilled(new DotNetOptions { LogAction = filled });
        }
    }

    [TestMethod]
    public void Test_DotNetOptions_OnePropNully()
    {
        foreach (var nully in NullyTexts)
        {
            AssertFilled(FilledOpts with { Dir = nully! });
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(FilledOpts with { File = nully! });
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(FilledOpts with { BuildConf = nully! });
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(FilledOpts with { Args = nully! });
        }

        AssertFilled(FilledOpts with { AutoRestore = false });
        AssertFilled(FilledOpts with { ParallelRestore = false });
        AssertFilled(FilledOpts with { NodeReuse = false });

        foreach (var nully in NullyTimeOuts)
        {
            AssertFilled(FilledOpts with { TimeOutSec = nully! });
        }

        foreach (var nully in NullyVerbosities)
        {
            AssertFilled(FilledOpts with { Verbosity = nully! });
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(FilledOpts with { LogFile = nully! });
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(FilledOpts with { BinLog = nully! });
        }

        foreach (var nully in NullyLogActions)
        {
            AssertFilled(FilledOpts with { LogAction = nully! });
        }
    }

    [TestMethod]
    public void Test_DotNetOptions_FilledOrNot_AllCombos()
    {
        int counter = 0;

        // Take(n) otherwise 2 million combos (not fast)
        var dirVals             = FilledTexts      .Take(1).Union(NullyTexts      .Take(2)).ToArray();
        var fileVals            = FilledTexts      .Take(1).Union(NullyTexts      .Take(2)).ToArray();
        var buildConfVals       = FilledTexts      .Take(1).Union(NullyTexts      .Take(2)).ToArray();
        var argsVals            = FilledTexts      .Take(1).Union(NullyTexts      .Take(2)).ToArray();
        var autoRestoreVals     = FilledBools      .Take(1).Union(NullyBools      .Take(2)).ToArray();
        var parallelRestoreVals = FilledBools      .Take(1).Union(NullyBools      .Take(2)).ToArray();
        var nodeReuseVals       = FilledBools      .Take(1).Union(NullyBools      .Take(2)).ToArray();
        var timeOutSecVals      = FilledTimeOuts   .Take(1).Union(NullyTimeOuts   .Take(2)).ToArray();
        var verbosityVals       = FilledVerbosities.Take(1).Union(NullyVerbosities.Take(2)).ToArray();
        var logFileVals         = FilledTexts      .Take(1).Union(NullyTexts      .Take(2)).ToArray();
        var binLogVals          = FilledTexts      .Take(1).Union(NullyTexts      .Take(2)).ToArray();
        var logActionVals       = FilledLogActions .Take(1).Union(NullyLogActions .Take(2)).ToArray();

        foreach (var dir             in dirVals)
        foreach (var file            in fileVals)
        foreach (var buildConf       in buildConfVals)
        foreach (var args            in argsVals)
        foreach (var autoRestore     in autoRestoreVals)
        foreach (var parallelRestore in parallelRestoreVals)
        foreach (var nodeReuse       in nodeReuseVals)
        foreach (var timeOutSec      in timeOutSecVals)
        foreach (var verbosity       in verbosityVals)
        foreach (var logFile         in logFileVals)
        foreach (var binLog          in binLogVals)
        foreach (var logAction       in logActionVals)
        {
            DotNetOptions opts = new()
            { 
                Dir             = dir!,            
                File            = file!,           
                BuildConf       = buildConf!, 
                Args            = args!,
                AutoRestore     = autoRestore!,
                ParallelRestore = parallelRestore!,
                NodeReuse       = nodeReuse!,
                TimeOutSec      = timeOutSec!,
                Verbosity       = verbosity!,
                LogFile         = logFile!,
                BinLog          = binLog!,         
                LogAction       = logAction!
            };

            bool isNully = dir            .In(NullyTexts) &&
                           file           .In(NullyTexts) &&
                           buildConf      .In(NullyTexts) &&
                           args           .In(NullyTexts) &&
                           autoRestore    .In(NullyBools) &&
                           parallelRestore.In(NullyBools) &&
                           nodeReuse      .In(NullyBools) &&
                           timeOutSec     .In(NullyTimeOuts) &&
                           verbosity      .In(NullyVerbosities) &&
                           logFile        .In(NullyTexts) &&
                           binLog         .In(NullyTexts) &&
                           logAction      .In(NullyLogActions);

            if (isNully)
            {
                AssertNully(opts);
            }
            else
            {
                AssertFilled(opts);
            }

            counter++;
        }

        Log($"{counter} combos checked.");
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_DotNetOptions_NotNullWhen()
    {
        static DotNetOptions? Get() => new DotNetOptions();

        { DotNetOptions? args = Get(); if ( Has     (args )) args.ToString(); }
        { DotNetOptions? args = Get(); if ( FilledIn(args )) args.ToString(); }
        { DotNetOptions? args = Get(); if (!IsNully (args )) args.ToString(); }
        { DotNetOptions? args = Get(); if ( args.FilledIn()) args.ToString(); }
        { DotNetOptions? args = Get(); if (!args.IsNully ()) args.ToString(); }
    }
    // Helpers

    private static void AssertNully(DotNetOptions opts, [ArgExpress(nameof(opts))] string expr = "")
    {
        IsFalse(FilledIn(opts), expr);
        IsFalse(opts.FilledIn(), expr);

        IsTrue(IsNully(opts), expr);
        IsTrue(opts.IsNully(), expr);

        IsFalse(Has(opts), expr);
    }

    private static void AssertNully(DotNetOptions? opts, [ArgExpress(nameof(opts))] string expr = "")
    {
        IsFalse(FilledIn(opts), expr);
        IsFalse(opts.FilledIn(), expr);

        IsTrue(IsNully(opts), expr);
        IsTrue(opts.IsNully(), expr);

        IsFalse(Has(opts), expr);
    }

    private static void AssertFilled(DotNetOptions opts, [ArgExpress(nameof(opts))] string expr = "")
    {
        IsTrue(FilledIn(opts), expr);
        IsTrue(opts.FilledIn(), expr);

        IsFalse(IsNully(opts), expr);
        IsFalse(opts.IsNully(), expr);

        IsTrue(Has(opts), expr);
    }

    private static void AssertFilled(DotNetOptions? opts, [ArgExpress(nameof(opts))] string expr = "")
    {
        IsTrue(FilledIn(opts), expr);
        IsTrue(opts.FilledIn(), expr);

        IsFalse(IsNully(opts), expr);
        IsFalse(opts.IsNully(), expr);

        IsTrue(Has(opts), expr);
    }

    private static DotNetOptions FilledOpts { get; } = new()
    {
        Dir = FilledTexts[0],
        File = FilledTexts[0],
        BuildConf = FilledTexts[0],
        Args = FilledTexts[0],
        AutoRestore = true,
        ParallelRestore = true,
        NodeReuse = true,
        TimeOutSec = FilledTimeOuts[0],
        Verbosity = FilledVerbosities[0],
        LogFile = FilledTexts[0],
        BinLog = FilledTexts[0],
        LogAction = FilledLogActions[0]
    };
}

