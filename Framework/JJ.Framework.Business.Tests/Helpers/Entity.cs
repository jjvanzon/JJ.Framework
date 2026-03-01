using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Business.Legacy.Tests.Helpers
{
    internal class Entity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // ncrunch: no coverage start
        public Entity RelatedEntity { get; set; }

        public Entity QuestionType { get; set; }
        public Entity Source { get; set; }
        public IList<Entity> QuestionCategories { get; set; }
        public IList<Entity> QuestionLinks { get; set; }
        public IList<Entity> QuestionFlags { get; set; }
        // ncrunch: no coverage end
    }
}
