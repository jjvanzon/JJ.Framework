namespace JJ.Framework.Business.Core.Tests;

internal class Entity
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public Entity? QuestionType { get; set; }
    public Entity? Source { get; set; }
    public IList<Entity> QuestionCategories { get; set; } = new List<Entity>();
    public IList<Entity> QuestionLinks { get; set; } = new List<Entity>();
    public IList<Entity> QuestionFlags { get; set; } = new List<Entity>();
}

internal static class EntityFactory
{
    public static Entity CreateSimpleEntity() => new() 
    {
        ID = 1, 
        Name = "Original" 
    };

    public static Entity CreateRichEntity() => new()
    {
        ID                 = 1,
        Name               = "Root",
        QuestionType       = new Entity{ ID = 2, Name = "QType" },
        Source             = new Entity{ ID = 3, Name = "Source" },
        QuestionCategories = [ new Entity{ ID = 4, Name = "Cat1" } ],
        QuestionLinks      = [ new Entity{ ID = 5, Name = "Link1" } ],
        QuestionFlags      = [ new Entity{ ID = 6, Name = "Flag1" } ] 
    };
}
