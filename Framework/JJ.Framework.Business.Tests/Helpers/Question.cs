namespace JJ.Framework.Business.Legacy.Tests.Helpers;

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