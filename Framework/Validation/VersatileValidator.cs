using JetBrains.Annotations;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Validation
{
    public abstract class VersatileValidator<TRootObject> : VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject>
    {
        public VersatileValidator([NotNull] TRootObject obj)
            : base(obj)
        {
            if (obj == null) throw new NullException(() => obj);
        }
    }
}
