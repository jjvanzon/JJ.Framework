namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal abstract class DerivedClassAccessorBase : IDerivedClassAccessor
    {
        protected readonly Accessor _accessor;
        protected readonly Accessor _baseAccessor;

        public DerivedClassAccessorBase(DerivedClass obj)
        {
            _accessor = new Accessor(obj);
            _baseAccessor = new Accessor(obj, typeof(Class));
        }

        public abstract int MemberToHide { get; set; }
        public abstract int Base_MemberToHide { get; set; }
    }
}
