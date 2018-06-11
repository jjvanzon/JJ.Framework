// ReSharper disable UnusedMember.Global
#pragma warning disable 169
#pragma warning disable 649
#pragma warning disable IDE0044 // Add readonly modifier

namespace JJ.Framework.CodeAnalysis.TestCode
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
