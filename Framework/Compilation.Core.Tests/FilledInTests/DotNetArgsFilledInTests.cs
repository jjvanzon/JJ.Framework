// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable ReturnTypeCanBeNotNullable

namespace JJ.Framework.Compilation.Core.Tests.FilledInTests;

[TestClass]
public class DotNetArgsFilledInTests
{
    [TestMethod]
    public void Test_DotNetArgs_Nully()
    {
        DotNetArgs? @null = null;
        AssertNully(@null);

        var args = new DotNetArgsAccessor();
        AssertNully(args);
    }

    [TestMethod]
    public void Test_DotNetArgs_AllPropsFilled()
    {
        AssertFilled(FilledArgs());
    }

    [TestMethod]
    public void Test_DotNetArgs_OnePropFilled()
    {
        foreach (var filled in FilledCommandEnums)
        {
            AssertFilled(new DotNetArgsAccessor { CommandEnum = filled });
        }

        foreach (var filled in FilledCommands)
        {
            AssertFilled(new DotNetArgsAccessor { Command = filled });
        }

        foreach (var filled in FilledIDs)
        {
            AssertFilled(new DotNetArgsAccessor { ID = filled });
        }

        foreach (var filled in FilledVers)
        {
            AssertFilled(new DotNetArgsAccessor { Ver = filled });
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetArgsAccessor { Args = filled });
        }

        AssertFilled(new DotNetArgsAccessor { IsRebuild = true });

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetArgsAccessor { FullArgs = filled });
        }
    }

    [TestMethod]
    public void Test_DotNetArgs_OnePropNully()
    {
        foreach (var nully in NullyCommandEnums)
        {
            var args = FilledArgs();
            AssertFilled(new DotNetArgsAccessor(args) { CommandEnum = nully });
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            AssertFilled(new DotNetArgsAccessor(args) { Command = nully! });
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            AssertFilled(new DotNetArgsAccessor(args) { ID = nully! });
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            AssertFilled(new DotNetArgsAccessor(args) { Ver = nully! });
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            AssertFilled(new DotNetArgsAccessor(args) { Args = nully! });
        }

        {
            var args = FilledArgs();
            AssertFilled(new DotNetArgsAccessor(args) { IsRebuild = false });
        }

        foreach (var nully in NullyTexts)
        {
            var args = FilledArgs();
            AssertFilled(new DotNetArgsAccessor(args) { FullArgs = nully! });
        }
    }

    [TestMethod]
    public void Test_DotNetArgs_FilledOrNot_AllCombos()
    {
        var commandEnumVals = FilledCommandEnums.Union(NullyCommandEnums).ToArray();
        var commandVals     = FilledCommands    .Union(NullyTexts).ToArray();
        var idVals          = FilledIDs         .Union(NullyTexts).ToArray();
        var verVals         = FilledVers        .Union(NullyTexts).ToArray();
        var extraArgsVals   = FilledTexts       .Union(NullyTexts).ToArray();
        var isRebuildVals   = FilledBools       .Union(NullyBools).ToArray();
        var fullArgsVals    = FilledTexts       .Union(NullyTexts).ToArray();

        int counter = 0;

        foreach (var commandEnum in commandEnumVals)
        foreach (var command     in commandVals)
        foreach (var id          in idVals)
        foreach (var ver         in verVals)
        foreach (var extraArgs   in extraArgsVals)
        foreach (var isRebuild   in isRebuildVals)
        foreach (var fullArgs    in fullArgsVals)
        {
            var args = new DotNetArgsAccessor 
            { 
                CommandEnum = commandEnum,
                Command     = command!,
                ID          = id!,
                Ver         = ver!,
                IsRebuild   = isRebuild,
                Args        = extraArgs!,
                FullArgs    = fullArgs!
            };

            bool isNully = commandEnum.In(NullyCommandEnums) &&
                           command    .In(NullyTexts) &&
                           id         .In(NullyTexts) &&
                           ver        .In(NullyTexts) &&
                           extraArgs  .In(NullyTexts) &&
                           isRebuild  .In(NullyBools) &&
                           fullArgs   .In(NullyTexts);

            if (isNully)
            {
                AssertNully(args);
            }
            else
            {
                AssertFilled(args);
            }
        
            counter++;
        }

        Log($"{counter} combos checked.");
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_DotNetArgs_NotNullWhen()
    {
        static DotNetArgs? Get() => new DotNetArgsAccessor();

        { DotNetArgs? args = Get(); if ( Has     (args )) args.ToString(); }
        { DotNetArgs? args = Get(); if ( FilledIn(args )) args.ToString(); }
        { DotNetArgs? args = Get(); if (!IsNully (args )) args.ToString(); }
        { DotNetArgs? args = Get(); if ( args.FilledIn()) args.ToString(); }
        { DotNetArgs? args = Get(); if (!args.IsNully ()) args.ToString(); }
    }
    // Helpers

    private static void AssertNully(DotNetArgs? dotNetArgs, [ArgExpress(nameof(dotNetArgs))] string expr = "")
    {
        IsFalse(FilledIn(dotNetArgs), expr);
        IsFalse(dotNetArgs.FilledIn(), expr);

        IsTrue(IsNully(dotNetArgs), expr);
        IsTrue(dotNetArgs.IsNully(), expr);

        IsFalse(Has(dotNetArgs), expr);
    }

    private static void AssertFilled(DotNetArgs? dotNetArgs, [ArgExpress(nameof(dotNetArgs))] string expr = "")
    {
        IsTrue(FilledIn(dotNetArgs), expr);
        IsTrue(dotNetArgs.FilledIn(), expr);

        IsFalse(IsNully(dotNetArgs), expr);
        IsFalse(dotNetArgs.IsNully(), expr);

        IsTrue(Has(dotNetArgs), expr);
    }
}

