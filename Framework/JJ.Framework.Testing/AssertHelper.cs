// ReSharper disable UnusedParameter.Local
// ReSharper disable RedundantBoolCompare

using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace JJ.Framework.Testing.Legacy
{
    /// <summary>
    /// When using AssertHelper instead of Assert,
    /// the failure message automatically includes the tested expression.
    /// It also offers methods to evaluate if the right exception goes off in the right spot
    /// with the right exception type and / or the right message.
    /// </summary>
    public static class AssertHelper
    {
        public static void ThrowsException(Action action)
        {
            if (action == null) throw new NullException(() => action);

            try
            {
                action();
            }
            catch
            {
                return;
            }

            throw new Exception("An exception should have been thrown.");
        }

        // TODO: The code below has not been reviewed (as of 2014-06-11).

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void NotEqual<T>(T a, Expression<Func<T>> bExpresion)
        {
            T b = ExpressionHelper.GetValue(bExpresion);

            if (Object.Equals(a, b))
            {
                string name = ExpressionHelper.GetText(bExpresion);
                string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetNotEqualFailedMessage(a, b, message);
                throw new Exception(fullMessage);
            }
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void AreEqual<T>(T expected, Expression<Func<T>> actualExpression)
        {
            ExpectedActualCheck((actual) => Object.Equals(expected, actual), "AreEqual", expected, actualExpression);
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void AreSame<T>(T expected, Expression<Func<T>> actualExpression)
        {
            ExpectedActualCheck((actual) => Object.ReferenceEquals(expected, actual), "AreSame", expected, actualExpression);
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void IsTrue(Expression<Func<bool>> expression)
        {
            Check(x => x == true, "IsTrue", expression);
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void IsFalse(Expression<Func<bool>> expression)
        {
            Check(x => x == false, "IsFalse", expression);
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void IsNull(Expression<Func<object>> expression)
        {
            Check(x => x == null, "IsNull", expression);
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void IsNotNull(Expression<Func<object>> expression)
        {
            Check(x => x != null, "IsNotNull", expression);
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void IsNullOrEmpty(Expression<Func<string>> expression)
        {
            Check(x => String.IsNullOrEmpty(x), "IsNullOrEmpty", expression);
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void NotNullOrEmpty(Expression<Func<string>> expression)
        {
            Check(x => !String.IsNullOrEmpty(x), "NotNullOrEmpty", expression);
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void IsOfType<T>(Expression<Func<object>> expression)
        {
            object obj = ExpressionHelper.GetValue(expression);
            if (obj == null) throw new Exception("obj cannot be null");
            Type expected = typeof(T);
            Type actual = obj.GetType();
            ExpectedActualCheck((x) => expected == actual, "IsOfType", expected, expression);
        }

        // ThrowsException Checks

        [Suppress("Trimmer", "IL2026", Justification = ExpressionsWithArrays)]
        public static void ThrowsException(Action statement, string expectedMessage)
        {
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                #pragma warning disable IL2026 // Requires unreferenced code: Trim warning only applies to Expressions with arrays.
                AreEqual(expectedMessage, () => ex.Message);
                #pragma warning restore IL2026 
                return;
            }

            throw new Exception("An exception should have been raised.");
        }

        [Suppress("Trimmer", "IL2026", Justification = ExpressionsWithArrays)]
        public static void ThrowsException(Action statement, Type exceptionType)
        {
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                #pragma warning disable IL2026 // Requires unreferenced code: Trim warning only applies to Expressions with arrays.
                AreEqual(exceptionType, () => ex.GetType());
                #pragma warning restore IL2026 
                return;
            }

            throw new Exception("An exception should have been raised.");
        }

        [Suppress("Trimmer", "IL2026", Justification = ExpressionsWithArrays)]
        public static void ThrowsException(Action statement, Type exceptionType, string expectedMessage)
        {
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                #pragma warning disable IL2026 // Requires unreferenced code: Trim warning only applies to Expressions with arrays.
                AreEqual(exceptionType, () => ex.GetType());
                AreEqual(expectedMessage, () => ex.Message);
                #pragma warning restore IL2026 
                return;
            }

            throw new Exception("An exception should have been raised.");
        }

        public static void ThrowsException<ExceptionType>(Action statement)
        {
            ThrowsException(statement, typeof(ExceptionType));
        }

        public static void ThrowsException<ExceptionType>(Action statement, string expectedMessage)
        {
            ThrowsException(statement, typeof(ExceptionType), expectedMessage);
        }

        public static void ThrowsExceptionOnOtherThread(Action statement)
        {
            bool exceptionWasThrown = false;
            Action action = new Action(() =>
            {
                try
                {
                    statement();
                }
                catch
                {
                    exceptionWasThrown = true;
                }
            });

            ThreadStart threadStart = new ThreadStart(action);
            Thread thread = new Thread(threadStart);
            thread.Start();
            thread.Join();

            if (!exceptionWasThrown)
            {
                throw new Exception("An exception should have been raised.");
            }
        }

        // Normalized Methods

        private static void ExpectedActualCheck<T>(bool condition, string methodName, T expected, T actual, string message = "")
        {
            if (!condition)
            {
                string fullMessage = GetExpectedActualMessage(methodName, expected, actual, message);
                throw new Exception(fullMessage);
            }
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        private static void ExpectedActualCheck<T>(Func<T, bool> condition, string methodName, T expected, Expression<Func<T>> actualExpression)
        {
            T actual = (T)ExpressionHelper.GetValue(actualExpression);
            if (!condition(actual))
            {
                string name = ExpressionHelper.GetText(actualExpression);
                string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetExpectedActualMessage(methodName, expected, actual, message);
                throw new Exception(fullMessage);
            }
        }

        private static void Check(bool condition, string methodName, string message)
        {
            if (!condition)
            {
                string fullMessage = GetFailureMessage(methodName, message);
                throw new Exception(fullMessage);
            }
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public static void Check<T>(Func<T, bool> condition, string methodName, Expression<Func<T>> expression)
        {
            T value = ExpressionHelper.GetValue(expression);
            if (!condition(value))
            {
                string name = ExpressionHelper.GetText(expression);
                string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetFailureMessage(methodName, message);
                throw new Exception(fullMessage);
            }
        }

        // Messages
        
        private static string GetNotEqualFailedMessage<T>(T a, T b, string message)
        {
            return
                String.Format("Assert.NotEqual failed. Both values are <{0}>.{1}{2}",
                    a != null ? a.ToString() : "null",
                    !String.IsNullOrEmpty(message) ? " " : "",
                    message);
        }

        private static string GetExpectedActualMessage<T>(string methodName, T expected, T actual, string message)
        {
            return
                String.Format("Assert.{0} failed. Expected <{1}>, Actual <{2}>.{3}{4}",
                    methodName,
                    expected != null ? expected.ToString() : "null",
                    actual != null ? actual.ToString() : "null",
                    !String.IsNullOrEmpty(message) ? " " : "",
                    message);
        }

        private static string GetFailureMessage(string methodName, string message)
        {
            return
                String.Format("Assert.{0} failed.{1}{2}",
                    methodName,
                    !String.IsNullOrEmpty(message) ? " " : "",
                    message);
        }

        private static string GetAssertFailFailedMessage(string message)
        {
            return
                String.Format("Assert failed.{0}{1}",
                    !String.IsNullOrEmpty(message) ? " " : "",
                    message);
        }
    }
}
