// Ported from "The King": legacy branch HEAD

#pragma warning disable CS0078 // The 'l' suffix is easily confused with the digit '1'
#pragma warning disable IDE0016 // Join null check with assignment
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0060 // nolog param "unused"
// ReSharper disable UnusedVariable
// ReSharper disable UnusedParameter.Local
// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault

namespace JJ.Framework.StringResources.Legacy
{
    /// <inheritdoc cref="_stringresourcetester" />
    public class StringResourceTester
    {
        [Dyn(PubPropMethod)]
        private readonly Type _resourceClass;
        private readonly object? _resourceObject;
        private readonly string _defaultCultureName;
        private readonly string[] _knownCultureNames;
        private readonly string _unknownCultureName;
        private readonly bool _nolog;

        // Init

        /// <inheritdoc cref="_stringresourcetester" />
        public StringResourceTester(
            [Dyn(PubPropMethod)] Type resourceClass, 
            string[] known, string unknown, string @default, NoLog nolog)
            : this(
                resourceClass, resourceObject: null, 
                known, unknown, @default, nolog: true)
        { }

        /// <inheritdoc cref="_stringresourcetester" />
        public StringResourceTester(
            [Dyn(PubPropMethod)] Type resourceClass, object resourceObject, 
            string[] known, string unknown, string @default, NoLog nolog)
            : this(
                resourceClass, resourceObject, 
                known, unknown, @default, nolog: true)
        { }

        /// <inheritdoc cref="_stringresourcetester" />
        public StringResourceTester(
            [Dyn(PubPropMethod)] Type resourceClass,
            string[] known, string unknown, string @default, bool nolog = default)
            : this(
                resourceClass, null, 
                known, unknown, @default, nolog)
        { }

        /// <inheritdoc cref="_stringresourcetester" />
        public StringResourceTester(
            [Dyn(PubPropMethod)] Type resourceClass, object? resourceObject,
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

        /// <inheritdoc cref="_assertallmembers" />
        public void AssertResourceMembers()
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

        /// <inheritdoc cref="_assertunknownculturefallback" />
        public void AssertCultureFallback()
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

                    if (!string.Equals(expected, actual, OrdinalIgnoreCase))
                    {
                        throw new Exception(
                            $"{memberToTest.Name} should return '{expected}', but instead returned '{actual}'.");
                    }
                }
            }
            finally
            {
                SetCurrentCulture(saved);
            }
        }

        // Selection

        private IList<MemberInfo> SelectMembersToTest([Dyn(PubPropMethod)] Type resourceClass)
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
        
        /// <inheritdoc cref="_include" />
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

        /// <inheritdoc cref="_getarg" />
        protected virtual object GetArg(ParameterInfo param)
        {
            if (param == null) throw new ArgumentNullException(nameof(param));

            return Type.GetTypeCode(param.ParameterType) switch
            {
                TypeCode.Int32   =>          100  + param.Position,
                TypeCode.Int64   =>          100l + param.Position,
                TypeCode.Decimal =>          100m + param.Position,
                TypeCode.Double  =>          100d + param.Position,
                TypeCode.Single  =>          100f + param.Position,
                TypeCode.Int16   =>  (short)(100  + param.Position),
                TypeCode.Byte    =>   (byte)(100  + param.Position),
                TypeCode.Char    =>   (char)(100  + param.Position),
                TypeCode.SByte   =>  (sbyte)(100  + param.Position),
                TypeCode.UInt16  => (ushort)(100  + param.Position),
                TypeCode.UInt32  =>   (uint)(100  + param.Position),
                TypeCode.UInt64  =>  (ulong)(100  + param.Position),
                TypeCode.Boolean => param.Position % 2 == 0,
                TypeCode.String  => $"arg{param.Position}",
                _ => throw new Exception(
                    $"Failed to generate value for parameter " +
                    $"'{param.Name}' of type '{param.ParameterType.Name}' for method '{param.Member.Name}'. " +
                    $"Override Include or GetArg to include/exclude members or to provide a value explicitly.")
            };
        }
       
        // Assert

        /// <inheritdoc cref="_assertresourcetext" />
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

        /// <inheritdoc cref="_assertresourceprop" />
        private string AssertResourceProp(PropertyInfo prop)
        {
            var isStatic = IsStatic(prop);
            object? obj = TryGetResourceObject(isStatic, prop);
            object val = prop.GetValue(obj);
            string text = AssertReturnsText(prop, val);
            LogProp(prop, text);
            return text;
        }

        /// <inheritdoc cref="_assertresourcemethod" />
        private string AssertResourceMethod(MethodInfo method)
        {
            // Generate arguments
            ParameterInfo[] parameters = method.GetParameters();
            var args = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                args[i] = GetArg(parameters[i]);
            }

            // Call method, basic result check
            object? obj = TryGetResourceObject(method.IsStatic, method);
            object ret = method.Invoke(obj, args) ?? "";
            string text = AssertReturnsText(method, ret);

            // Log result
            LogMethod(method, args, text);

            // Check unresolved placeholders
            if (IsMatch(text!, "{\\d+(:[^}]+)?}"))
            {
                throw new Exception(
                    $"{FormatMethod(method, args)} has unresolved placeholders: \"{text}\".");
            }
            
            // Check args are in text
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null) continue;
                string argString = $"{args[i]}";
                if (!text.Contains(argString))
                {
                    throw new Exception(
                        $"Parameter {parameters[i].Name} = \"{argString}\" not found in text \"{text}\" " +
                        $"returned by method {FormatMethod(method, args)}.");
                }
            }

            return text;
        }

        /// <inheritdoc cref="_assertreturnstext" />
        private static string AssertReturnsText(MemberInfo member, object ret)
        {
            var returnType = ret.GetType();
            if (returnType != typeof(string))
            {
                throw new Exception(
                    $"'{member.Name}' from '{member.DeclaringType?.Name}' " +
                    $"should return string but instead it returned: '{returnType}'");
            }

            var text = (string)ret;
            if (IsNullOrWhiteSpace(text)) 
            {
                throw new Exception(member.Name + " is null or white space.");
            }

            return text;
        }

        // Helpers

        /// <inheritdoc cref="_trygetresourceobject" />
        private object? TryGetResourceObject(bool isStatic, MemberInfo member)
        {
            if (isStatic) return null;

            if (_resourceObject == null)
            {
                throw new Exception(
                    $"'{member.Name}' from '{member.DeclaringType?.Name}' " +
                    $"requires an object. Please pass one to the '{nameof(StringResourceTester)}' constructor.");
            }

            return _resourceObject;
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
