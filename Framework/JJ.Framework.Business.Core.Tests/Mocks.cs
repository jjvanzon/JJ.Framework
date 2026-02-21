namespace JJ.Framework.Business.Core.Tests;

internal class Question
{
    public int ID { get; set; }
    public string Topic { get; set; } = "";
    public string Author { get; set; } = "";

    public Question? QuestionType { get; set; }
    public Question? Source { get; set; }
    public string Name { get; set; } = "";
    public IList<Category> QuestionCategories { get; set; } = new List<Category>();
    public IList<Link> QuestionLinks { get; set; } = new List<Link>();
    public IList<Flag> QuestionFlags { get; set; } = new List<Flag>();
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
        QuestionType       = new Question { ID = 2, Name = "QType" },
        Source             = new Question { ID = 3, Name = "Source" },
        QuestionCategories = [ new Category { ID = 4, Name = "Cat1" } ],
        QuestionLinks      = [ new Link { ID = 5, Name = "Link1" } ],
        QuestionFlags      = [ new Flag { ID = 6, Name = "Flag1" } ]
    };
}
