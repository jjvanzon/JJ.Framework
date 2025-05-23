        
        //public VersatileLogger(LogConfig config)
        //{
        //    if (config == null) throw new NullException(() => config);
        //    if (config.Logs == null) throw new NullException(() => config.Logs);
            
        //    // TODO: Move this to factory, so you can return different instances based on configuration?

        //    var loggerConfigs = config.Logs.Where(x => x.Active ?? DefaultActive).ToArray();
            
        //    int count = loggerConfigs.Length;
            
        //    _loggers = new ILogger[count];
            
        //    for (int i = 0; i < count; i++)
        //    {
        //        _loggers[i] = CreateLogger(config.Logs[i].Type);
        //    }   
        //}

        //public static ILogger CreateLogger(LogConfig config)
        //{
        //    if (config == null) throw new NullException(() => config);
            
        //    if (!config.Active ?? DefaultActive)
        //    {
        //        return new EmptyLogger();
        //    }
            
        //    ILogger logger = new VersatileLogger(config);
        //    return logger;
        //}

            lock (_loggerTypeDictionaryLock)
            {
                if (_loggerTypeDictionary.TryGetValue(name, out Type type))
                {
                    return CreateLogger(type);
                }

                type  = TryGetTypeFromAssembly(name);
                if (type == null) type = GetTypeByString(name);
                
                _loggerTypeDictionary[name] = type;

                return CreateLogger(type);
            }

        
        private static Type TryGetTypeFromAssembly(Assembly assembly)
        {
            var types = GetImplementations<ILogger>(assembly);
            
            // After assembly load succeeds, it is required to contain exactly one ILogger implementation.
            
            switch (types.Length)
            {
                case 0:  throw new Exception("No " + nameof(ILogger) + " implementation found in assembly " + assembly.FullName);
                case 1:  return types[0];
                default: throw new Exception("Multiple " + nameof(ILogger) + " implementations found in assembly " + assembly.FullName);
            }
        }

        
        private static ILogger CreateLogger(Type type)
        {
            if (type == null) throw new NullException(() => type);
            
            // Outcommented for micro-optimization.
            //object obj = Activator.CreateInstance(type);
            
            //if (!(obj is ILogger logger))
            //{
            //    throw new Exception("Type " + type.FullName + " does not implement " + nameof(ILogger) + ".");
            //}
            
            //return logger;

            return (ILogger)Activator.CreateInstance(type);
        }

            //if (string.Equals(name, _lastName, StringComparison.Ordinal))


        
        private static ILogger[] CreateLoggersFromConfig(LogConfig config)
        {
            var configs = GetActiveLoggerConfigs(config);
            return CreateLoggersFromConfigs(configs);
        }

            
            //var types = GetImplementations<ILogger>(assembly);
            
            //switch (types.Length)
            //{
            //    case 1:  return types[0];
            //    case 0:  throw new Exception("No " + nameof(ILogger) + " implementation found in assembly " + assembly.FullName);
            //    default: throw new Exception("Multiple " + nameof(ILogger) + " implementations found in assembly " + assembly.FullName);
            //}

            // if (!Has(name)) throw new Exception(nameof(name) + " not filled in."); // Outcommented for micro-optimization
            if (!Has(name)) throw new Exception(nameof(name) + " not filled in."); // Outcommented for micro-optimization

                //if (type == null) type = GetLoggerType_ByTypeString(name);

        private static Type GetLoggerType_ByTypeString(string typeString)
        {
            var type = Type.GetType(typeString);
            if (type == null) throw new Exception("Type " + typeString + " not found.");
            return type;
        }


