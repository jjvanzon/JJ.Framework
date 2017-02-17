using System;
using System.Linq.Expressions;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class InvalidIndexException : Exception
    {
        /// <summary> Example: "outletViewModel.Keys.OutletListIndex 1 is an invalid index for op.Outlets with count 0." </summary>
        private const string MESSAGE = "{0} {1} is an invalid index for {2} with count {3}.";

        public InvalidIndexException(Expression<Func<object>> listIndexExpression, Expression<Func<object>> countExpression)
            : base(string.Format(
                MESSAGE, 
                ExpressionHelper.GetText(listIndexExpression), 
                ExpressionHelper.GetValue(listIndexExpression), 
                StringExtensions.TrimStart(ExpressionHelper.GetText(countExpression), '.').TrimEnd('.'), 
                ExpressionHelper.GetValue(countExpression)))
        {  }
    }
}
