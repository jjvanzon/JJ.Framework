﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JJ.Utilities.FileDeduplication {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("JJ.Utilities.FileDeduplication.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Also scan subfolders.
        /// </summary>
        internal static string AlsoScanSubFolders {
            get {
                return ResourceManager.GetString("AlsoScanSubFolders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to JJ Utilities - File Deduplication.
        /// </summary>
        internal static string ApplicationName {
            get {
                return ResourceManager.GetString("ApplicationName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you wish to delete the files? (The one with | in front of it are deleted.).
        /// </summary>
        internal static string DeleteFilesQuestion {
            get {
                return ResourceManager.GetString("DeleteFilesQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicates.
        /// </summary>
        internal static string Duplicates {
            get {
                return ResourceManager.GetString("Duplicates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This utility tries to look up duplicate files in a folder (and its sub-folders). It might first analyze which duplicates there are and would report them. The list might then be edited. After that this utility could delete the files. The files would be sent to the recycle bin. Be careful, because some files are supposed to be there twice to keep things working..
        /// </summary>
        internal static string Explanation {
            get {
                return ResourceManager.GetString("Explanation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Maybe {0} first?.
        /// </summary>
        internal static string MaybeDoFirst_WithName {
            get {
                return ResourceManager.GetString("MaybeDoFirst_WithName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you wish to scan? The list of duplicates would get overwritten..
        /// </summary>
        internal static string ScanQuestion {
            get {
                return ResourceManager.GetString("ScanQuestion", resourceCulture);
            }
        }
    }
}