using JetBrains.Annotations;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Validation
{
    public abstract class VersatileValidator<TRootObject> : VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject>
    {
        /// <param name="postponeExecute">
        /// When set to true, you can do initializations in your constructor
        /// before Execute goes off. If so, then you have to call Execute in your own constructor.
        /// </param>
        public VersatileValidator([NotNull] TRootObject obj, bool postponeExecute = false)
            : base(obj, postponeExecute: true)
        {
            if (obj == null) throw new NullException(() => obj);

            if (!postponeExecute)
            {
                // ReSharper disable once VirtualMemberCallInConstructor
                Execute();
            }
        }

        [NotNull]
        // ReSharper disable once AssignNullToNotNullAttribute
        public override TRootObject Obj => base.Obj;
    }
}
