using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JJ.Framework.Logging.Core;
using JJ.Framework.Reflection;

namespace JJ.Framework.Testing.Core
{
    public static class AssertHelper_Copied
    {
        internal static void ExpectedActualCheck_Copied<T>(Func<T, bool> condition, string methodName, T expected, Expression<Func<T>> actualExpression, string name = null)
        {
            T actual = ExpressionHelper.GetValue(actualExpression);
            
            if (!condition(actual))
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = ExpressionHelper.GetText(actualExpression);
                }
                
                string message     = TestHelper_Copied.FormatTestedPropertyMessage(name);
                string fullMessage = GetExpectedActualMessage_Copied(methodName, expected, actual, message);
                throw new Exception(fullMessage);
            }
        }
        
        private static string GetExpectedActualMessage_Copied<T>(string methodName, T expected, T actual, string message)
            => $@"Assert.{methodName} failed. Expected <{(expected != null ? expected.ToString() : "null")}>, Actual <{(actual != null ? actual.ToString() : "null")}>.{(!string.IsNullOrEmpty(message) ? " " : "")}{message}";
        
        
        public static void ThrowsException_OrInnerException(Action statement, Type expectedExceptionType, string expectedMessage)
        {
            if (statement             == null) throw new NullException(() => statement);
            if (expectedExceptionType == null) throw new NullException(() => expectedExceptionType);
            
            string actualDescriptor = "";
            
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                bool isMatch = ex.HasExceptionOrInnerExceptionsOfType(expectedExceptionType, expectedMessage);
                if (!isMatch)
                {
                    actualDescriptor = $"Actual exception: '{ExceptionHelper_Copied.FormatExceptionWithInnerExceptions(ex, includeStackTrace: false)}'";
                }
                else
                {
                    return;
                }
            }
            
            throw new Exception($"Exception or inner exception was expected of type '{expectedExceptionType}' with message '{expectedMessage}'. {actualDescriptor}");
        }
        
        public static void ThrowsException_OrInnerException<T>(Action statement, string expectedMessage)
            => ThrowsException_OrInnerException(statement, typeof(T), expectedMessage);
    }
}