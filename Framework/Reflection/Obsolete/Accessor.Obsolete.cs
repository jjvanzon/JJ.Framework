using System;
using System.Linq.Expressions;
// ReSharper disable CheckNamespace

namespace JJ.Framework.Reflection
{
    public partial class Accessor
    {
        private const string INVOKE_METHOD_OBSOLETE_MESSAGE = "Use another overload instead. Parameters might not need to be specified, and may be put in the lambda expression instead. Or use an overload takes a string name possibly using nameof().";

        [Obsolete(INVOKE_METHOD_OBSOLETE_MESSAGE, true)]
        public void InvokeMethod(Expression<Action> nameExpression, params object[] parameters)
            => throw new NotSupportedException(INVOKE_METHOD_OBSOLETE_MESSAGE);

        [Obsolete(INVOKE_METHOD_OBSOLETE_MESSAGE, true)]
        public T InvokeMethod<T>(Expression<Func<T>> nameExpression, params object[] parameters)
            => throw new NotSupportedException(INVOKE_METHOD_OBSOLETE_MESSAGE);

        [Obsolete(INVOKE_METHOD_OBSOLETE_MESSAGE, true)]
        public object InvokeMethod(LambdaExpression nameExpression, params object[] parameters)
            => throw new NotSupportedException(INVOKE_METHOD_OBSOLETE_MESSAGE);
    }
}
