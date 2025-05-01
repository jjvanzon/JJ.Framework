#pragma warning disable CS0649
#pragma warning disable CS0169 // Field is never used
#pragma warning disable IDE0044
#pragma warning disable IDE1006 // Naming Styles

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace JJ.Framework.Reflection
{
    namespace docs
    {
        // NOTE: These are structs, so their syntax colorings are unobtrusive.

        /// <summary>
        /// Makes it easier to access private/protected/internal members.
        /// To access base class members, instantiate a separate Accessor
        /// alongside an accessor for the derived class members.
        /// To access internal classes, use a .NET Type string, GetType / or CreateInstance.
        /// </summary>
        public struct _accessor { }
        
        /// <summary>
        /// Use this constructor to access instance members of internal classes.
        /// </summary>
        public struct _accessorconstructorwithtypename { }
        
        /// <summary>
        /// Use this constructor to access instance members.
        /// </summary>
        public struct _accessorconstructorwithobject { }

        /// <summary>
        /// Use this constructor to access static members.
        /// </summary>
        public struct _accessorconstructorwithtype { }
        
        /// <summary>
        /// Use this constructor to access members of the base class.
        /// </summary>
        public struct _accessorconstructorwithobjectandtype { }
        
        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted.
        /// Only the last name in the expression is used the return type can as well.
        /// </param>
        public struct _nameexpression { }

        /// <summary>
        /// <para>
        /// Calls a method, normally not accessible,
        /// but can be accessed through this Accessor class anyway.
        /// </para>
        /// 
        /// <para>
        /// The Accessor class finds the method to call,
        /// based on its name and parameter types.
        /// </para>
        ///
        /// <para>
        /// You can program a custom wrapper Accessor class,
        /// to have methods that look the same as the ones that you are trying to call.
        /// </para>
        ///
        /// <para>
        /// InvokeMethod overloads, that take a lambda expression, is a good choice,
        /// because it resolves the parameter types quite elegantly.
        /// </para>
        /// 
        /// <para>
        /// If that does not work, second in line is InvokeMethod overloads,
        /// that take a name and parameter objects.
        /// That overload attempts to derive the parameter types
        /// based on the signature of the calling method
        /// (which may work for custom Accessor classes).
        /// Otherwise it gets the parameter types based on the values that were passed
        /// (which however, may not always be specific enough).
        /// </para>
        ///
        /// <para>
        /// Last in line are the overloads, that specify parameter types explicitly.
        /// That can be done with an array of Types or with type arguments.
        /// Calls to these overloads may seem less elegant,
        /// but are a last option before you can only resort to other APIs.
        /// There is some lenience in leaving out certain parameter types (using null)
        /// that can already be resolved based on the values themselves.
        /// </para>
        ///
        /// <para>
        /// There are also overloads to specify generic type arguments.
        /// </para>
        ///
        /// <para>
        /// InvokeMethod supports ref parameters and can handle both ref and out.
        /// </para>
        /// </summary>
        /// <param name="parameterTypes">
        /// Nullable. Some parameter types can be specified as null.
        /// It can also have less items, than there are parameters.
        /// The other parameter types are resolved based on the concrete types of the passed parameter values.
        /// </param>
        /// <param name="callExpression">
        /// An expression from which the member name, parameter types and parameter values are extracted.
        /// </param>
        public struct _invokemethod { }

        /// <summary>
        /// Complements null parameter types with types from parameter values (concrete types).
        /// </summary>
        public struct _complementparametertypes { }
    }
}
