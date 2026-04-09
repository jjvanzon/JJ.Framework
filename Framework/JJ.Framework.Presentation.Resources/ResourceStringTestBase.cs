// Ported from "The King": legacy branch HEAD

// ReSharper disable SuggestVarOrType_Elsewhere
// ReSharper disable UnusedVariable

using static System.StringComparison;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace JJ.Framework.ResourceStrings.Legacy
{
    /// <summary>
    /// This class can be used as a base class for unit tests to run on a Resources or ResourceFormatter class.
    /// That ResourceFormatter would be be structured like CommonResourceFormatter from JJ.Framework.ResourceStrings.
    /// That means, that each public static member of the ResourceFormatter class returns a string.
    /// That string may not be null or white space. The test can switch to different cultures and repeat the checks.
    /// An unused culture is currently assumed to fall back to a default culture en-US.
    /// Some of those requirements might seem quite specific for how our ResourceFormatter classes are structured.
    /// But having this base class for tests, would allow testing integrity of
    /// some other resource formatters the same way JJ.Framework.ResourceStrings would do things.
    ///
    /// <code>
    /// An implementation might look something like:
    /// [TestClass]
    /// public class CommonResourceFormatterTests : ResourceFormatterTestsBase
    /// {
    ///   public CommonResourceFormatterTests()
    ///     : base(
    ///         typeof(CommonResourceFormatter),
    ///         knownCultureNames: [ "pl-PL", "nl-NL", "en-US" ],
    ///         unknownCultureName: "zh-CN") { }
    /// 
    ///   [TestMethod]
    ///   public void Test_CommonResourceFormatter_AllPublicMembers_ReturnText_ForKnownCultures()
    ///     =&gt; base.Test_Resources_AllPublicStatics_ReturnText_ForKnownCultures();
    /// 
    ///   [TestMethod]
    ///   public void Test_CommonResourceFormatter_UnknownCulture_DefaultsToEnUS()
    ///     =&gt; base.Test_ResourceFormatter_UnknownCulture_DefaultsToEnUS();
    /// }
    /// </code>
    /// </summary>
    public abstract class ResourceStringTestBase
    {
        private readonly IList<MemberInfo> _membersToTest;
        private readonly IList<string> _knownCultureNames;
        private readonly string _unusedCultureName;

        /// <inheritdoc cref="ResourceStringTestBase" />
        public ResourceStringTestBase(Type resourceFormatterType, string[] knownCultureNames, string unknownCultureName)
        {
            if (resourceFormatterType == null) throw new ArgumentNullException(nameof(resourceFormatterType));
            _knownCultureNames = knownCultureNames ?? throw new ArgumentNullException(nameof(knownCultureNames));
            _unusedCultureName = unknownCultureName;
            _membersToTest = GetMembersToTest(resourceFormatterType);
        }

        protected void Test_Resources_AllPublicStatics_ReturnText_ForKnownCultures()
        {
            CultureInfo originalCultureInfo = GetCurrentCulture();

            try
            {
                foreach (string cultureName in _knownCultureNames)
                {
                    SetCurrentCultureName(cultureName);

                    foreach (MemberInfo memberToTest in _membersToTest)
                    {
                        if (!IsExcluded(memberToTest))
                        {
                            string resourceText = AssertResourceText(memberToTest);
                        }
                    }
                }
            }
            finally
            {
                SetCurrentCulture(originalCultureInfo);
            }
        }

        protected virtual bool IsExcluded(MemberInfo memberToTest)
        {
            ThrowIfNull(memberToTest);

            if (string.Equals(memberToTest.Name, "Culture", OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals(memberToTest.Name, "ResourceManager", OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        protected void Test_ResourceFormatter_UnknownCulture_DefaultsToEnUS()
        {
            CultureInfo originalCultureInfo = GetCurrentCulture();

            try
            {
                const string defaultCultureName = "en-US";

                foreach (MemberInfo memberToTest in _membersToTest)
                {
                    SetCurrentCultureName(defaultCultureName);
                    string expected = AssertResourceText(memberToTest);

                    SetCurrentCultureName(_unusedCultureName);
                    string actual = AssertResourceText(memberToTest);

                    AssertHelper.AreEqual(expected, () => actual, memberToTest.Name);
                }
            }
            finally
            {
                SetCurrentCulture(originalCultureInfo);
            }
        }

        // Helpers

        private IList<MemberInfo> GetMembersToTest(Type resourceFormatterType)
        {
            var propertiesToTest = resourceFormatterType.GetProperties(BindingFlags.Static | BindingFlags.Public);
            var methodsToTest = resourceFormatterType.GetMethods(BindingFlags.Static | BindingFlags.Public)
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

        /// <summary>
        /// Aims to assert that the property is of type string and what it might return would not be null or white space.
        /// </summary>
        private static string AssertResourceText(PropertyInfo propertyInfo)
        {
            object propertyValue = propertyInfo.GetValue();
            AssertHelper.IsOfType<string>(() => propertyValue, propertyInfo.Name);
            var propertyValueString = (string)propertyValue;
            AssertHelper.NotNullOrWhiteSpace(() => propertyValueString, propertyInfo.Name);
            return propertyValueString;
        }

        /// <summary>
        /// Aims to assert that the method is of type string,
        /// it is callable with all parameters null,
        /// and what it might return would not be null or white space.
        /// </summary>
        private static string AssertResourceText(MethodInfo methodInfo)
        {
            // Supplying nulls for the parameters. Reflection seemed to turn those nulls into defaults,
            // making it work for int and decimal parameters too, which was convenient.
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
