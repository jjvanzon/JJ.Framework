using JJ.Framework.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace JJ.Framework.Testing
{
    public static class AssertExtended
    {
        public static void ThrowsException(Action action)
        {
            if (action == null) throw new ArgumentNullException("action");

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

        public static void NotEqual<T>(T a, T b, string message = "")
        {
            if (Object.Equals(a, b))
            {
                string fullMessage = GetNotEqualFailedMessage(a, b, message);
                throw new AssertFailedException(fullMessage);
            }
        }

        public static void NotEqual<T>(T a, Expression<Func<T>> bExpresion)
        {
            T b = ExpressionHelper.GetValue(bExpresion);

            if (Object.Equals(a, b))
            {
                string name = ExpressionHelper.GetText(bExpresion);
                string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetNotEqualFailedMessage(a, b, message);
                throw new AssertFailedException(fullMessage);
            }
        }

        public static void AreEqual<T>(T expected, T actual, string message = "")
        {
            ExpectedActualCheck(Object.Equals(expected, actual), "AreEqual", expected, actual, message);
        }

        public static void AreEqual<T>(T expected, Expression<Func<T>> actualExpression)
        {
            ExpectedActualCheck((actual) => Object.Equals(expected, actual), "AreEqual", expected, actualExpression);
        }

        public static void AreSame<T>(T expected, T actual, string message = "")
        {
            ExpectedActualCheck(Object.ReferenceEquals(expected, actual), "AreSame", expected, actual, message);
        }

        public static void AreSame<T>(T expected, Expression<Func<T>> actualExpression)
        {
            ExpectedActualCheck((actual) => Object.ReferenceEquals(expected, actual), "AreSame", expected, actualExpression);
        }

        public static void IsTrue(bool condition, string message = "")
        {
            Check(condition, "IsTrue", message);
        }

        public static void IsTrue(Expression<Func<bool>> expression)
        {
            Check(x => x == true, "IsTrue", expression);
        }

        public static void IsFalse(bool condition, string message = "")
        {
            Check(!condition, "IsFalse", message);
        }

        public static void IsFalse(Expression<Func<bool>> expression)
        {
            Check(x => x == false, "IsFalse", expression);
        }

        public static void IsNull(object obj, string message = "")
        {
            Check(obj == null, "IsNull", message);
        }

        public static void IsNull(Expression<Func<object>> expression)
        {
            Check(x => x == null, "IsNull", expression);
        }

        public static void IsNotNull(object obj, string message = "")
        {
            Check(obj != null, "IsNotNull", message);
        }

        public static void IsNotNull(Expression<Func<object>> expression)
        {
            Check(x => x != null, "IsNotNull", expression);
        }

        public static void Fail(string message = "")
        {
            string fullMessage = GetAssertFailFailedMessage(message);
            throw new AssertFailedException(fullMessage);
        }

        public static void ThrowsException(Action statement, string expectedMessage)
        {
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
                return;
            }

            Assert.Fail("An exception should have been raised.");
        }

        public static void ThrowsException(Action statement, Type exceptionType)
        {
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(exceptionType, ex.GetType());
                return;
            }

            Assert.Fail("An exception should have been raised.");
        }

        public static void ThrowsException(Action statement, Type exceptionType, string expectedMessage)
        {
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(exceptionType, ex.GetType());
                Assert.AreEqual(expectedMessage, ex.Message);
                return;
            }

            Assert.Fail("An exception should have been raised.");
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
                Assert.Fail("An exception should have been raised.");
            }
        }

        public static void IsNullOrEmpty(string value, string message = "")
        {
            Check(String.IsNullOrEmpty(value), "IsNullOrEmpty", message);
        }

        public static void IsNullOrEmpty(Expression<Func<string>> expression)
        {
            Check(x => String.IsNullOrEmpty(x), "IsNullOrEmpty", expression);
        }

        public static void NotNullOrEmpty(string value, string message = "")
        {
            Check(!String.IsNullOrEmpty(value), "NotNullOrEmpty", message);
        }

        public static void NotNullOrEmpty(Expression<Func<string>> expression)
        {
            Check(x => !String.IsNullOrEmpty(x), "NotNullOrEmpty", expression);
        }

        public static void IsOfType<T>(object obj, string message)
        {
            if (obj == null) throw new Exception("obj cannot be null");
            Type expected = typeof(T);
            Type actual = obj.GetType();
            ExpectedActualCheck(expected == actual, "IsOfType", expected, actual, message);
        }

        public static void IsOfType<T>(Expression<Func<object>> expression)
        {
            object obj = ExpressionHelper.GetValue(expression);
            if (obj == null) throw new Exception("obj cannot be null");
            Type expected = typeof(T);
            Type actual = obj.GetType();
            ExpectedActualCheck((x) => expected == actual, "IsOfType", expected, expression);
        }

        public static void Inconclusive(string message = null)
        {
            throw new AssertInconclusiveException(message);
        }

        // Normalized Methods

        private static void ExpectedActualCheck<T>(bool condition, string methodName, T expected, T actual, string message = "")
        {
            if (!condition)
            {
                string fullMessage = GetExpectedActualMessage(methodName, expected, actual, message);
                throw new AssertFailedException(fullMessage);
            }
        }

        private static void ExpectedActualCheck<T>(Func<T, bool> condition, string methodName, T expected, Expression<Func<T>> actualExpression)
        {
            T actual = (T)ExpressionHelper.GetValue(actualExpression);
            if (!condition(actual))
            {
                string name = ExpressionHelper.GetText(actualExpression);
                string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetExpectedActualMessage(methodName, expected, actual, message);
                throw new AssertFailedException(fullMessage);
            }
        }

        private static void Check(bool condition, string methodName, string message)
        {
            if (!condition)
            {
                string fullMessage = GetFailureMessage(methodName, message);
                throw new AssertFailedException(fullMessage);
            }
        }

        public static void Check<T>(Func<T, bool> condition, string methodName, Expression<Func<T>> expression)
        {
            T value = ExpressionHelper.GetValue(expression);
            if (!condition(value))
            {
                string name = ExpressionHelper.GetText(expression);
                string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetFailureMessage(methodName, message);
                throw new AssertFailedException(fullMessage);
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
