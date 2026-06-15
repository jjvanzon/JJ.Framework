// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable ReturnTypeCanBeNotNullable

namespace JJ.Framework.Compilation.Core.Tests.FilledInTests;

[TestClass]
public class DotNetResultFilledInTests
{
    // TODO: AllFilled test so that case isn't dependent on the grand "all combos" loop.

    [TestMethod]
    public void Test_DotNetResult_Nully()
    {
        DotNetResult? @null = null;
        AssertNully(@null);

        var args = NewResult();
        AssertNully(args);
    }

    [TestMethod]
    public void Test_DotNetResult_OnePropFilled()
    {
        // TODO: Test with Opt prop filled, Args prop filled, and then the 4 other constructor arguments.

        foreach (var filled in FilledTexts)
        {
            AssertFilled(NewResult(new DotNetOptions { Dir = filled }));
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(NewResult(new DotNetOptions { File = filled }));
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(NewResult(new DotNetOptions { BuildConf = filled }));
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(NewResult(new DotNetOptions { Args = filled }));
        }

        {
            AssertFilled(NewResult(new DotNetOptions { AutoRestore = true }));
        }
        
        {
            AssertFilled(NewResult(new DotNetOptions { ParallelRestore = true }));
        }
        
        {
            AssertFilled(NewResult(new DotNetOptions { NodeReuse = true }));
        }

        foreach (var filled in FilledTimeOuts)
        {
            AssertFilled(NewResult(new DotNetOptions { TimeOutSec = filled }));
        }
        
        foreach (var filled in FilledVerbosities)
        {
            AssertFilled(NewResult(new DotNetOptions { Verbosity = filled }));
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(NewResult(new DotNetOptions { LogFile = filled }));
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(NewResult(new DotNetOptions { BinLog = filled }));
        }

        foreach (var filled in FilledLogActions)
        {
            AssertFilled(NewResult(new DotNetOptions { LogAction = filled }));
        }

        foreach (var filled in FilledCommandEnums)
        {
            AssertFilled(NewResult(new DotNetArgsAccessor { CommandEnum = filled }));
        }

        foreach (var filled in FilledCommands)
        {
            AssertFilled(NewResult(new DotNetArgsAccessor { Command = filled }));
        }

        foreach (var filled in FilledIDs)
        {
            AssertFilled(NewResult(new DotNetArgsAccessor { ID = filled }));
        }

        foreach (var filled in FilledVers)
        {
            AssertFilled(NewResult(new DotNetArgsAccessor { Ver = filled }));
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(NewResult(new DotNetArgsAccessor { Args = filled }));
        }

        {
            AssertFilled(NewResult(new DotNetArgsAccessor { IsRebuild = true }));
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(NewResult(new DotNetArgsAccessor { FullArgs = filled }));
        }
    }

    [TestMethod]
    public void Test_DotNetResult_OnePropNully()
    {
        foreach (var nully in NullyTexts)
        {
            AssertFilled(NewResult(FilledOpt with { Dir = nully! }));
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(NewResult(FilledOpt with { File = nully! }));
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(NewResult(FilledOpt with { BuildConf = nully! }));
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(NewResult(FilledOpt with { Args = nully! }));
        }

        {
            AssertFilled(NewResult(FilledOpt with { AutoRestore = false }));
        }

        {
            AssertFilled(NewResult(FilledOpt with { ParallelRestore = false }));
        }

        {
            AssertFilled(NewResult(FilledOpt with { NodeReuse = false }));
        }

        foreach (var nully in NullyTimeOuts)
        {
            AssertFilled(NewResult(FilledOpt with { TimeOutSec = nully! }));
        }

        foreach (var nully in NullyVerbosities)
        {
            AssertFilled(NewResult(FilledOpt with { Verbosity = nully! }));
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(NewResult(FilledOpt with { LogFile = nully! }));
        }

        foreach (var nully in NullyTexts)
        {
            AssertFilled(NewResult(FilledOpt with { BinLog = nully! }));
        }

        foreach (var nully in NullyLogActions)
        {
            AssertFilled(NewResult(FilledOpt with { LogAction = nully! }));
        }

        foreach (var nully in NullyCommandEnums)
        {
            var args = FilledArgs();
            args.CommandEnum = nully;
            AssertFilled(FilledResult(args));
        }

        foreach (var nully in NullyTexts.Except([ null ]))
        {
            var args = FilledArgs();
            args.Command = nully!;
            AssertFilled(FilledResult(args));
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            args.ID = nully!;
            AssertFilled(FilledResult(args));
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            args.Ver = nully!;
            AssertFilled(FilledResult(args));
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            args.Args = nully!;
            AssertFilled(FilledResult(args));
        }

        {
            var args = FilledArgs();
            args.IsRebuild = false;
            AssertFilled(FilledResult(args));
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            args.FullArgs = nully!;
            AssertFilled(FilledResult(args));
        }
    }

