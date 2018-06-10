using JetBrains.Annotations;

namespace JJ.Framework.Data.Tests.Model
{
    [UsedImplicitly]
    public class Thing
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }
}