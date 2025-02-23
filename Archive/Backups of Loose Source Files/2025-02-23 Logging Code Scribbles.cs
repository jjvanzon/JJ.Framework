        
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