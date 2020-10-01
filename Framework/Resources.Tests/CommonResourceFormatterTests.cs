using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using JJ.Framework.Common;
using JJ.Framework.Exceptions.TypeChecking;
using JJ.Framework.Reflection;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedVariable
#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace JJ.Framework.Resources.Tests
{
	[TestClass]
	public class CommonResourceFormatterTests
	{
		[TestMethod]
		public void Test_CommonResourceFormatter_AllPublicMembers_ReturnText_ForKnownCultures_EnUS_NlNL_PlPL()
		{
			CultureInfo originalCultureInfo = CultureHelper.GetCurrentCulture();

			try
			{
				var cultureNames = new[] { "pl-PL", "nl-NL", "en-US" };
				IList<MemberInfo> membersToTest = GetMembersToTest();

				foreach (string cultureName in cultureNames)
				{
					CultureHelper.SetCurrentCultureName(cultureName);

					foreach (MemberInfo memberToTest in membersToTest)
					{
						string resourceText = AssertResourceText(memberToTest);
					}
				}
			}
			finally
			{
				CultureHelper.SetCurrentCulture(originalCultureInfo);
			}
		}

		[TestMethod]
		public void Test_CommonResourceFormatter_UnknownCulture_DefaultsToEnUS()
		{
			CultureInfo originalCultureInfo = CultureHelper.GetCurrentCulture();

			try
			{
				const string defaultCultureName = "en-US";
				const string unknownCultureName = "zh-CN";

				IList<MemberInfo> membersToTest = GetMembersToTest();

				foreach (MemberInfo memberToTest in membersToTest)
				{
					CultureHelper.SetCurrentCultureName(defaultCultureName);
					string expected = AssertResourceText(memberToTest);

					CultureHelper.SetCurrentCultureName(unknownCultureName);
					string actual = AssertResourceText(memberToTest);

					AssertHelper.AreEqual(expected, () => actual, memberToTest.Name);
				}
			}
			finally
			{
				CultureHelper.SetCurrentCulture(originalCultureInfo);
			}
		}

		// Helpers

		private IList<MemberInfo> GetMembersToTest()
		{
			var propertiesToTest = typeof(CommonResourceFormatter).GetProperties(BindingFlags.Static | BindingFlags.Public);
			var methodsToTest = typeof(CommonResourceFormatter).GetMethods(BindingFlags.Static | BindingFlags.Public)
			                                                   .Where(x => !x.IsProperty());
			var membersToTest = propertiesToTest.Union<MemberInfo>(methodsToTest).OrderBy(x => x.Name).ToArray();
			return membersToTest;
		}

		private static string AssertResourceText(MemberInfo memberInfo)
		{
			switch (memberInfo)
			{
				case PropertyInfo propertyInfo:
					return AssertResourceText(propertyInfo);

				case MethodInfo methodInfo:
					return AssertResourceText(methodInfo);

				default:
					throw new UnexpectedTypeException(() => memberInfo);
			}
		}

		private static string AssertResourceText(PropertyInfo propertyInfo)
		{
			object propertyValue = propertyInfo.GetValue();
			AssertHelper.IsOfType<string>(() => propertyValue, propertyInfo.Name);
			var propertyValueString = (string)propertyValue;
			AssertHelper.NotNullOrWhiteSpace(() => propertyValueString, propertyInfo.Name);
			return propertyValueString;
		}

		private static string AssertResourceText(MethodInfo methodInfo)
		{
			// Supplying nulls (not defaults) for the parameters.
			// (This may make this test not work for int parameters for instance,
			//  but perhaps that is OK.)
			int parameterCount = methodInfo.GetParameters().Length;
			var parameters = new object[parameterCount];
			object returnValue = methodInfo.Invoke(parameters);
			AssertHelper.IsOfType<string>(() => returnValue, methodInfo.Name);
			var returnValueString = (string)returnValue;
			AssertHelper.NotNullOrWhiteSpace(() => returnValueString, methodInfo.Name);
			return returnValueString;
		}
	}
}
