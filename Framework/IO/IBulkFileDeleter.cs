using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace JJ.Framework.IO
{
    [PublicAPI]
    public interface IBulkFileDeleter
    {
        void DeleteFiles(IList<string> filePaths, Action<string> progressCallback = null, Func<bool> cancelCallback = null);
    }
}