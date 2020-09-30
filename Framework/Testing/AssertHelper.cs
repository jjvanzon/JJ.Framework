using System;
using System.Linq.Expressions;
using System.Threading;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Reflection;

namespace JJ.Framework.Testing
{
    /// <summary>
    /// Compared to the Assert class this AssertHelper class aims to be clearer
    /// about the variable or expression that an error is about.
    /// Additionally it tries to offer methods that would evaluate if the expected exception goes off in the expected spot
    /// with the intended exception type and / or message.
    /// </summary>
    [PublicAPI]
    public static class AssertHelper
    {
        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void NotEqual<T>(T a, Expression<Func<T>> bExpression, string name = null)
        {
            T b = ExpressionHelper.GetValue(bExpression);

            if (Equals(a, b))
            {
	            if (string.IsNullOrWhiteSpace(name))
	            {
		            name = ExpressionHelper.GetText(bExpression);
	            }

	            string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetNotEqualFailedMessage(a, message);
                throw new Exception(fullMessage);
            }
        }

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void AreEqual<T>(T expected, Expression<Func<T>> actualExpression, string name = null)
            => ExpectedActualCheck(actual => Equals(expected, actual), "AreEqual", expected, actualExpression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void AreSame<T>(T expected, Expression<Func<T>> actualExpression, string name = null)
            => ExpectedActualCheck(actual => ReferenceEquals(expected, actual), "AreSame", expected, actualExpression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void IsTrue(Expression<Func<bool>> expression, string name = null)
	        => Check(x => x, "IsTrue", expression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void IsFalse(Expression<Func<bool>> expression, string name = null)
	        => Check(x => x == false, "IsFalse", expression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void IsNull(Expression<Func<object>> expression, string name = null)
	        => Check(x => x == null, "IsNull", expression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void IsNotNull(Expression<Func<object>> expression, string name = null)
	        => Check(x => x != null, "IsNotNull", expression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void IsNullOrEmpty(Expression<Func<string>> expression, string name = null)
	        => Check(string.IsNullOrEmpty, "IsNullOrEmpty", expression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void IsNullOrWhiteSpace(Expression<Func<string>> expression, string name = null)
	        => Check(string.IsNullOrWhiteSpace, "WhiteSpace", expression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void NotNullOrEmpty(Expression<Func<string>> expression, string name = null)
            => Check(x => !string.IsNullOrEmpty(x), "NotNullOrEmpty", expression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void NotNullOrWhiteSpace(Expression<Func<string>> expression, string name = null)
            => Check(x => !string.IsNullOrWhiteSpace(x), "NotNullOrWhiteSpace", expression, name);

        /// <param name="name">The name might be derived from the expression parameter, but this may be overridden by this name parameter.</param>
        public static void IsOfType<T>(Expression<Func<object>> expression, string name = null)
        {
            object obj = ExpressionHelper.GetValue(expression);
            if (obj == null) throw new NullException(() => obj);
            Type expected = typeof(T);

            // TODO: Beating around the bush in code seems evidence of abstraction failure.
            Type actual = obj.GetType();

            if (string.IsNullOrWhiteSpace(name))
            {
	            name = ExpressionHelper.GetName(expression);
            }

            ExpectedActualCheck(x => expected == actual, "IsOfType", expected, () => actual, name);
        }

        // ThrowsException Checks

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

        public static void ThrowsException(Action statement, string expectedMessage)
        {
            if (statement == null) throw new NullException(() => statement);

            try
            {
                statement();
            }
            catch (Exception ex)
            {
                AreEqual(expectedMessage, () => ex.Message);
                return;
            }

            throw new Exception("An exception should have occurred.");
        }

        public static void ThrowsException(Action statement, Type exceptionType)
        {
            if (statement == null) throw new NullException(() => statement);

            try
            {
                statement();
            }
            catch (Exception ex)
            {
                AreEqual(exceptionType, () => ex.GetType());
                return;
            }

            throw new Exception("An exception should have occurred.");
        }

        public static void ThrowsException(Action statement, Type exceptionType, string expectedMessage)
        {
            if (statement == null) throw new NullException(() => statement);
            if (exceptionType == null) throw new NullException(() => exceptionType);

            try
            {
                statement();
            }
            catch (Exception ex)
            {
                AreEqual(expectedMessage, () => ex.Message);
                AreEqual(exceptionType, () => ex.GetType());
                return;
            }

            throw new Exception("An exception should have occurred.");
        }

        public static void ThrowsException<TException>(Action statement) => ThrowsException(statement, typeof(TException));

        public static void ThrowsException<TException>(Action statement, string expectedMessage)
            => ThrowsException(statement, typeof(TException), expectedMessage);

        public static void ThrowsExceptionOnOtherThread(Action statement)
        {
            var exceptionWasThrown = false;

            var action = new Action(
                () =>
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

            var threadStart = new ThreadStart(action);
            var thread = new Thread(threadStart);
            thread.Start();
            thread.Join();

            if (!exceptionWasThrown)
            {
                throw new Exception("An exception should have occurred.");
            }
        }

        // Normalized Methods

        private static void ExpectedActualCheck<T>(Func<T, bool> condition, string methodName, T expected, Expression<Func<T>> actualExpression, string name = null)
        {
            T actual = ExpressionHelper.GetValue(actualExpression);

            if (!condition(actual))
            {
	            if (string.IsNullOrWhiteSpace(name))
	            {
		            name = ExpressionHelper.GetText(actualExpression);
	            }

	            string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetExpectedActualMessage(methodName, expected, actual, message);
                throw new Exception(fullMessage);
            }
        }

        public static void Check<T>(Func<T, bool> condition, string methodName, Expression<Func<T>> expression, string name = null)
        {
            if (condition == null) throw new NullException(() => condition);

            T value = ExpressionHelper.GetValue(expression);

            if (!condition(value))
            {
	            if (string.IsNullOrWhiteSpace(name))
	            {
		            name = ExpressionHelper.GetText(expression);
	            }

	            string message = TestHelper.FormatTestedPropertyMessage(name);
                string fullMessage = GetFailureMessage(methodName, message);
                throw new Exception(fullMessage);
            }
        }

        // Messages

        private static string GetNotEqualFailedMessage<T>(T a, string message)
            => $"Assert.NotEqual failed. Both values are <{(a != null ? a.ToString() : "null")}>.{(!string.IsNullOrEmpty(message) ? " " : "")}{message}";

        private static string GetExpectedActualMessage<T>(string methodName, T expected, T actual, string message)
            => $@"Assert.{methodName} failed. Expected <{(expected != null ? expected.ToString() : "null")}>, Actual <{
                    (actual != null ? actual.ToString() : "null")
                }>.{(!string.IsNullOrEmpty(message) ? " " : "")}{message}";

        private static string GetFailureMessage(string methodName, string message)
        {
            string separator = !string.IsNullOrEmpty(message) ? " " : "";

            return $"Assert.{methodName} failed.{separator}{message}";
        }
    }
}