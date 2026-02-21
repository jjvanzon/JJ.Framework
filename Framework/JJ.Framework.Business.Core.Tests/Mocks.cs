// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace JJ.Framework.Business.Core.Tests;

internal class Question
{
    public int ID { get; set; }
    public string Topic { get; set; } = "";
    public string Author { get; set; } = "";

    public QuestionType? QuestionType { get; set; }
    public Source? Source { get; set; }
    public string Name { get; set; } = "";
    public IList<Category> QuestionCategories { get; set; } = new List<Category>();
    public IList<Link> QuestionLinks { get; set; } = new List<Link>();
    public IList<Flag> QuestionFlags { get; set; } = new List<Flag>();
}

internal class QuestionType
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
}

internal class Source
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
}

internal class Category
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
}

internal class Link
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
}

internal class Flag
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
}

internal class ViewModel
{
    public int Key { get; set; }
    public string? Name { get; set; }
}

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
