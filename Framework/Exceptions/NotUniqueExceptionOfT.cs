using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
    public class NotUniqueException<TObject> : NotUniqueException
    {
        private const string MESSAGE = "{0} with key '{1}' not unique.";

        public NotUniqueException(object key)
            : base(String.Format(MESSAGE, typeof(TObject).Name, key))
        { }
    }
}
