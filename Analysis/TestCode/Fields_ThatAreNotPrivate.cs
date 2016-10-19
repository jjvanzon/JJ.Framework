namespace JJ.Analysis.TestCode
{
    internal class Fields_ThatAreNotPrivate
    {
        private int _privateField;
        protected int _protectedField;

        public int _publicField;
        internal int _internalField;
        protected internal int _protectedInternalField;
    }
}
