using static JJ.Framework.Common.KeyHelper;
// ReSharper disable ChangeFieldTypeToSystemThreadingLock

namespace JJ.Framework.Reflection
{
    public class ReflectionCache(BindingFlags _bindingFlags)
    {
        public ReflectionCache() : this(ReflectionHelper.BINDING_FLAGS_ALL) { }
        
        // Property

        private readonly Dictionary<(Type, string), PropertyInfo?> _propertyDictionary = new();
        private readonly object _propertyDictionaryLock = new();

        public PropertyInfo GetProperty(Type type, string name)
        {
            PropertyInfo? property = TryGetProperty(type, name);
            if (property == null)
            {
                throw new Exception($"Property '{name}' not found.");
            }
            return property;
        }

        public PropertyInfo? TryGetProperty(Type type, string name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            lock (_propertyDictionaryLock)
            {
                var key = (type, name);
                
                if (_propertyDictionary.TryGetValue(key, out PropertyInfo? property))
                {
                    return property;
                }

                property = type.GetProperty(name, _bindingFlags);
                _propertyDictionary[key] = property;

                return property;
            }
        }

        // Properties

        private readonly Dictionary<Type, PropertyInfo[]> _propertiesDictionary = new();
        private readonly object _propertiesDictionaryLock = new();

        public PropertyInfo[] GetProperties(Type type)
        {
            lock (_propertiesDictionaryLock)
            {
                if (_propertiesDictionary.TryGetValue(type, out PropertyInfo[]? properties))
                {
                    return properties;
                }

                properties = type.GetProperties(_bindingFlags);
                _propertiesDictionary.Add(type, properties);

                return properties;
            }
        }

        // PropertyDictionaries

        private readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _propertyDictionaryDictionary = new();
        private readonly object _propertyDictionaryDictionaryLock = new();

        public Dictionary<string, PropertyInfo> GetPropertyDictionary(Type type)
        {
            lock (_propertyDictionaryDictionaryLock)
            {
                if (_propertyDictionaryDictionary.TryGetValue(type, out Dictionary<string, PropertyInfo>? propertyDictionary))
                {
                    return propertyDictionary;
                }

                propertyDictionary = type.GetProperties(_bindingFlags).ToDictionary(x => x.Name);
                _propertyDictionaryDictionary.Add(type, propertyDictionary);

                return propertyDictionary;
            }
        }

        // Field

        private readonly Dictionary<(Type, string), FieldInfo?> _fieldDictionary = new();
        private readonly object _fieldDictionaryLock = new();

        public FieldInfo GetField(Type type, string name)
        {
            FieldInfo? field = TryGetField(type, name);
            if (field == null)
            {
                throw new Exception($"Field '{name}' not found.");
            }
            return field;
        }

        public FieldInfo? TryGetField(Type type, string name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            lock (_fieldDictionaryLock)
            {
                var key = (type, name);

                if (_fieldDictionary.TryGetValue(key, out FieldInfo? field))
                {
                    return field;
                }

                field = type.GetField(name, _bindingFlags);
                _fieldDictionary[key] = field;

                return field;
            }
        }

        // Fields

        private readonly Dictionary<Type, FieldInfo[]> _fieldsDictionary = new();
        private readonly object _fieldsDictionaryLock = new();

        public FieldInfo[] GetFields(Type type)
        {
            lock (_fieldsDictionaryLock)
            {
                if (_fieldsDictionary.TryGetValue(type, out FieldInfo[]? fields))
                {
                    return fields;
                }

                fields = type.GetFields(_bindingFlags);
                _fieldsDictionary.Add(type, fields);

                return fields;
            }
        }

        // Indexer

        private readonly Dictionary<(Type, string parameterTypesKey), PropertyInfo?> _indexerDictionary = new();
        private readonly object _indexerDictionaryLock = new();

        public PropertyInfo GetIndexer(Type type, params Type[] parameterTypes)
        {
            PropertyInfo? property = TryGetIndexer(type, parameterTypes);
            if (property == null)
            {
                throw new Exception($"Indexer not found with parameterTypes '{Join(", ", parameterTypes.Select(x => x.ToString()))}'.");
            }
            return property;
        }

        public PropertyInfo? TryGetIndexer(Type type, params Type[] parameterTypes)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (parameterTypes == null) throw new ArgumentNullException(nameof(parameterTypes));
            if (parameterTypes.Length == 0) throw new Exception("parameterTypes.Length is 0.");

            string parameterTypesKey = CreateKey(parameterTypes);

            lock (_indexerDictionaryLock)
            {
                var key = (type, parameterTypesKey);

                if (_indexerDictionary.TryGetValue(key, out PropertyInfo? property))
                {
                    return property;
                }

                var defaultMemberAttribute = (DefaultMemberAttribute?)type.GetCustomAttributes(typeof(DefaultMemberAttribute), inherit: true).SingleOrDefault();
                if (defaultMemberAttribute == null)
                {
                    return null;
                }
                string name = defaultMemberAttribute.MemberName;
                property = type.GetProperty(name, _bindingFlags, null, null, parameterTypes, null);
                _indexerDictionary[key] = property;

                return property;
            }
        }

