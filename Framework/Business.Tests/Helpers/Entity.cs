using System.Collections.Generic;

namespace JJ.Framework.Business.Tests.Helpers
{
    internal class Entity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Entity RelatedEntity { get; set; }

        public Entity QuestionType { get; set; }
        public Entity Source { get; set; }
        public IList<Entity> QuestionCategories { get; set; }
        public IList<Entity> QuestionLinks { get; set; }
        public IList<Entity> QuestionFlags { get; set; }
    }
}
