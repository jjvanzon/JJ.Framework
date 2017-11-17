//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//    public class InvalidTypeException : Exception
//    {
//        private const string MESSAGE = "{0} is not of type {1}.";

//        public override string Message { get; }

//        public InvalidTypeException(Expression<Func<object>> expression, Type type)
//        {
//            if (type == null) throw new NullException(() => type);

//            Message = string.Format(MESSAGE, ExpressionHelper.GetText(expression), type.FullName);
//        }

//        public InvalidTypeException(Expression<Func<object>> expression, string typeName)
//        {
//            Message = string.Format(MESSAGE, ExpressionHelper.GetText(expression), typeName);
//        }
//    }
//}