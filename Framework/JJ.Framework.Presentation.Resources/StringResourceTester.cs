// Ported from "The King": legacy branch HEAD

#pragma warning disable IDE0016 // Join null check with assignment
#pragma warning disable IDE0059 // Unnecessary assignment of a value
// ReSharper disable UnusedVariable

using static JJ.Framework.Reflection.Legacy.ReflectionHelper;

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
    ///   public void Test_CommonResourceFormatter_AssertResources_ReturnText_ForKnownCultures()
    ///     =&gt; base.AssertAllMembers();
    /// 
    ///   [TestMethod]
    ///   public void Test_CommonResourceFormatter_UnknownCulture_DefaultsToEnUS()
    ///     =&gt; base.AssertUnknownCulture();
    /// }
    /// </code>
    /// </summary>
    public class StringResourceTester
    {
        [Dyn(PubProps|PubMethods)]
        private readonly Type _resourceClass;
        private readonly object? _resourceObject;
        private readonly string _defaultCultureName;
        private readonly string[] _knownCultureNames;
        private readonly string _unknownCultureName;
        private readonly bool _nolog;

        // Init

        // ReSharper disable once UnusedParameter.Local
        /// <inheritdoc cref="StringResourceTester" />
        public StringResourceTester(
            [Dyn(PubProps|PubMethods)] Type resourceClass, 
            string[] known, string unknown, string @default, NoLog nolog)
            : this(
                resourceClass, resourceObject: null, 
                known, unknown, @default, nolog: true)
        { }

        // ReSharper disable once UnusedParameter.Local
        /// <inheritdoc cref="StringResourceTester" />
        public StringResourceTester(
            [Dyn(PubProps|PubMethods)] Type resourceClass, object resourceObject, 
            string[] known, string unknown, string @default, NoLog nolog)
            : this(
                resourceClass, resourceObject, 
                known, unknown, @default, nolog: true)
        { }

        /// <inheritdoc cref="StringResourceTester" />
        public StringResourceTester(
            [Dyn(PubProps|PubMethods)] Type resourceClass,
            string[] known, string unknown, string @default, bool nolog = default)
            : this(
                resourceClass, null, 
                known, unknown, @default, nolog)
        { }

        /// <inheritdoc cref="StringResourceTester" />
        public StringResourceTester(
            [Dyn(PubProps|PubMethods)] Type resourceClass, object? resourceObject,
            string[] known, string unknown, string @default, bool nolog = default)
        {
            _resourceClass = resourceClass ?? throw new ArgumentNullException(nameof(resourceClass));
            _resourceObject = resourceObject;
            _defaultCultureName = @default ?? "";
            _knownCultureNames = InitKnownCultureNames(@default, known);
            _unknownCultureName = unknown ?? "";
            _nolog = nolog;
        }

        private static string[] InitKnownCultureNames(string @default, string[] known)
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

            var props = resourceClass.GetProperties(Static | Instance | Public);

            var methods = resourceClass.GetMethods(Static | Instance | Public)
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
           
            if (memberToTest.DeclaringType == typeof(object))
            {
                return false;
            }

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
        protected virtual object GetArg(ParameterInfo param)
        {
            if (param == null) throw new ArgumentNullException(nameof(param));

            return Type.GetTypeCode(param.ParameterType) switch
            {
                TypeCode.Int32    =>          101  + param.Position,
                TypeCode.Int64    =>          101l + param.Position,
                TypeCode.Decimal  =>          101m + param.Position,
                TypeCode.Double   =>          101d + param.Position,
                TypeCode.Single   =>          101f + param.Position,
                TypeCode.Int16    =>  (short)(101  + param.Position),
                TypeCode.Byte     =>   (byte)(101  + param.Position),
                TypeCode.Char     =>   (char)(101  + param.Position),
                TypeCode.SByte    =>  (sbyte)(101  + param.Position),
                TypeCode.UInt16   => (ushort)(101  + param.Position),
                TypeCode.UInt32   =>   (uint)(101  + param.Position),
                TypeCode.UInt64   =>  (ulong)(101  + param.Position),
                TypeCode.Boolean  => param.Position % 2 == 0,
                TypeCode.String   => $"arg{param.Position}",
                TypeCode.DateTime => new DateTime(2000 + param.Position, 1, 1),
                _ => throw new Exception(
                    $"Could not automatically generate value for parameter '{param.ParameterType.Name} {param.Name}' of method '{param.Member.Name}'. " +
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
        private string AssertResourceProp(PropertyInfo prop)
        {
            object? obj = !IsStatic(prop) ? _resourceObject : null;
            object val = prop.GetValue(obj);
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
            // Guard
            if (!method.IsStatic && _resourceObject == null)
            {
                throw new Exception(
                    $"Method '{method.Name}' of type '{method.DeclaringType?.Name}' " +
                    $"is not static and requires an instance.");
            }

            // Generate parameters
            ParameterInfo[] parameters = method.GetParameters();
            var args = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                args[i] = GetArg(parameters[i]);
            }

            // Call method, check result
            object ret = method.Invoke(!method.IsStatic ? _resourceObject : null, args);
            IsOfType<string>(() => ret, method.Name);
            string text = (string)ret;
            NotNullOrWhiteSpace(() => text, method.Name);

            // Check placeholders were returned
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null) continue;
                string argString = $"{args[i]}";
                if (!text!.Contains(argString))
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

        private void LogCulture(string cultureName)
        {
            Log("");
            Log($"{FormatCulture(cultureName)}:");
            Log("");
        }

        private void LogProp(PropertyInfo prop, string text) 
            => Log($"Prop {prop.Name} = {FormatText(text)} ({FormatCulture()})");

        private void LogMethod(MethodInfo method, object[] args, string text) 
            => Log($"Method {FormatMethod(method, args)} => {FormatText(text)} ({FormatCulture()})");

        private void Log(string message)
        {
            if (_nolog)
                return;

            Trace.WriteLine(message);
        }

        private static string FormatText(string text) 
            => @"""" + text + @"""";

        private static string FormatMethod(MethodInfo method, object[] args) 
            => $"{method?.Name}({Join(", ", args.Select(FormatArg))})";

        private static string FormatArg(object arg)
        {
            if (arg == null) return "null";
            if (arg is string)
            {
                return @"""" + arg + @"""";
            }
            if (arg is char)
            {
                return $"'{arg}'";
            }
            return $"{arg}";
        }

        private static string FormatCulture()
            => FormatCulture(GetCurrentCulture()?.Name);
        
        private static string FormatCulture(string cultureName) 
            => !IsNullOrEmpty(cultureName) ? cultureName : "Invariant culture";
    }
}
