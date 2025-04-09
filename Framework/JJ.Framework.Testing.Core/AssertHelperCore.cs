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
using static JJ.Framework.Existence.Core.FilledInHelper;
using static JJ.Framework.Testing.AssertHelper;
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

        // Partial String Comparison
                
        public static void Contains(string expectedText, string actualText)
        {
            actualText ??= "";
            expectedText ??= "";
            
            if (!actualText.Contains(expectedText, ignoreCase: true))
            {
                throw new Exception($"Message does not contain: '{expectedText}'. Full message: '{actualText}'");
            }
        }

        // ThrowsException Checks

        public static void ThrowsExceptionContaining(Action statement, params string[] expectedTexts)
        {
            if (statement == null) throw new NullException(() => statement);
            if (expectedTexts == null) throw new NullException(() => expectedTexts);
            
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                foreach (string expectedText in expectedTexts)
                {
                    Contains(expectedText, ex.Message);
                }
                
                return;
            }

            throw new Exception("An exception should have occurred.");
        }
        
        public static void ThrowsExceptionContaining(Action statement, Type exceptionType, params string[] expectedTexts)
        {
            if (statement == null) throw new NullException(() => statement);
            if (exceptionType == null) throw new NullException(() => exceptionType);
            if (expectedTexts == null) throw new NullException(() => expectedTexts);
            
            try
            {
                statement();
            }
            catch (Exception ex)
            {
                AssertHelper.AreEqual(exceptionType, () => ex.GetType());
                
                foreach (string expectedText in expectedTexts)
                {
                    Contains(expectedText, ex.Message);
                }
                
                return;
            }

            throw new Exception("An exception should have occurred.");
        }

        public static void ThrowsExceptionContaining<TException>(Action statement, params string[] expectedTexts)
            => ThrowsExceptionContaining(statement, typeof(TException), expectedTexts);
    }
}