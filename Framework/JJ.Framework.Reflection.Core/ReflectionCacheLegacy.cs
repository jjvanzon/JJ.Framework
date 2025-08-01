﻿using static JJ.Framework.Common.Legacy.KeyHelper;

// ReSharper disable ChangeFieldTypeToSystemThreadingLock
// ReSharper disable UseSymbolAlias
// ReSharper disable CoVariantArrayConversion

namespace JJ.Framework.Reflection.Core
{
    public class ReflectionCacheLegacy(BindingFlags _bindingFlags)
    {
        public ReflectionCacheLegacy() : this(ReflectionHelper.BINDING_FLAGS_ALL) { }
        
        // Property

        private readonly Dictionary<(Type, string), PropertyInfo?> _propertyDictionary = new();
        private readonly object _propertyDictionaryLock = new();

        public PropertyInfo GetProperty([Dyn(AllProperties)] Type type, string name)
        {
            PropertyInfo? property = TryGetProperty(type, name);
            if (property == null)
            {
                throw new Exception($"Property '{name}' not found.");
            }
            return property;
        }

        public PropertyInfo? TryGetProperty([Dyn(AllProperties)] Type type, string name)
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

        public PropertyInfo[] GetProperties([Dyn(AllProperties)] Type type)
        {
            lock (_propertiesDictionaryLock)
            {
                if (_propertiesDictionary.TryGetValue(type, out PropertyInfo[]? properties))
                {
                    return properties;
                }

                if (type == null) throw new ArgumentNullException(nameof(type));
                properties = type.GetProperties(_bindingFlags);
                _propertiesDictionary.Add(type, properties);

                return properties;
            }
        }

        // PropertyDictionaries

        private readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _propertyDictionaryDictionary = new();
        private readonly object _propertyDictionaryDictionaryLock = new();

        public Dictionary<string, PropertyInfo> GetPropertyDictionary([Dyn(AllProperties)] Type type)
        {
            lock (_propertyDictionaryDictionaryLock)
            {
                if (_propertyDictionaryDictionary.TryGetValue(type, out Dictionary<string, PropertyInfo>? propertyDictionary))
                {
                    return propertyDictionary;
                }

                if (type == null) throw new ArgumentNullException(nameof(type));
                
                propertyDictionary = type.GetProperties(_bindingFlags).ToDictionary(x => x.Name);
                _propertyDictionaryDictionary.Add(type, propertyDictionary);

                return propertyDictionary;
            }
        }

        // Field

        private readonly Dictionary<(Type, string), FieldInfo?> _fieldDictionary = new();
        private readonly object _fieldDictionaryLock = new();

        public FieldInfo GetField([Dyn(AllFields)] Type type, string name)
        {
            FieldInfo? field = TryGetField(type, name);
            if (field == null)
            {
                throw new Exception($"Field '{name}' not found.");
            }
            return field;
        }

        public FieldInfo? TryGetField([Dyn(AllFields)] Type type, string name)
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

        public FieldInfo[] GetFields([Dyn(AllFields)] Type type)
        {
            lock (_fieldsDictionaryLock)
            {
                if (_fieldsDictionary.TryGetValue(type, out FieldInfo[]? fields))
                {
                    return fields;
                }
                
                if (type == null) throw new ArgumentNullException(nameof(type));

                fields = type.GetFields(_bindingFlags);
                _fieldsDictionary.Add(type, fields);

                return fields;
            }
        }

        // Indexer

        private readonly Dictionary<(Type, string parameterTypesKey), PropertyInfo?> _indexerDictionary = new();
        private readonly object _indexerDictionaryLock = new();

        public PropertyInfo GetIndexer([Dyn(AllProperties)] Type type, params Type[] parameterTypes)
        {
            PropertyInfo? property = TryGetIndexer(type, parameterTypes);
            if (property == null)
            {
                throw new Exception($"Indexer not found with parameterTypes '{Join(", ", parameterTypes.Select(x => x.ToString()))}'.");
            }
            return property;
        }

        public PropertyInfo? TryGetIndexer([Dyn(AllProperties)] Type type, params Type[] parameterTypes)
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

        public MethodInfo GetMethod([Dyn(AllMethods)] Type type, string name, params Type[] parameterTypes)
        {
            MethodInfo? method = TryGetMethod(type, name, parameterTypes);
            if (method == null)
            {
                throw new Exception($"Method '{name}' not found.");
            }
            return method;
        }

        public MethodInfo? TryGetMethod([Dyn(AllMethods)] Type type, string name, params Type[] parameterTypes)
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

        private readonly Dictionary<(Type, string name, string parameterTypesKey, string typeArgumentsKey), MethodInfo?> _methodWithTypeArgumentsDictionary 
            = new();

