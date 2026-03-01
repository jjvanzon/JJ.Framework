namespace JJ.Framework.Business.Tests.Helpers;

internal static class EntityFactory
{
    public static Question CreateEmptyQuestion() => new()
    {
        ID = 1,
        Name = ""
    };

    public static Question CreateSimpleQuestion() => new()
    {
        ID = 1,
        Name = "Original"
    };

    public static Question CreateRichQuestion() => new()
    {
        ID                 = 1,
        Name               = "Root",
        Topic              = "Topic",
        Author             = "Author",
        QuestionType       = new QuestionType { ID = 2, Name = "QType"  },
        Source             = new Source       { ID = 3, Name = "Source" },
        QuestionCategories = [ new Category   { ID = 4, Name = "Cat1"  } ],
        QuestionLinks      = [ new Link       { ID = 5, Name = "Link1" } ],
        QuestionFlags      = [ new Flag       { ID = 6, Name = "Flag1" } ]
    };
}