// Ported from "The King": legacy branch HEAD

// ReSharper disable UnusedVariable

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace JJ.Framework.StringResources.Legacy
{
    /// <summary>
    /// This class can be used as a base class for unit tests to run on a Resources or ResourceFormatter class.
    /// That ResourceFormatter would be be structured like CommonResourceFormatter from JJ.Framework.StringResources.
    /// That means, that each public static member of the ResourceFormatter class returns a string.
    /// That string may not be null or white space. The test can switch to different cultures and repeat the checks.
    /// An unused culture is currently assumed to fall back to a default culture en-US.
    /// Some of those requirements might seem quite specific for how our ResourceFormatter classes are structured.
    /// But having this base class for tests, would allow testing integrity of
    /// some other resource formatters the same way JJ.Framework.StringResources would do things.
    ///
    /// <code>
    /// An implementation might look something like:
    /// [TestClass]
    /// public class CommonResourceFormatterTests : StringResourceTester
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
    public class StringResourceTester
    {
        [Dyn(PubProps|PubMethods)] 
        private readonly Type _resourceClass;
        private readonly string _defaultCultureName;
        private readonly string[] _knownCultureNames;
        private readonly string _unknownCultureName;

        // Init

        /// <inheritdoc cref="StringResourceTester" />
        public StringResourceTester
            ([Dyn(PubProps|PubMethods)] Type resourceClass, string[] known, string unknown, string @default)
        {
            _resourceClass = resourceClass ?? throw new ArgumentNullException(nameof(resourceClass));
            _defaultCultureName = @default ?? "";
            _knownCultureNames = PopulateKnownCultureNames(@default, known);
            _unknownCultureName = unknown ?? "";
            
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

        public void AssertAllMembers()
        {
            IList<MemberInfo> membersToTest = SelectMembersToTest(_resourceClass);

            CultureInfo saved = GetCurrentCulture();

            try
            {
                foreach (string cultureName in _knownCultureNames)
                {
                    SetCurrentCultureName(cultureName);
                    LogCulture(cultureName);

                    foreach (MemberInfo memberToTest in membersToTest)
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

        public void AssertUnknownCulture()
        {
            IList<MemberInfo> membersToTest = SelectMembersToTest(_resourceClass);

            CultureInfo saved = GetCurrentCulture();

            try
            {
                foreach (MemberInfo memberToTest in membersToTest)
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

        // Selection

        private IList<MemberInfo> SelectMembersToTest([Dyn(PubProps|PubMethods)] Type resourceClass)
        {
            if (resourceClass == null) throw new ArgumentNullException(nameof(resourceClass));

            var props = resourceClass.GetProperties(Static | Public);

            var methods = resourceClass.GetMethods(Static | Public)
                                       .Where(x => !x.IsProperty());

            var members = props.Union<MemberInfo>(methods)
                               .Where(x => Include(x))
                               .OrderBy(x => x.Name)
                               .ToArray();
            return members;
        }
              
        protected virtual bool Include(MemberInfo memberToTest)
        {
            if (memberToTest == null) throw new ArgumentNullException(nameof(memberToTest));

            if (string.Equals(memberToTest.Name, "Culture", OrdinalIgnoreCase))
            {
                return false;
            }
          
            if (string.Equals(memberToTest.Name, "ResourceManager", OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates a test value for a parameter of the given type.
        /// Override to support additional parameter types.
        /// </summary>
        protected virtual object GetArg(Type parameterType, int index)
        {
            return Type.GetTypeCode(parameterType) switch
            {
                TypeCode.Int32    =>          101  + index,
                TypeCode.Int64    =>          101l + index,
                TypeCode.Decimal  =>          101m + index,
                TypeCode.Double   =>          101d + index,
                TypeCode.Single   =>          101f + index,
                TypeCode.Int16    =>  (short)(101  + index),
                TypeCode.Byte     =>   (byte)(101  + index),
                TypeCode.Char     =>   (char)(101  + index),
                TypeCode.SByte    =>  (sbyte)(101  + index),
                TypeCode.UInt16   => (ushort)(101  + index),
                TypeCode.UInt32   =>   (uint)(101  + index),
                TypeCode.UInt64   =>  (ulong)(101  + index),
                TypeCode.Boolean  => index % 2 == 0,
                TypeCode.String   => $"Param{index}",
                TypeCode.DateTime => new DateTime(2000 + index, 1, 1),
                _ => throw new Exception(
                    $"Could not automatically generate parameter value of type '{parameterType?.Name}'. " +
                    $"Override Include or GetArg to include/exclude members or to provide a value.")
            };
        }
       
        // Assert

        private string AssertResourceText(MemberInfo member)
        {
            switch (member)
            {
                case PropertyInfo prop:
                    return AssertResourceProp(prop);

                case MethodInfo method:
                    return AssertResourceMethod(method);

                default:
                    throw new UnexpectedTypeException(() => member); // ncrunch: no coverage
            }
        }

        /// <summary>
        /// Aims to assert that the property is of type string and what it might return would not be null or white space.
        /// </summary>
        private static string AssertResourceProp(PropertyInfo prop)
        {
            object val = prop.GetValue();
            IsOfType<string>(() => val, prop.Name);
            var text = (string)val;
            NotNullOrWhiteSpace(() => text, prop.Name);
            LogProp(prop, text);
            return text;
        }

        /// <summary>
        /// Asserts that the method returns a non-empty string
        /// and that each supplied test value appears in the result.
        /// </summary>
        private string AssertResourceMethod(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            var args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                args[i] = GetArg(parameters[i].ParameterType, i);
            }

            object ret = method.Invoke(args);
            IsOfType<string>(() => ret, method.Name);
            var text = (string)ret;
            NotNullOrWhiteSpace(() => text, method.Name);

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null) continue;
                string argString = args[i].ToString();
                if (!text.Contains(argString))
                {
                    throw new Exception(
                        $"Method {method.Name}: parameter '{parameters[i].Name}' " +
                        $"value \"{argString}\" not found in result \"{text}\".");
                }
            }

            LogMethod(method, args, text);
            return text;
        }

        // Log

        private static void LogCulture(string cultureName)
        {
            Trace.WriteLine("");
            Trace.WriteLine($"{FormatCulture(cultureName)}:");
            Trace.WriteLine("");
        }

        private static void LogProp(PropertyInfo prop, string text) 
            => Trace.WriteLine($"Prop {prop.Name} = {FormatText(text)} ({FormatCulture()})");

        private static void LogMethod(MethodInfo method, object[] args, string text) 
            => Trace.WriteLine($"Method {FormatMethod(method, args)} => {FormatText(text)} ({FormatCulture()})");

        private static string FormatText(string text) 
            => @"""" + text + @"""";

        private static string FormatMethod(MethodInfo method, object[] args) 
            => $"{method?.Name}({Join(", ", args.Select(x => x?.ToString() ?? "null"))})";

        private static string FormatCulture()
            => FormatCulture(GetCurrentCulture()?.Name);
        
        private static string FormatCulture(string cultureName) 
            => !IsNullOrEmpty(cultureName) ? cultureName : "Invariant culture";
    }
}