        private readonly object _methodWithTypeArgumentsDictionaryLock = new();

        public MethodInfo GetMethod([Dyn(AllMethods)] Type type, string name, Type[] parameterTypes, Type[] typeArguments)
        {
            if (typeArguments == null) throw new ArgumentNullException(nameof(typeArguments));
            if (typeArguments.Length == 0) return GetMethod(type, name, parameterTypes);
            
            MethodInfo? method = TryGetMethod(type, name, parameterTypes, typeArguments);
            if (method == null)
            {
                throw new Exception(
                    $"Method '{name}' with {typeArguments.Length} type arguments not found " +
                    $"with parameters ({Join(", ", parameterTypes.Select(x => $"{x.Name}"))}) " +
                    $"in type '{type}'.");
            }
            return method;
        }

        public MethodInfo? TryGetMethod([Dyn(AllMethods)] Type type, string name, Type[] parameterTypes, Type[] typeArguments)
        {
            if (typeArguments == null) throw new ArgumentNullException(nameof(typeArguments));
            if (typeArguments.Length == 0) return TryGetMethod(type, name, parameterTypes);

            if (type == null) throw new ArgumentNullException(nameof(type));
            if (parameterTypes == null) throw new ArgumentNullException(nameof(parameterTypes));

            string parameterTypesKey = CreateKey(parameterTypes);
            string typeArgumentsKey = CreateKey(typeArguments);

            lock (_methodWithTypeArgumentsDictionaryLock)
            {
                var key = (type, name, parameterTypesKey, typeArgumentsKey);

                if (_methodWithTypeArgumentsDictionary.TryGetValue(key, out MethodInfo? method))
                {
                    return method;
                }

                method = TryResolveGenericMethod(type, name, parameterTypes, typeArguments);

                _methodWithTypeArgumentsDictionary[key] = method;

                return method;
            }
        }

