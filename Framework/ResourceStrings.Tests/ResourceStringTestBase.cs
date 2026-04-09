// Ported from "The King": legacy branch HEAD

// ReSharper disable UnusedVariable


#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace JJ.Framework.ResourceStrings.Tests
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
    /// public class CommonResourceFormatterTests : ResourceStringTester
    /// {
    ///   public CommonResourceFormatterTests()
    ///     : base(
    ///         typeof(CommonResourceFormatter),
    ///         @default: "en-US",
    ///         known: [ "pl-PL", "nl-NL" ],
    ///         unknown: "zh-CN") { }
    /// 
    ///   [TestMethod]
    ///   public void Test_CommonResourceFormatter_AllPublicMembers_ReturnText_ForKnownCultures()
    ///     =&gt; base.Assert_AllPublicStatics_ReturnText_ForKnownCultures();
    /// 
    ///   [TestMethod]
    ///   public void Test_CommonResourceFormatter_UnknownCulture_DefaultsToEnUS()
    ///     =&gt; base.Assert_UnknownCulture_UsesDefaultCulture();
    /// }
    /// </code>
    /// </summary>
    public class ResourceStringTester
    {
        private readonly IList<MemberInfo> _membersToTest;
        private readonly string _defaultCultureName;
        private readonly string[] _knownCultureNames;
        private readonly string _unknownCultureName;

        // Init

        /// <inheritdoc cref="ResourceStringTester" />
        public ResourceStringTester
            (Type resourceClass, string[] known, string unknown, string @default)
        {
            if (resourceClass == null) throw new ArgumentNullException(nameof(resourceClass));
            _defaultCultureName = @default ?? "";
            _knownCultureNames = PopulateKnownCultureNames(@default, known);
            _unknownCultureName = unknown ?? "";
            _membersToTest = SelectMembersToTest(resourceClass);
        }

        private static string[] PopulateKnownCultureNames(string @default, string[] known)
        {
            if (known == null) throw new ArgumentNullException(nameof(known));

            var hash = new HashSet<string> { @default ?? "" };

            foreach (string knownCultureName in known)
            {
                hash.Add(knownCultureName ?? "");
            }

            return hash.ToArray();
        }

        // Test

        public void Assert_AllPublicStatics_ReturnText_ForKnownCultures()
        {
            CultureInfo saved = GetCurrentCulture();

            try
            {
                foreach (string cultureName in _knownCultureNames)
                {
                    SetCurrentCultureName(cultureName);
                    LogCulture(cultureName);

                    foreach (MemberInfo memberToTest in _membersToTest)
                    {
                        string resourceText = AssertResourceText(memberToTest);
                    }
                }
            }
            finally
            {
                SetCurrentCulture(saved);
            }
        }

        public void Assert_UnknownCulture_UsesDefaultCulture()
        {
            CultureInfo saved = GetCurrentCulture();

            try
            {
                foreach (MemberInfo memberToTest in _membersToTest)
                {
                    SetCurrentCultureName(_defaultCultureName);
                    string expected = AssertResourceText(memberToTest);

                    SetCurrentCultureName(_unknownCultureName);
                    string actual = AssertResourceText(memberToTest);

                    AreEqual(expected, () => actual, memberToTest.Name);
                }
            }
            finally
            {
                SetCurrentCulture(saved);
            }
        }

        // Select

        protected virtual IList<MemberInfo> SelectMembersToTest(Type resourceClass)
        {
            var props = resourceClass.GetProperties(Static | Public);

            var methods = resourceClass.GetMethods(Static | Public)
                                       .Where(x => !x.IsProperty());

            var members = props.Union<MemberInfo>(methods)
                               .Where(x => !IsExcluded(x))
                               .OrderBy(x => x.Name)
                               .ToArray();
            return members;
        }
              
        protected virtual bool IsExcluded(MemberInfo memberToTest)
        {
            if (memberToTest == null) throw new ArgumentNullException(nameof(memberToTest));

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

        // Assert

        private static string AssertResourceText(MemberInfo member)
        {
            switch (member)
            {
                case PropertyInfo prop:
                    return AssertResourceText(prop);

                case MethodInfo method:
                    return AssertResourceText(method);

                default:
                    throw new UnexpectedTypeException(() => member); // ncrunch: no coverage
            }
        }

        /// <summary>
        /// Aims to assert that the property is of type string and what it might return would not be null or white space.
        /// </summary>
        private static string AssertResourceText(PropertyInfo prop)
        {
            object val = prop.GetValue();
            IsOfType<string>(() => val, prop.Name);
            var text = (string)val;
            NotNullOrWhiteSpace(() => text, prop.Name);
            LogProp(prop, text);
            return text;
        }

        /// <summary>
        /// Aims to assert that the method is of type string,
        /// it is callable with all parameters null,
        /// and what it might return would not be null or white space.
        /// </summary>
        private static string AssertResourceText(MethodInfo method)
        {
            // Supplying nulls for the parameters. Reflection seemed to turn those nulls into defaults,
            // making it work for int and decimal parameters too, which was convenient.
            int parameterCount = method.GetParameters().Length;
            var parameters = new object[parameterCount];
            object ret = method.Invoke(parameters);
            IsOfType<string>(() => ret, method.Name);
            var text = (string)ret;
            NotNullOrWhiteSpace(() => text, method.Name);
            LogMethod(method, text);
            return text;
        }

        // Log

        private static void LogCulture(string cultureName)
        {
            Trace.WriteLine("");
            Trace.WriteLine($"{FormatCultureName(cultureName)}:");
            Trace.WriteLine("");
        }

        private static string FormatCultureName(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName)) 
            {
                return "Invariant culture";
            }
            return cultureName;
        }

        private static void LogProp(PropertyInfo prop, string text)
        {
            Trace.WriteLine($"Prop {prop.Name} = \"{text}\" ({FormatCultureName(GetCurrentCulture()?.Name)})");
            //Trace.WriteLine(@$"Prop {prop.Name} = ""{text}""");
        }

        private static void LogMethod(MethodInfo method, string text)
        {
            Trace.WriteLine($"Method {method.Name}({string.Join(", ", method.GetParameters().Select(x => x.Name))}) => \"{text}\" ({FormatCultureName(GetCurrentCulture()?.Name)})");
            //Trace.WriteLine(@$"Prop {prop.Name} = ""{text}""");
        }

        /*
        private static void LogEmptyLine()
        { 
            Trace.WriteLine("");
        }
        */
    }
}
