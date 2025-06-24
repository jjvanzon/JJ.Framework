// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name

namespace JJ.Framework.Logging.Core
{
    namespace docs
    {
       
        /// <summary>
        /// Does not include the ".wishes" part for future compatibility.
        /// </summary>
        public struct _defaultconfigsectionname { } 

        /// <summary>
        /// A separate excluded categories collection allows filtering out categories 
        /// even when the initial category list is empty, where direct removal wouldn't be possible.
        /// </summary>
        public struct _loggerexcludedcategories { }
            
        /// <summary>
        /// Allows specifying the format of the output log messages,
        /// namely the occurrence or leaving out of the elements: timestamp, category and message,
        /// {0}, {1} and {2} respectively (for now).
        /// </summary>
        public struct _loggerformat { }
        
        /// <summary>
        /// Specifies the logger type. Options include:<br/>
        /// - LoggerEnum values (e.g., Console, DebugOutput).<br/>
        /// - Assembly name containing an ILogger implementation.<br/>
        /// - Full .NET Type string indicating an implementation of ILogger.
        /// </summary>
        public struct _loggertype { }
        
        /// <remarks>Semi-colon separated.</remarks>
        /// <inheritdoc cref="docs._loggertype" />
        public struct _loggertypes { }

    }
}