        //[RequiresDynamicCode(GenericMethods)]
        //[NoTrim(GenericMethods)]
        [Suppress("Trimmer", "IL2060", Justification = "Only closed generic methods that are used can be reflected; RequiresUnreferencedCode omitted.")]
        [Suppress("Trimmer", "IL3050", Justification = "Only closed generic methods that are used can be reflected; RequiresDynamicCode omitted.")]
        private MethodInfo? TryResolveGenericMethod([Dyn(AllMethods)] Type type, string name, Type[] parameterTypes, Type[] typeArguments)
        {
            IList<MethodInfo> methods = GetMethods(type).Where(x => string.Equals(x.Name, name, Ordinal))
                                                        .Where(x => ArgTypesMatch(x, parameterTypes))
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
                        $"parameter types {Join(", ", parameterTypes.Select(x => $"'{x.Name}'"))}.");
            }
        }
       
        private bool ArgTypesMatch(MethodInfo openMethod, Type[] closedArgTypes)
        {
            Type[] openArgTypes = openMethod.GetParameters().Select(x => x.ParameterType).ToArray();
            return ArgTypesMatch(openArgTypes, closedArgTypes);
        }

        private static bool ArgTypesMatch(Type[] openArgTypes, Type[] closedArgTypes)
        {
            if (openArgTypes.Length != closedArgTypes.Length)
            {
                return false;
            }
            
            for (int i = 0; i < openArgTypes.Length; i++)
            {
                if(openArgTypes[i].IsGenericParameter)
                {
                    // Ignore generic parameters.
                    continue;
                }
                
                // Match non-generic parameters
                if (openArgTypes[i] != closedArgTypes[i])
                {
                    return false;
                }
            }
            
            return true;
        }
        
        // Methods

        private readonly Dictionary<Type, MethodInfo[]> _methodsDictionary = new();
        private readonly object _methodsDictionaryLock = new();

        public MethodInfo[] GetMethods([Dyn(AllMethods)] Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            lock (_methodsDictionaryLock)
            {
                if (_methodsDictionary.TryGetValue(type, out MethodInfo[]? methods))
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

        [NoTrim(GetTypes)]
        public Type GetTypeByShortName(string shortTypeName)
        {
            Type? type = TryGetTypeByShortName(shortTypeName);
            if (type == null)
            {
                throw new Exception($"Type with short name '{shortTypeName}' not found in the AppDomain's assemblies.");
            }
            return type;
        }

        [NoTrim(GetTypes)]
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

        [NoTrim(GetTypes)]
        public IList<Type> GetTypesByShortName(string shortTypeName)
        {
            Type[]? types;
            
            lock (_typeByShortNameDictionaryLock)
            {
                if (_typeByShortNameDictionary.TryGetValue(shortTypeName, out types))
                {
                    return types;
                }
            }

            if (IsNullOrWhiteSpace(shortTypeName))
            {
                throw new Exception($"{nameof(shortTypeName)} is null or white space.");
            }

            var stringComparison = _bindingFlags.HasFlag(IgnoreCase) ? OrdinalIgnoreCase : Ordinal;
            string trimmedName = shortTypeName.Trim();

            var list = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    list.AddRange(assembly.GetTypes().Where(x => string.Equals(x.Name, trimmedName, stringComparison) ||
                                                                 string.Equals(x.FullName, trimmedName, stringComparison) ||
                                                                 string.Equals(x.AssemblyQualifiedName, trimmedName, stringComparison)));
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

            lock (_typeByShortNameDictionaryLock)
            {
                _typeByShortNameDictionary[shortTypeName] = types;
                return types;
            }
        }

        // Constructor

        private readonly Dictionary<Type, ConstructorInfo> _constructorDictionary = new();
        private readonly object _constructorDictionaryLock = new();

        public ConstructorInfo GetConstructor([Dyn(AllConstructors)] Type type)
        {
            lock (_constructorDictionaryLock)
            {
                if (_constructorDictionary.TryGetValue(type, out ConstructorInfo? constructor))
                {
                    return constructor;
                }
                
                if (type == null) throw new ArgumentNullException(nameof(type));
                

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

        public MethodInfo GetMethod<TArg1>([Dyn(AllMethods)] Type type, string name)
            => GetMethod(type, name, [ ], [ typeof(TArg1) ]);

        public MethodInfo GetMethod<TArg1, TArg2>([Dyn(AllMethods)] Type type, string name)
            => GetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2) ]);

        public MethodInfo GetMethod<TArg1, TArg2, TArg3>([Dyn(AllMethods)] Type type, string name)
            => GetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3) ]);

        public MethodInfo GetMethod<TArg1, TArg2, TArg3, TArg4>([Dyn(AllMethods)] Type type, string name)
            => GetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) ]);

        public MethodInfo GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5>([Dyn(AllMethods)] Type type, string name)
            => GetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) ]);

        public MethodInfo GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([Dyn(AllMethods)] Type type, string name)
            => GetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) ]);

        public MethodInfo GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([Dyn(AllMethods)] Type type, string name)
            => GetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) ]);

        public MethodInfo? TryGetMethod<TArg1>([Dyn(AllMethods)] Type type, string name)
            => TryGetMethod(type, name, [ ], [ typeof(TArg1) ]);

        public MethodInfo? TryGetMethod<TArg1, TArg2>([Dyn(AllMethods)] Type type, string name)
            => TryGetMethod(type, name, [ ] , [ typeof(TArg1), typeof(TArg2) ]);

        public MethodInfo? TryGetMethod<TArg1, TArg2, TArg3>([Dyn(AllMethods)] Type type, string name)
            => TryGetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3) ]);

        public MethodInfo? TryGetMethod<TArg1, TArg2, TArg3, TArg4>([Dyn(AllMethods)] Type type, string name)
            => TryGetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) ]);

        public MethodInfo? TryGetMethod<TArg1, TArg2, TArg3, TArg4, TArg5>([Dyn(AllMethods)] Type type, string name)
            => TryGetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) ]);

        public MethodInfo? TryGetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([Dyn(AllMethods)] Type type, string name)
            => TryGetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) ]);

        public MethodInfo? TryGetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([Dyn(AllMethods)] Type type, string name)
            => TryGetMethod(type, name, [ ], [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) ]);

        public PropertyInfo GetIndexer<TArg1>([Dyn(AllProperties)] Type type)
            => GetIndexer(type, typeof(TArg1));

        public PropertyInfo GetIndexer<TArg1, TArg2>([Dyn(AllProperties)] Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3>([Dyn(AllProperties)] Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3, TArg4>([Dyn(AllProperties)] Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5>([Dyn(AllProperties)] Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([Dyn(AllProperties)] Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6));

        public PropertyInfo GetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([Dyn(AllProperties)] Type type)
            => GetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7));

        public PropertyInfo? TryGetIndexer<TArg1>([Dyn(AllProperties)] Type type)
            => TryGetIndexer(type, typeof(TArg1));

        public PropertyInfo? TryGetIndexer<TArg1, TArg2>([Dyn(AllProperties)] Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2));

        public PropertyInfo? TryGetIndexer<TArg1, TArg2, TArg3>([Dyn(AllProperties)] Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3));

        public PropertyInfo? TryGetIndexer<TArg1, TArg2, TArg3, TArg4>([Dyn(AllProperties)] Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4));

        public PropertyInfo? TryGetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5>([Dyn(AllProperties)] Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5));

        public PropertyInfo? TryGetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([Dyn(AllProperties)] Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6));

        public PropertyInfo? TryGetIndexer<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([Dyn(AllProperties)] Type type)
            => TryGetIndexer(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7));
    }
}