type = TryGetLoggerType_FromAssembly(name) ?? Type.GetType(name);

            //LogConfig       config  = GetConfigSection();
            //LoggerElement[] configs = GetActiveLoggerConfigs(config);

        
        private static LogConfigSection CoalesceConfig(LogConfigSection config)
        {
            config = config ?? new LogConfigSection();
            config.Logs = config.Logs ?? Empty<LogConfigElement>();
            
            for (int i = 0; i < config.Logs.Length; i++)
            {
                config.Logs[i] = config.Logs[i] ?? new LogConfigElement();
            }
            
            return config;
        }
        
        private static LogConfigElement[] GetActiveLoggerConfigs(LogConfigSection config)
        {
            bool active = config.Active ?? DefaultActive;
            if (!active) return Empty<LogConfigElement>();
            return config.Logs;
        }

        //public static string TryGetAssemblyName<TType>()
        //    => typeof(TType).Assembly.GetName().Name;

        //void Log(string category, string message);

        //public void Log(string category, string message)
        //    => throw new NotImplementedException();

        //public void Log(string category, string message) { }

        
        //internal static string[] GetCategories(LoggingConfiguration config)
        //{
        //    if (config == null) throw new NullException(() => config);
            
        //    if (!(Active(config)))
        //    {
        //        return Empty<string>();
        //    }
            
        //    var categories = SplitValues(config.Categories)
        //                    .Union(SplitValues(config.Category))
        //                    .Union(EnumerateCategoriesFromElements(config)).ToArray();
            
        //    return categories;
        //}

        
        public override void Log(string category, string message)
        {
            // TODO: Abstract this check in LoggerBase?
            // TODO: Yes/no propagate category to Console?
            if (HasCategory(category)) Log(message);
        }

            
            _categories = Has(categories) ? categories is HashSet<string> new HashSet<string>(categories) : _emptyCategories;
            throw new NotImplementedException();

        public void SetCategories(params string[] categories) => SetCategories((string[ICollection])categories);

        //private static ILogger CreateLogger_FromID(string loggerID, HashSet<string> categories) 
            // TODO: Safer constructor selection instead of Activator.CreateInstance. Or categories not via constructor.
            //=> TryCreateLogger_ByEnum(loggerID, categories) ?? (ILogger)Activator.CreateInstance(GetLoggerType(loggerID), categories);


        [XmlAttribute]
        public string Cat { get; set; }

        [XmlAttribute]
        public string Cats { get; set; }

        [XmlAttribute]
        public string Category { get; set; }

        [XmlAttribute]
        public string Categories { get; set; }

            
            list.AddRange(SplitValues(config.CatString));
            list.AddRange(SplitValues(config.CatsString));
            list.AddRange(SplitValues(config.CategoryString));
            list.AddRange(SplitValues(config.CategoriesString));

        
        //private static LoggerConfig XmlToLoggerConfig(LoggerXml loggerElement) => new LoggerConfig
        //{
        //    Type = loggerElement.Type,
        //    Categories = Ca
            
        //};

            // TODO: Has doesn't work for HashSet / ICollection<T>. When fixed, it causes failures in JJ.Framework.Wishes.Tests usage.
            //=> _categories = categories == null || categories.Count == 0 ? _emptyCategories : categories;
            //=> _categories = categories ?? _emptyCategories;

        //private bool Has(HashSet<string> coll) => coll != null && coll.Count != 0;
        //private bool Has(IList<string> coll) => coll != null && coll.Count != 0;

        //protected bool HasCategory(string category) => _categories.Count == 0 || _categories.Contains(category);
        //protected bool HasCategory(string category) => !Has(_categories) || _categories.Contains(category);


        //protected LoggerBase() 
        //    : this(_emptyCategories) { }
        
        //protected LoggerBase(ICollection<string> categories) 
        //    : this(new HashSet<string>(categories)) { }

        //protected LoggerBase(HashSet<string> categories) 
        //    => _categories = Has(categories) ? categories : _emptyCategories;

        void SetCategories(HashSet<string> categories);

        public void SetCategories(HashSet<string> categories)
        {
            _categories = Has(categories) ? categories : _emptyCategories;
        }

                //// Temporary for debugging
                //if (!Has(message))
                //{
                //    int dummy = 1;
                //}

    
    
        private static readonly HashSet<string> _emptyCategories = new HashSet<string>();
        
        private HashSet<string> _categories = _emptyCategories;

        public void SetCategories(params string[] categories)
        {
            if (!Has(categories))
            {
                _categories = _emptyCategories;
            }

            _categories = new HashSet<string>(categories);
        }

        
        public void SetCategories(ICollection<string> categories)
        {
            // TODO: Simplify
            switch (categories)
            {
                case null: 
                    _categories = new HashSet<string>(); break;
                
                case var _ when categories.Count == 0:
                    _categories = new HashSet<string>(); break;
                    
                case HashSet<string> hashSet: 
                    _categories = hashSet; break;
                
                default: 
                    _categories = new HashSet<string>(categories); break;
            }
            
            _excludedCategories.Clear();
        }

        /// <summary>
        /// Managing an excluded categories collection separately,
        /// can provide us a way to filter out a category,
        /// with an empty initial category list, from which the category couldn't even be removed.
        /// </summary>
        public struct _loggerexcludedcategories { }

        bool categoryIsExcluded = _excludedCategories.Contains(category, ignoreCase: true);
        bool categoryIsListed = _categories.Contains(category, ignoreCase: true);

        /// <summary> AddRange is a member of List&lt;T&gt;. Here is an overload for HashSet&lt;T&gt;. </summary>
        //public static void AddRange<T>(this HashSet<T> dest, IEnumerable<T> source)
        //{
        //    if (dest == null) throw new ArgumentNullException(nameof(dest));
        //    if (source == null) throw new ArgumentNullException(nameof(source));

        //    foreach (T item in source)
        //    {
        //        dest.Add(item);
        //    }
        //}

        
        private static string StringToCategoryConfig(string categoryString) 
            => new CategoryConfig { Name = categoryString };

        
        private static string ElementToCategory(CategoryXml categoryXml) => categoryXml.Name;


        
        <cats>
          <cat name="Synth" tagged="false" />
          <cat name="Config" tagged="true" />
        </cats>

        <categories>
          <category name="Synth" tagged="false" />
          <category name="Config" tagged="true" />
        </categories>

      <cats>
        <cat name="SynthLog" tagged="false" />
        <cat name="Config" tagged="true" />
      </cats>

      <categories>
        <category name="SynthLog" tagged="false" />
        <category name="Config" tagged="true" />
      </categories>

        <cats>
          <cat name="SynthLog" tagged="false" />
          <cat name="Config" tagged="true" />
        </cats>

        <categories>
          <category name="SynthLog" tagged="false" />
          <category name="Config" tagged="true" />
        </categories>

        [XmlAttribute("cat")]        public string CatString        { get; set; }
        [XmlAttribute("cats")]       public string CatsString       { get; set; }
        [XmlAttribute("category")]   public string CategoryString   { get; set; }
        [XmlAttribute("categories")] public string CategoriesString { get; set; }
        
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public IList<CategoryXml> CategoryCollection { get; set; }
        
        [XmlArray("cats")]
        [XmlArrayItem("cat")]
        public IList<CategoryXml> CatCollection { get; set; }

                   .Concat(categoriesXml.CategoryCollection.Select(x => x.Name))
                   .Concat(categoriesXml.CatCollection.Select(x => x.Name))

        public const bool DefaultTagged = true;

            // TODO: Use Coalesce method instead.
            
            // Check if loggerConfig defined categories itself..
            if (categories.Count == 0)
            {
                // Otherwise use those of root config.
                categories = XmlToCategories(rootXml);
            }

        private string _formattedEmptyMessage;
                _formattedEmptyMessage = string.Format(_format, "", "", "");
        
            if (formatted == _formattedEmptyMessage)
            {
                return ""; // Prevents decorations/delimiters from being displayed for empty messages.
            }

        public static RootLoggerConfig CascadeSettings(params RootLoggerXml[] rootXmls)
        {
            if (rootXmls == null) throw new NullException(() => rootXmls);
            
            return new RootLoggerConfig
            {
                Active = Coalesce(rootXmls.Select(x => x.Active)),
                Loggers = Coalesce(rootXmls.Select(x => XmlToLoggerConfigs))
            };
        }

            return list;
                  //.Where(x => Has(x.Type))
                  //.ToList();

        private static LoggerConfig ToDto(string typeString, LoggerXml template) => new LoggerConfig
        {
            Active     = Coalesce(            template.Active, DefaultActive),
            Type       = Coalesce(typeString, template.Type,   DefaultType  ),
            Format     = Coalesce(            template.Format, DefaultFormat),
            Categories = GetCats(template),
            ExcludedCategories = new List<string>()
        };
        
        private static LoggerConfig ToDto(string typeString, LoggerXml xml, LoggerXml template)
        {
            if (xml == null) throw new NullException(() => xml);
            
            return new LoggerConfig
            {
                Active     = Coalesce(            xml.Active, template.Active, DefaultActive),
                Type       = Coalesce(typeString, xml.Type,   template.Type,   DefaultType  ),
                Format     = Coalesce(            xml.Format, template.Format, DefaultFormat),
                Categories = Coalesce(GetCats(xml), GetCats(template)),
                ExcludedCategories = new List<string>()
            };
        }

        public static RootLoggerConfig CascadeSettings(params RootLoggerXml[] layerXmls) => CascadeSettings((IList<RootLoggerXml>)layerXmls);
        private static IList<LoggerConfig> ToDtos(params LoggerXml[] xmlLayers) => ToDtos((IList<LoggerXml>)xmlLayers);
        private static LoggerConfig ToDto(string type, IList<RootLoggerXml> xmlLayers)=> ToDto(type, xmlLayers.Cast<LoggerXml>().ToArray());
        private static IList<string> GetTypeStrings(IList<RootLoggerXml> xmlLayers) => GetTypeStrings(xmlLayers.Cast<LoggerXml>().ToArray());
