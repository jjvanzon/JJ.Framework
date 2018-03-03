using System;
using System.Linq.Expressions;
using System.Threading;
using JJ.Framework.Exceptions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Testing
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

		// TODO: This code was ported out of a code base from 2010 to a code base from 2014, without any refactoring.
		// By attempting to normalize the methods, a lot of anti-patterns were introduced,
		// among other things delegitis, parametritis and scattering of cause and effect.

		public static void NotEqual<T>(T a, Expression<Func<T>> bExpression)
		{
			T b = ExpressionHelper.GetValue(bExpression);

			if (Equals(a, b))
			{
				string name = ExpressionHelper.GetText(bExpression);
				string message = TestHelper.FormatTestedPropertyMessage(name);
				string fullMessage = GetNotEqualFailedMessage(a, message);
				throw new Exception(fullMessage);
			}
		}

		public static void AreEqual<T>(T expected, Expression<Func<T>> actualExpression)
		{
			ExpectedActualCheck(actual => Equals(expected, actual), "AreEqual", expected, actualExpression);
		}

		public static void AreSame<T>(T expected, Expression<Func<T>> actualExpression)
		{
			ExpectedActualCheck(actual => ReferenceEquals(expected, actual), "AreSame", expected, actualExpression);
		}

		public static void IsTrue(Expression<Func<bool>> expression)
		{
			// ReSharper disable once RedundantBoolCompare
			Check(x => x == true, "IsTrue", expression);
		}

		public static void IsFalse(Expression<Func<bool>> expression)
		{
			Check(x => x == false, "IsFalse", expression);
		}

		public static void IsNull(Expression<Func<object>> expression)
		{
			Check(x => x == null, "IsNull", expression);
		}

		public static void IsNotNull(Expression<Func<object>> expression)
		{
			Check(x => x != null, "IsNotNull", expression);
		}

		public static void IsNullOrEmpty(Expression<Func<string>> expression)
		{
			Check(x => string.IsNullOrEmpty(x), "IsNullOrEmpty", expression);
		}

		public static void NotNullOrEmpty(Expression<Func<string>> expression)
		{
			Check(x => !string.IsNullOrEmpty(x), "NotNullOrEmpty", expression);
		}

		public static void IsOfType<T>(Expression<Func<object>> expression)
		{
			object obj = ExpressionHelper.GetValue(expression);
			if (obj == null) throw new Exception("obj cannot be null");
			Type expected = typeof(T);
			Type actual = obj.GetType();
			ExpectedActualCheck(x => expected == actual, "IsOfType", expected, expression);
		}

		// ThrowsException Checks

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
				AreEqual(exceptionType, () => ex.GetType());
				AreEqual(expectedMessage, () => ex.Message);
				return;
			}

			throw new Exception("An exception should have occurred.");
		}

		public static void ThrowsException<TException>(Action statement)
		{
			ThrowsException(statement, typeof(TException));
		}

		public static void ThrowsException<TException>(Action statement, string expectedMessage)
		{
			ThrowsException(statement, typeof(TException), expectedMessage);
		}

		public static void ThrowsExceptionOnOtherThread(Action statement)
		{
			bool exceptionWasThrown = false;
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

		private static void ExpectedActualCheck<T>(Func<T, bool> condition, string methodName, T expected, Expression<Func<T>> actualExpression)
		{
			T actual = ExpressionHelper.GetValue(actualExpression);
			if (!condition(actual))
			{
				string name = ExpressionHelper.GetText(actualExpression);
				string message = TestHelper.FormatTestedPropertyMessage(name);
				string fullMessage = GetExpectedActualMessage(methodName, expected, actual, message);
				throw new Exception(fullMessage);
			}
		}

		public static void Check<T>(Func<T, bool> condition, string methodName, Expression<Func<T>> expression)
		{
			if (condition == null) throw new NullException(() => condition);

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

		private static string GetNotEqualFailedMessage<T>(T a, string message) => string.Format(
			"Assert.NotEqual failed. Both values are <{0}>.{1}{2}",
			a != null ? a.ToString() : "null",
			!string.IsNullOrEmpty(message) ? " " : "",
			message);

		private static string GetExpectedActualMessage<T>(string methodName, T expected, T actual, string message) => string.Format(
			"Assert.{0} failed. Expected <{1}>, Actual <{2}>.{3}{4}",
			methodName,
			expected != null ? expected.ToString() : "null",
			actual != null ? actual.ToString() : "null",
			!string.IsNullOrEmpty(message) ? " " : "",
			message);

		private static string GetFailureMessage(string methodName, string message)
		{
			string separator = !string.IsNullOrEmpty(message) ? " " : "";

			return $"Assert.{methodName} failed.{separator}{message}";
		}
	}
}