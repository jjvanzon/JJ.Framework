#pragma warning disable CS0649
#pragma warning disable CS0169 // Field is never used
#pragma warning disable IDE0044

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace JJ.Framework.Reflection.Core
{
    namespace docs
    {
        // NOTE: These are structs, so their syntax colorings are unobtrusive.

        /// <summary> Use this constructor to access instance members of internal classes. </summary>
        public struct _accessorconstructorwithtypename { }
        
        /// <summary>
        /// <para>
        /// Calls a method, that might not be accessible normally,
        /// but can be accessed through this Accessor class anyway.
        /// </para>
        /// 
        /// <para>
        /// The Accessor class tries to find the method to call,
        /// based on its name and parameter types.
        /// </para>
        ///
        /// <para>
        /// You might program a custom wrapper Accessor class,
        /// having methods that are like the ones that you try to call.
        /// </para>
        ///
        /// <para>
        /// The InvokeMethod overload that takes a lambda expression might be a first choice,
        /// because it may resolve the parameter types quite elegantly.
        /// </para>
        /// 
        /// <para>
        /// If that does not work, second in line might be, the InvokeMethod overloads,
        /// that takes a name and parameter objects.
        /// That overload attempts to guess the parameter types
        /// based on the signature of the calling method
        /// (which may work for custom Accessor classes).
        /// Otherwise it may try to guess parameter types based on the values that were passed
        /// (which however, may not always be specific enough).
        /// </para>
        ///
        /// <para>
        /// Last in line might be overloads, that specify parameter types explicitly.
        /// That can be done with an array of Types or with type arguments.
        /// Calls to these overloads may seem less elegant,
        /// but there may sometimes be no other option left.
        /// There is some lenience in leaving out certain parameter types (using null)
        /// that might be guessed based on the values.
        /// </para>
        ///
        /// <para>
        /// There may also be an overload to specify generic type arguments.
        /// </para>
        ///
        /// <para>
        /// In case of ref and out parameters, specifying the parameter types explicitly
        /// may be the only option. InvokeMethod may use ref parameters which may work for both ref and out parameters.
        /// </para>
        /// </summary>
        ///
        /// <param name="parameterTypes">
        /// Nullable. Some items can be left null. It can also have less items, than there are parameters.
        /// It may be complemented with the concrete types of the passed parameter values.
        /// </param>
        public struct _acessorinvokemethod { }

        /// <summary>
        /// Handles a collection of this class and its base classes recursively.
        /// </summary>
        public struct _classesinhierarchy { }
        
        /// <summary>
        /// Handles a collection of this interface or its deeper interfaces recursively.
        /// </summary>
        public struct _interfacesinhierarchy { }

        /// <summary>
        /// Handles a collection of this type and its base classes and interfaces recursively.
        /// </summary>
        public struct _typesinhierarchy { }
        
    }
}
