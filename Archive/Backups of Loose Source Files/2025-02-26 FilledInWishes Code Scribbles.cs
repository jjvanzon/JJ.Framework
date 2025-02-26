
        //public static T IsNull<T>(Expression<Func<T>> expression) => NoNull(expression);
        //public static T Null<T>(Expression<Func<T>> expression) => NoNull(expression);
        //public static T OrThrow<T>(Expression<Func<T>> expression) => NoNull(expression);
        //public static T NotNull<T>(Expression<Func<T>> expression) => NoNull(expression);
        // TODO: Syntax examples.
        /// <summary>
        /// Perhaps slightly less fast than a literal check for null,
        /// but shorter in syntax, especially useful inlined.
        /// </summary>
        //public static T NoNull<T>(Expression<Func<T>> expression)
        //{
        //    T obj = GetValue(expression);
            
        //    if (obj== null)
        //    {
        //        string str = GetText(expression);
        //        throw new Exception(str + " unspecified.");
        //    }
            
        //    return obj;
        //}
