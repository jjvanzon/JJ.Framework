using JJ.Framework.Existence.Core;

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetFilledInTests
{
    [TestMethod]
    public void Test_DotNetArgs_Nully_Null()
    {
        DotNetArgs? @null = null;
        AssertNully(@null);
    }

    [TestMethod]
    public void Test_DotNetArgs_Nully_New()
    {
        var args = new DotNetArgsAccessor().Obj;
        AssertNully(args);
    }

    [TestMethod]
    public void Test_DotNetArgs_Nully_IsRebuildFalse() 
        => AssertNully(new DotNetArgsAccessor { IsRebuild = false }.Obj);

    // TODO: Start with fully filled, and set one prop at a time.
    [TestMethod]
    public void Test_DotNetArgs_Nully_CommandEnum()
    {
        foreach (var nully in NullyCommandEnums)
        {
            AssertNully(new DotNetArgsAccessor { CommandEnum = nully }.Obj);
        }
    }

    // One Prop Filled

    [TestMethod]
    public void Test_DotNetArgs_Filled_CommandEnum()
    {
        foreach (var filled in FilledCommandEnums)
        {
            AssertFilled(new DotNetArgsAccessor { CommandEnum = filled }.Obj);
        }
    }

    [TestMethod]
    public void Test_DotNetArgs_Filled_Command()
    {
        foreach (var filled in FilledCommands)
        {
            AssertFilled(new DotNetArgsAccessor { Command = filled }.Obj);
        }
    }

    [TestMethod]
    public void Test_DotNetArgs_Filled_ID()
    {
        foreach (var filled in FilledIDs)
        {
            AssertFilled(new DotNetArgsAccessor { ID = filled }.Obj);
        }
    }

    [TestMethod]
    public void Test_DotNetArgs_Filled_Vers()
    {
        foreach (var filled in FilledVers)
        {
            AssertFilled(new DotNetArgsAccessor { Ver = filled }.Obj);
        }
    }

    [TestMethod]
    public void Test_DotNetArgs_Filled_IsRebuild()
    {
        AssertFilled(new DotNetArgsAccessor { IsRebuild = true }.Obj);
    }

    [TestMethod]
    public void Test_DotNetArgs_Filled_FullArgs()
    {
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
                FullArgs    = fullArgs!
            }.Obj;

            bool isNully = commandEnum.In(NullyCommandEnums) &&
                           command    .In(NullyTexts) &&
                           id         .In(NullyTexts) &&
                           ver        .In(NullyTexts) &&
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




    // TODO: NotNullWhen.

    // Helpers

    private static void AssertNully(DotNetArgs? dotNetArgs)
    {
        IsFalse(FilledIn(dotNetArgs));
        IsFalse(dotNetArgs.FilledIn());

        IsTrue(IsNully(dotNetArgs));
        IsTrue(dotNetArgs.IsNully());

        IsFalse(Has(dotNetArgs));
    }

    private static void AssertFilled(DotNetArgs? dotNetArgs)
    {
        IsTrue(FilledIn(dotNetArgs));
        IsTrue(dotNetArgs.FilledIn());

        IsFalse(IsNully(dotNetArgs));
        IsFalse(dotNetArgs.IsNully());

        IsTrue(Has(dotNetArgs));
    }
}

