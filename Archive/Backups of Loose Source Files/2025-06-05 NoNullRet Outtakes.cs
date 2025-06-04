
    // For objects

    ///// <inheritdoc cref="_nonullret" />
    //public static void NoNullRet<TRet>(TRet ret)
    //    where TRet : class
    //{
    //    NotNull(ret);
    //}

    // For structs

    ///// <inheritdoc cref="_nullret" />
    //public static void NullRet<TRet>(TRet ret, [ArgExpress(nameof(ret))] string message = "")
    //    where TRet : struct
    //{
    //    IsType(typeof(int?), ret, message);
    //    NotType(typeof(int), ret, message);
    //}


    // For bool
    
    ///// <inheritdoc cref="_nonullret" />
    //public static void NoNullRet<TRet>(bool expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
    //    where TRet : struct
    //{
    //    AreEqual(expected, ret, message);
    //    IsType(typeof(bool), ret, message);
    //    NotType(typeof(bool?), ret, message);
    //}

    ///// <inheritdoc cref="_nullret" />
    //public static void NullRet<TRet>(bool expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
    //{
    //    AreEqual(expected, ret, message);
    //    IsType(typeof(bool?), ret, message);
    //    NotType(typeof(bool), ret, message);
    //}
    
    ///// <inheritdoc cref="_nullret" />
    //public static void NullRet<TRet>(bool? expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
    //{
    //    AreEqual(expected, ret, message);
    //    IsType(typeof(bool?), ret, message);
    //    NotType(typeof(bool), ret, message);
    //}
    
    ///// <inheritdoc cref="_nonullret" />
    //public static void NoNullTrue<TRet>(TRet ret, [ArgExpress(nameof(ret))] string message = "")
    //{
    //    AreEqual(true, ret, message);
    //    IsType(typeof(bool?), ret, message);
    //    NotType(typeof(bool), ret, message);
    //}
    
    ///// <inheritdoc cref="_nonullret" />
    //public static void NoNullFalse<TRet>(TRet ret, [ArgExpress(nameof(ret))] string message = "")
    //{
    //    AreEqual(false, ret, message);
    //    IsType(typeof(bool?), ret, message);
    //    NotType(typeof(bool), ret, message);
    //}
