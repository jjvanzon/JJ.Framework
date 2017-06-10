using JetBrains.Annotations;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Validation
{
    public abstract class ValidatorBase<TRootObject> : ValidatorBase_WithoutConstructorArgumentNullCheck<TRootObject>
    {
        public ValidatorBase([NotNull] TRootObject obj)
            : base(obj)
        {
            if (obj == null) throw new NullException(() => obj);
        }
    }
}
