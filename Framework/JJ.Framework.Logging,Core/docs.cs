// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name

namespace JJ.Framework.Logging.Core
{
    namespace docs
    {
        /// <summary>
        /// Can function as a single collection, but also as a collection of collections, <br/>
        /// and a helper for using structured test Cases. <br/>
        /// Provides integration with MSTest using DynamicData for parameterized data-driven testing. <br/><br/>
        ///
        /// Helps define a store the test cases into memory,
        /// retrieving them by key, conversion to DynamicData
        /// and Case templating.
        /// </summary>
        public struct _casecollection { }
        
        /// <summary>
        /// Allow duplicates to pass by, for practical reasons when managing multiple CaseCollections as one.
        /// </summary>
        public struct _casecollectionallowduplicates { }
                
        /// <summary>
        /// Creates new cases based on the specified template, applying its properties to the provided cases.<br/>
        /// NOTE: You can't replace a template value by a ZERO value! Try defining a separate case without a template,
        /// or another template with the zero value in it.
        /// </summary>
        /// <param name="template">The template case to apply.</param>
        /// <param name="cases">The cases to which the template is applied.</param>
        /// <param name="destCases">The cases to which the template is applied.</param>
        /// <returns>A collection of cases derived from the template.</returns>
        public struct _casetemplate { }
       
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
        
        /// <summary>
        /// Usage of the flag is up to the developer's discretion. <br/><br/>
        /// 
        /// Specifies whether strict validation is applied to ensure consistency between
        /// mathematically related Props.<br/><br/>
        /// 
        /// - <c>true</c>: Validation ensures that specified values match values calculated from dependencies.
        ///   Inconsistencies can result in exceptions, such as: <br/>
        ///   "Attempt to initialize FrameCount to 11 is inconsistent with FrameCount 4803 
        ///    based on initial values for AudioLength (0.1), SamplingRate (default 48000), and CourtesyFrames (3)." <br/>
        /// - <c>false</c>: Validation is relaxed, and mismatched values are allowed for scenarios 
        ///   where not all properties might be relevant to the test. <br/><br/>
        /// 
        /// Use this flag to test cases with or without strict mathematical relationships between properties.
        /// </summary>
        public struct _strict { }

        
        /// <summary> 
        /// This null-tolerant version is missing in JJ.Framework.Configuration for now.
        /// </summary> 
        public struct _trygetsection { }
    }
}
