using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using JJ.Framework.Common;
using JJ.Framework.Logging.Core;
using JJ.Framework.Logging.Core.docs;
using JJ.Framework.Reflection;
using JJ.Framework.Text.Core;
using static System.Math;
using static System.String;
using static JJ.Framework.Testing.Core.AssertHelperLegacy;
using static JJ.Framework.Testing.Core.DeltaDirectionEnum;

namespace JJ.Framework.Testing.Core
{
    public static class AssertHelperCore
    {
        /// <inheritdoc cref="_deltadirection" />
        public static void AreEqual(int expected, Expression<Func<int>> actualExpression, int delta, DeltaDirectionEnum direction = None)
        {
            // Allow negatives to trigger Downward direction automatically
            if (delta < 0 && direction == default) direction = Down;

            if (direction == None)
            {
                ExpectedActualCheckLegacy(actual => Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);
            }
            else if (direction == Up)
            {
                ExpectedActualCheckLegacy(actual => actual - expected >= 0 && Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);   
            }
            else if (direction == Down)
            {
                ExpectedActualCheckLegacy(actual => actual - expected <= 0 && Abs(actual - expected) <= Abs(delta), nameof(AreEqual), expected, actualExpression);   
            }
            else
            {
                throw new ValueNotSupportedException(direction);
            }
        }
          
        /// <inheritdoc cref="_deltadirection" />
        public static void AreEqual(double expected, Expression<Func<double>> actualExpression, double delta, DeltaDirectionEnum direction = None)
        {
            // Allow negatives to trigger Downward direction automatically
            if (delta < 0 && direction == default) direction = Down;

            if (direction == None)
            {
                ExpectedActualCheckLegacy(actual => Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);
            }
            else if (direction == Up)
            {
                ExpectedActualCheckLegacy(actual => actual - expected >= 0 && Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);   
            }
            else if (direction == Down)
            {
                ExpectedActualCheckLegacy(actual => actual - expected <= 0 && Abs(actual - expected) <= Abs(delta), nameof(AreEqual), expected, actualExpression);   
            }
            else
            {
                throw new ValueNotSupportedException(direction);
            }
        }


        // ThrowsException Checks

        public static void ThrowsExceptionThatContains(Action statement, params string[] messageContainsTexts)
        {
            if (statement == null) throw new NullException(() => statement);
            if (messageContainsTexts == null) throw new NullException(() => messageContainsTexts);
            
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                foreach (string messageContainsText in messageContainsTexts)
                {
                    AssertHelper.IsTrue(() => ex.Message.Contains(messageContainsText, true));
                }
            }

            string concatenatedMessageContains = Join(", ", messageContainsTexts.Select(x => $"'{x}'"));
            throw new Exception($"An exception should have occurred with a message containing these texts: {concatenatedMessageContains}");
        }
        
        public static void ThrowsExceptionThatContains(Action statement, Type exceptionType, params string[] messageContainsTexts)
        {
            if (statement == null) throw new NullException(() => statement);
            if (exceptionType == null) throw new NullException(() => exceptionType);
            if (messageContainsTexts == null) throw new NullException(() => messageContainsTexts);
            
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                AssertHelper.AreEqual(exceptionType, () => ex.GetType());
                foreach (string messageContainsText in messageContainsTexts)
                {
                    AssertHelper.IsTrue(() => ex.Message.Contains(messageContainsText, true));
                }
                return;
            }

            string concatenatedMessageContains = Join(", ", messageContainsTexts.Select(x => $"'{x}'"));
            throw new Exception($"An exception should have occurred of type {exceptionType.Name} and a message containing these texts: '{concatenatedMessageContains}'");
        }

        public static void ThrowsExceptionThatContains<TException>(Action statement, string messageContains)
            => ThrowsExceptionThatContains(statement, typeof(TException), messageContains);
    }
}