    [TestMethod]
    public void Test_DotNetResult_FilledOrNot_AllCombos()
    {
        // TODO: Was expecting failure, since result's own fields aren't used, just arg and opt..

        // Take(n) otherwise 2 million combos (not fast)
        var dirVals             = FilledTexts       .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var fileVals            = FilledTexts       .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var buildConfVals       = FilledTexts       .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var extraArgsVals1      = FilledTexts       .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var autoRestoreVals     = FilledBools       .Take(1).Union(NullyBools       .Take(1)).ToArray();
        var parallelRestoreVals = FilledBools       .Take(1).Union(NullyBools       .Take(1)).ToArray();
        var nodeReuseVals       = FilledBools       .Take(1).Union(NullyBools       .Take(1)).ToArray();
        var timeOutSecVals      = FilledTimeOuts    .Take(1).Union(NullyTimeOuts    .Take(1)).ToArray();
        var verbosityVals       = FilledVerbosities .Take(1).Union(NullyVerbosities .Take(1)).ToArray();
        var logFileVals         = FilledTexts       .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var binLogVals          = FilledTexts       .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var logActionVals       = FilledLogActions  .Take(1).Union(NullyLogActions  .Take(1)).ToArray();
        var commandEnumVals     = FilledCommandEnums.Take(1).Union(NullyCommandEnums.Take(1)).ToArray();
        var commandVals         = FilledCommands    .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var idVals              = FilledIDs         .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var verVals             = FilledVers        .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var extraArgsVals2      = FilledTexts       .Take(1).Union(NullyTexts       .Take(1)).ToArray();
        var isRebuildVals       = FilledBools       .Take(1).Union(NullyBools       .Take(1)).ToArray();
        var fullArgsVals        = FilledTexts       .Take(1).Union(NullyTexts       .Take(1)).ToArray();

        int counter = 0;

        foreach (var dir             in dirVals)
        foreach (var file            in fileVals)
        foreach (var buildConf       in buildConfVals)
        foreach (var extraArgs1      in extraArgsVals1)
        foreach (var autoRestore     in autoRestoreVals)
        foreach (var parallelRestore in parallelRestoreVals)
        foreach (var nodeReuse       in nodeReuseVals)
        foreach (var timeOutSec      in timeOutSecVals)
        foreach (var verbosity       in verbosityVals)
        foreach (var logFile         in logFileVals)
        foreach (var binLog          in binLogVals)
        foreach (var logAction       in logActionVals)
        foreach (var commandEnum     in commandEnumVals)
        foreach (var command         in commandVals)
        foreach (var id              in idVals)
        foreach (var ver             in verVals)
        foreach (var extraArgs2      in extraArgsVals2)
        foreach (var isRebuild       in isRebuildVals)
        foreach (var fullArgs        in fullArgsVals)
        {
            var opt = new DotNetOptions
            { 
                Dir             = dir!,            
                File            = file!,           
                BuildConf       = buildConf!, 
                Args            = extraArgs1!,
                AutoRestore     = autoRestore!,
                ParallelRestore = parallelRestore!,
                NodeReuse       = nodeReuse!,
                TimeOutSec      = timeOutSec!,
                Verbosity       = verbosity!,
                LogFile         = logFile!,
                BinLog          = binLog!,         
                LogAction       = logAction!
            };

            var args = new DotNetArgsAccessor 
            { 
                CommandEnum = commandEnum,
                Command     = command!,
                ID          = id!,
                Ver         = ver!,
                IsRebuild   = isRebuild,
                Args        = extraArgs2!,
                FullArgs    = fullArgs!
            };

            var result = NewResult(opt, args);

            bool isNully = dir            .In(NullyTexts) &&
                           file           .In(NullyTexts) &&
                           buildConf      .In(NullyTexts) &&
                           extraArgs1     .In(NullyTexts) &&
                           autoRestore    .In(NullyBools) &&
                           parallelRestore.In(NullyBools) &&
                           nodeReuse      .In(NullyBools) &&
                           timeOutSec     .In(NullyTimeOuts) &&
                           verbosity      .In(NullyVerbosities) &&
                           logFile        .In(NullyTexts) &&
                           binLog         .In(NullyTexts) &&
                           logAction      .In(NullyLogActions) &&
                           commandEnum    .In(NullyCommandEnums) &&
                           command        .In(NullyTexts) &&
                           id             .In(NullyTexts) &&
                           ver            .In(NullyTexts) &&
                           extraArgs2     .In(NullyTexts) &&
                           isRebuild      .In(NullyBools) &&
                           fullArgs       .In(NullyTexts);

            if (isNully)
            {
                AssertNully(result);
            }
            else
            {
                AssertFilled(result);
            }
        
            counter++;
        }
    
        Log($"{counter} combos checked.");
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_DotNetResult_NotNullWhen()
    {
        static DotNetResult? Get() => NewResult();

        { DotNetResult? result = Get(); if ( Has     (result )) result.ToString(); }
        { DotNetResult? result = Get(); if ( FilledIn(result )) result.ToString(); }
        { DotNetResult? result = Get(); if (!IsNully (result )) result.ToString(); }
        { DotNetResult? result = Get(); if ( result.FilledIn()) result.ToString(); }
        { DotNetResult? result = Get(); if (!result.IsNully ()) result.ToString(); }
    }
    // Helpers

    private static void AssertNully(DotNetResult? result)
    {
        IsFalse(FilledIn(result));
        IsFalse(result.FilledIn());

        IsTrue(IsNully(result));
        IsTrue(result.IsNully());

        IsFalse(Has(result));
    }

    private static void AssertFilled(DotNetResult? result)
    {
        IsTrue(FilledIn(result));
        IsTrue(result.FilledIn());

        IsFalse(IsNully(result));
        IsFalse(result.IsNully());

        IsTrue(Has(result));
    }
}

