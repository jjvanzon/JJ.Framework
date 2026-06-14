namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetFilledInTests
{
    [TestMethod]
    public void Test_DotNetArgs_Nully()
    {
        DotNetArgs? @null = null;
        AssertNully(@null);

        var args = new DotNetArgsAccessor().Obj;
        AssertNully(args);
    }

    [TestMethod]
    public void Test_DotNetArgs_OnePropFilled()
    {
        foreach (var filled in FilledCommandEnums)
        {
            AssertFilled(new DotNetArgsAccessor { CommandEnum = filled }.Obj);
        }

        foreach (var filled in FilledCommands)
        {
            AssertFilled(new DotNetArgsAccessor { Command = filled }.Obj);
        }

        foreach (var filled in FilledIDs)
        {
            AssertFilled(new DotNetArgsAccessor { ID = filled }.Obj);
        }

        foreach (var filled in FilledVers)
        {
            AssertFilled(new DotNetArgsAccessor { Ver = filled }.Obj);
        }

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetArgsAccessor { Args = filled }.Obj);
        }

        AssertFilled(new DotNetArgsAccessor { IsRebuild = true }.Obj);

        foreach (var filled in FilledTexts)
        {
            AssertFilled(new DotNetArgsAccessor { FullArgs = filled }.Obj);
        }
    }

    [TestMethod]
    public void Test_DotNetArgs_FilledInOrNot_AllCombos()
    {
        foreach (var commandEnum in FilledCommandEnums.Union(NullyCommandEnums))
        foreach (var command     in FilledCommands    .Union(NullyTexts))
        foreach (var id          in FilledIDs         .Union(NullyTexts))
        foreach (var ver         in FilledVers        .Union(NullyTexts))
        foreach (var extraArgs   in FilledTexts       .Union(NullyTexts))
        foreach (var isRebuild   in FilledBools       .Union(NullyBools))
        foreach (var fullArgs    in FilledTexts       .Union(NullyTexts))
        {
            DotNetArgs args = new DotNetArgsAccessor 
            { 
                CommandEnum = commandEnum,
                Command     = command!,
                ID          = id!,
                Ver         = ver!,
                IsRebuild   = isRebuild,
                Args        = extraArgs!,
                FullArgs    = fullArgs!
            }.Obj;

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
        }
    }

    [TestMethod]
    public void Test_DotNetArgs_OnePropNully()
    {
        foreach (var nully in NullyCommandEnums)
        {
            var args = GetFilledDotNetArgs();
            AssertFilled(new DotNetArgsAccessor(args) { CommandEnum = nully }.Obj);
        }

        foreach (var nully in NullyTexts)
        {
            var args = GetFilledDotNetArgs();
            AssertFilled(new DotNetArgsAccessor(args) { Command = nully! }.Obj);
        }

        foreach (var nully in NullyTexts)
        {
            var args = GetFilledDotNetArgs();
            AssertFilled(new DotNetArgsAccessor(args) { ID = nully! }.Obj);
        }

        foreach (var nully in NullyTexts)
        {
            var args = GetFilledDotNetArgs();
            AssertFilled(new DotNetArgsAccessor(args) { Ver = nully! }.Obj);
        }

        foreach (var nully in NullyTexts)
        {
            var args = GetFilledDotNetArgs();
            AssertFilled(new DotNetArgsAccessor(args) { Args = nully! }.Obj);
        }

        {
            var args = GetFilledDotNetArgs();
            AssertFilled(new DotNetArgsAccessor(args) { IsRebuild = false }.Obj);
        }

        foreach (var nully in NullyTexts)
        {
            var args = GetFilledDotNetArgs();
            AssertFilled(new DotNetArgsAccessor(args) { FullArgs = nully! }.Obj);
        }
    }

    // TODO: NotNullWhen.


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

    private static DotNetArgs GetFilledDotNetArgs() => new DotNetArgsAccessor
    {
        CommandEnum = FilledCommandEnums[0],
        Command = FilledCommands[0],
        ID = FilledIDs[0],
        Ver = FilledVers[0],
        Args = FilledTexts[0],
        FullArgs = FilledTexts[0],
        IsRebuild = true,
    }.Obj;
}