        // Method

        private readonly Dictionary<(Type, string, string parameterTypesKey), MethodInfo?> _methodDictionary = new();
        private readonly object _methodDictionaryLock = new();

        public MethodInfo GetMethod(Type type, string name, params Type[] parameterTypes)
        {
            MethodInfo? method = TryGetMethod(type, name, parameterTypes);
            if (method == null)
            {
                throw new Exception($"Method '{name}' not found.");
            }
            return method;
        }

        public MethodInfo? TryGetMethod(Type type, string name, params Type[] parameterTypes)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (parameterTypes == null) throw new ArgumentNullException(nameof(parameterTypes));

            string parameterTypesKey = CreateKey(parameterTypes);

            lock (_methodDictionaryLock)
            {
                var key = (type, name, parameterTypesKey);

                if (_methodDictionary.TryGetValue(key, out MethodInfo? method))
                {
                    return method;
                }

                method = type.GetMethod(name, _bindingFlags, null, parameterTypes, null);
                _methodDictionary[key] = method;

                return method;
            }
        }

        // Method (with Type Arguments)

        private readonly Dictionary<(Type, string name, string parameterTypesKey, string typeArgumentsKey), MethodInfo> _methodWithTypeArgumentsDictionary 
            = new();

        private readonly object _methodWithTypeArgumentsDictionaryLock = new();

        public MethodInfo GetMethod(Type type, string name, Type[] parameterTypes, Type[] typeArguments)
        {
            MethodInfo method = TryGetMethod(type, name, parameterTypes, typeArguments);
            if (method == null)
            {
                throw new Exception(
                    $"Method '{name}' with {typeArguments.Length} type arguments not found " +
                    $"with parameters ({string.Join(", ", parameterTypes.Select(x => $"{x.Name}"))}) " +
                    $"in type '{type}'.");
            }
            return method;
        }

        public MethodInfo TryGetMethod(Type type, string name, Type[] parameterTypes, Type[] typeArguments)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (parameterTypes == null) throw new ArgumentNullException(nameof(parameterTypes));
            if (typeArguments == null) throw new ArgumentNullException(nameof(typeArguments));

            string parameterTypesKey = CreateKey(parameterTypes);
            string typeArgumentsKey = CreateKey(typeArguments);

            lock (_methodWithTypeArgumentsDictionaryLock)
            {
                var key = (type, name, parameterTypesKey, typeArgumentsKey);

                if (_methodWithTypeArgumentsDictionary.TryGetValue(key, out MethodInfo method))
                {
                    return method;
                }

                method = TryResolveGenericMethod(type, name, parameterTypes, typeArguments);

                _methodWithTypeArgumentsDictionary[key] = method;

                return method;
            }
        }

        private MethodInfo TryResolveGenericMethod(Type type, string name, Type[] parameterTypes, Type[] typeArguments)
        {
            IList<MethodInfo> methods = GetMethods(type).Where(x => string.Equals(x.Name, name))
                                                        .Where(x => x.GetParameters()
                                                                     .Select(y => y.ParameterType)
                                                                     .SequenceEqual(parameterTypes))
                                                        .ToArray();
            switch (methods.Count)
            {
                case 0:
                    return null;

                case 1:
                    MethodInfo openGenericMethod = methods[0];
                    if (openGenericMethod.GetGenericArguments().Length != typeArguments.Length)
                    {
                        return null;
                    }
                    MethodInfo closedGenericMethod = openGenericMethod.MakeGenericMethod(typeArguments);
                    return closedGenericMethod;

                default:
                    throw new Exception(
                        $"Type '{type}' appears to have multiple methods with name '{name}' and " +
                        $"parameter types {string.Join(", ", parameterTypes.Select(x => $"'{x.Name}'"))}.");
            }
        }

        // Methods

        private readonly Dictionary<Type, MethodInfo[]> _methodsDictionary = new();
        private readonly object _methodsDictionaryLock = new();

        public MethodInfo[] GetMethods(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            lock (_methodsDictionaryLock)
            {
                if (_methodsDictionary.TryGetValue(type, out MethodInfo[] methods))
                {
                    return methods;
                }

                methods = type.GetMethods(_bindingFlags);
                _methodsDictionary[type] = methods;

                return methods;
            }
        }

        // Types

        private readonly Dictionary<string, Type[]> _typeByShortNameDictionary = new();
        private readonly object _typeByShortNameDictionaryLock = new();

        public Type GetTypeByShortName(string shortTypeName)
        {
            Type? type = TryGetTypeByShortName(shortTypeName);
            if (type == null)
            {
                throw new Exception($"Type with short name '{shortTypeName}' not found in the AppDomain's assemblies.");
            }
            return type;
        }

        public Type? TryGetTypeByShortName(string shortTypeName)
        {
            IList<Type> types = GetTypesByShortName(shortTypeName);

            switch (types.Count)
            {
                case 1:
                    return types[0];

                case 0:
                    return null;

                default:
                    throw new Exception(
                        $"Type with short name '{shortTypeName}' found multiple times in the AppDomain's assemblies. " + 
                        $"Found types:{Environment.NewLine}{Join(Environment.NewLine, types.Select(x => x.FullName))}");
            }
        }

        public IList<Type> GetTypesByShortName(string shortTypeName)
        {
            Type[]? types;
            
            lock (_typeByShortNameDictionaryLock)
            {
                if (_typeByShortNameDictionary.TryGetValue(shortTypeName, out types))
                {
                    return types;
                }

                var list = new List<Type>();
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        list.AddRange(assembly.GetTypes().Where(x => string.Equals(x.Name, shortTypeName)));
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        // Ignore.
                        // TODO: Learn why types of some assemblies cannot be retrieved,
                        // and why it says the assembly cannot be loaded (file not found),
                        // while it clearly is part of the app domain.
                    }
                }
                types = list.ToArray();

                _typeByShortNameDictionary.Add(shortTypeName, types);
                return types;
            }
        }

        // Constructor

        private readonly Dictionary<Type, ConstructorInfo> _constructorDictionary = new();
        private readonly object _constructorDictionaryLock = new();

        public ConstructorInfo GetConstructor(Type type)
        {
            lock (_constructorDictionaryLock)
            {
                if (_constructorDictionary.TryGetValue(type, out ConstructorInfo? constructor))
                {
                    return constructor;
                }

                IList<ConstructorInfo> constructors = type.GetConstructors(_bindingFlags);
                switch (constructors.Count)
                {
                    case 1:
                        _constructorDictionary.Add(type, constructors[0]);
                        return constructors[0];

                    case 0:
                        throw new Exception($"No constructor found for type '{type.FullName}' for '{new { _bindingFlags}}'.");

                    default:
                        throw new Exception(
                            $"Multiple constructors found on type '{type.FullName}' for '{new { _bindingFlags }}'. " +
                            $"Found constructors: {Join(", ", constructors)}");
                }
            }
        }

        // Generic Overloads

        public MethodInfo GetMethod<TArg1>(Type type, string name)
            => GetMethod(type, name, typeof(TArg1));

        public MethodInfo GetMethod<TArg1, TArg2>(Type type, string name)
            => GetMethod(type, name, typeof(TArg1), typeof(TArg2));

        public MethodInfo GetMethod<TArg1, TArg2, TArg3>(Type type, string name)
            => GetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3));

        public MethodInfo GetMethod<TArg1, TArg2, TArg3, TArg4>(Type type, string name)
            => GetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4));

        public MethodInfo GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(Type type, string name)
            => GetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5));

        public MethodInfo GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Type type, string name)
            => GetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6));

        public MethodInfo GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Type type, string name)
            => GetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7));

        public MethodInfo TryGetMethod<TArg1>(Type type, string name)
            => TryGetMethod(type, name, typeof(TArg1));

        public MethodInfo TryGetMethod<TArg1, TArg2>(Type type, string name)
            => TryGetMethod(type, name, typeof(TArg1), typeof(TArg2));

        public MethodInfo TryGetMethod<TArg1, TArg2, TArg3>(Type type, string name)
            => TryGetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3));

        public MethodInfo TryGetMethod<TArg1, TArg2, TArg3, TArg4>(Type type, string name)
            => TryGetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4));

        public MethodInfo TryGetMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(Type type, string name)
            => TryGetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5));

        public MethodInfo TryGetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Type type, string name)
            => TryGetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6));

        public MethodInfo TryGetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Type type, string name)
            => TryGetMethod(type, name, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7));

        public PropertyInfo GetIndexer<TArg1>(Type type)
            => GetIndexer(type, typeof(TArg1));

        public PropertyInfo GetIndexer<TArg1, TArg2>(Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3>(Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3, TArg4>(Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5>(Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7));

        public PropertyInfo TryGetIndexer<TArg1>(Type type)
            => TryGetIndexer(type, typeof(TArg1));

        public PropertyInfo TryGetIndexer<TArg1, TArg2>(Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2));

        public PropertyInfo TryGetIndexer<TArg1, TArg2, TArg3>(Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3));

        public PropertyInfo TryGetIndexer<TArg1, TArg2, TArg3, TArg4>(Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4));

        public PropertyInfo TryGetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5>(Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5));

        public PropertyInfo TryGetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6));

        public PropertyInfo TryGetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7));
    }
}
