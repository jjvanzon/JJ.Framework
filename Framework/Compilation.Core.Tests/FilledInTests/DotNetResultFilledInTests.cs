// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable ReturnTypeCanBeNotNullable

namespace JJ.Framework.Compilation.Core.Tests.FilledInTests;

[TestClass]
public class DotNetResultFilledInTests
{
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
        // TODO: Finish implementing.
        return;

        foreach (var commandEnum in FilledCommandEnums.Union(NullyCommandEnums))
        foreach (var command     in FilledCommands    .Union(NullyTexts))
        foreach (var id          in FilledIDs         .Union(NullyTexts))
        foreach (var ver         in FilledVers        .Union(NullyTexts))
        foreach (var extraArgs   in FilledTexts       .Union(NullyTexts))
        foreach (var isRebuild   in FilledBools       .Union(NullyBools))
        foreach (var fullArgs    in FilledTexts       .Union(NullyTexts))
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

            var result = NewResult(args);

            bool isNully = commandEnum.In(NullyCommandEnums) &&
                           command    .In(NullyTexts) &&
                           id         .In(NullyTexts) &&
                           ver        .In(NullyTexts) &&
                           extraArgs  .In(NullyTexts) &&
                           isRebuild  .In(NullyBools) &&
                           fullArgs   .In(NullyTexts);

            if (isNully)
            {
                AssertNully(result);
            }
            else
            {
                AssertFilled(result);
            }
        }
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

