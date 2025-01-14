using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using JJ.Framework.Wishes.Collections;
using JJ.Framework.Wishes.Mathematics_Copied;
using JJ.Framework.Wishes.Text_Copied;
using JJ.Framework.Wishes.Text;
using JJ.Framework.Common;
using JJ.Framework.Configuration;
using static System.Environment;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Reflection.ReflectionWishes;
using System.Linq.Expressions;
using JetBrains.Annotations;
using JJ.Framework.Reflection;

namespace JJ.Framework.Wishes
{
    namespace Collections
    {
        public static class CollectionExtensionWishes
        { 
            public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
            {
                if (timeSpans == null) throw new ArgumentNullException(nameof(timeSpans));
                return timeSpans.Aggregate((x, y) => x + y);
            }
            
            public static TimeSpan Sum<T>(this IEnumerable<T> source, Func<T, TimeSpan> selector)
            {
                return source.Select(selector).Sum();
            }

            public static bool Contains(this IList<string> source, string match, bool ignoreCase = false)
            {
                if (source == null) throw new ArgumentNullException(nameof(source));

                StringComparison stringComparison = ignoreCase.ToStringComparison();

                return source.Any(x => (x ?? "").Equals(match, stringComparison));
            }
            
            /// <inheritdoc cref="docs._onebecomestwo" />
            public static IList<T> OneBecomesTwo<T>(this IList<T> list)
            {
                if (list == null) throw new ArgumentNullException(nameof(list));
                if (list.Count == 1) list = new List<T> { list[0], list[0] };
                return list;
            }
            
            /// <inheritdoc cref="docs._onebecomestwo" />
            public static T[] OneBecomesTwo<T>(this T[] list) => OneBecomesTwo((IList<T>)list).ToArray();
            
            /// <inheritdoc cref="docs._frameworkwishproduct" />
            public static double Product(this IEnumerable<double> collection)
            {
                if (collection == null) throw new ArgumentNullException(nameof(collection));
                
                var array = collection as double[] ?? collection.ToArray();
                
                if (!array.Any()) return 1;
                
                double product = array.FirstOrDefault();
                
                foreach (double value in array.Skip(1))
                {
                    product *= value;
                }
                
                return product;
            }
            
            public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
            {
                int i = 0;
                foreach (var x in enumerable)
                {
                    action(x, i++);
                }
            }

        }
    }

    namespace Collections_Copied
    {
        public static class CollectionsExtensions_Copied
        {
            /// <inheritdoc cref="docs._frameworkwishproduct" />
            public static double Product<TSource>(this IEnumerable<TSource> collection, Func<TSource, double> selector)
                => collection.Select(selector).Product();
        
            /// <summary> AddRange is a member of List&lt;T&gt;. Here is an overload for HashSet&lt;T&gt;. </summary>
            public static void AddRange<T>(this HashSet<T> dest, IEnumerable<T> source)
            {
                if (dest == null) throw new ArgumentNullException(nameof(dest));
                if (source == null) throw new ArgumentNullException(nameof(source));

                foreach (T item in source)
                {
                    dest.Add(item);
                }
            }
        }
    }
    
    namespace Common
    {
        public static class EnvironmentHelperWishes
        {
            public static bool EnvironmentVariableIsDefined(string environmentVariableName, string environmentVariableValue)
                => String.Equals(GetEnvironmentVariable(environmentVariableName), environmentVariableValue, StringComparison.OrdinalIgnoreCase);
        }

        public static class FilledInExtensionWishes
        {
            public static bool FilledIn(this string value)                 => FilledInWishes.FilledIn(value, false);
            public static bool FilledIn(this string value, bool trimSpace) => FilledInWishes.FilledIn(value, trimSpace);
            public static bool FilledIn<T>(this T[] arr)                   => FilledInWishes.FilledIn(arr);
            public static bool FilledIn<T>(this IList<T> coll)             => FilledInWishes.FilledIn(coll);
            public static bool FilledIn<T>(this T value)                   => FilledInWishes.FilledIn(value);
            public static bool FilledIn<T>(this T? value) where T : struct => FilledInWishes.FilledIn(value);

            public static bool Is(this string value, string comparison)                  => FilledInWishes.Is(value, comparison);
            public static bool Is(this string value, string comparison, bool ignoreCase) => FilledInWishes.Is(value, comparison, ignoreCase);
        
            public static bool In<T>(this T      value, params T     [] comparisons                 ) => FilledInWishes.In(value, comparisons);
            public static bool In   (this string value, params string[] comparisons                 ) => FilledInWishes.In(value, comparisons);
            public static bool In   (this string value,        string[] comparisons, bool ignoreCase) => FilledInWishes.In(value, comparisons, ignoreCase);
        }
        
        public static class FilledInWishes
        {
            public static bool FilledIn(string value)                 => FilledIn(value, false);
            public static bool FilledIn(string value, bool trimSpace) => trimSpace ? !string.IsNullOrWhiteSpace(value): !string.IsNullOrEmpty(value);
            public static bool FilledIn<T>(T[] arr)                   => arr != null && arr.Length > 0;
            public static bool FilledIn<T>(IList<T> coll)             => coll != null && coll.Count > 0;
            public static bool FilledIn<T>(T value)                   => !Equals(value, default(T));
            public static bool FilledIn<T>(T? value) where T : struct => !Equals(value, default(T?)) && !Equals(value, default(T));
            
            public static bool Has(string value)                      => FilledIn(value);
            public static bool Has(string value, bool trimSpace)      => FilledIn(value, trimSpace);
            public static bool Has<T>(T[] arr)                        => FilledIn(arr);
            public static bool Has<T>(IList<T> coll)                  => FilledIn(coll);
            public static bool Has<T>(T value)                        => FilledIn(value);
            public static bool Has<T>(T? value) where T : struct      => FilledIn(value);
            
            public static bool Is(string value, string comparison) => Is(value, comparison, ignoreCase: true);
            public static bool Is(string value, string comparison, bool ignoreCase) => string.Equals(value, comparison, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
            
            public static bool In<T>(T      value, params T     [] comparisons                 ) => comparisons.Contains(value                  );
            public static bool In   (string value, params string[] comparisons                 ) => comparisons.Contains(value, ignoreCase: true);
            public static bool In   (string value,        string[] comparisons, bool ignoreCase) => comparisons.Contains(value, ignoreCase      );
        }
    }
    
    /// <inheritdoc cref="_trygetsection"/>
    namespace Configuration
    {
        public static class ConfigurationManagerWishes
        {
            /// <inheritdoc cref="_trygetsection"/>
            public static T TryGetSection<T>()
                where T: class, new()
            {
                T config = null;

                try
                {
                    config = CustomConfigurationManager.GetSection<T>();
                }
                catch (Exception ex)
                {
                    // Allow 'Not Found' Exception
                    string configSectionName = GetAssemblyName<T>().ToLower();
                    string allowedMessage = $"Configuration section '{configSectionName}' not found.";
                    bool messageIsAllowed = string.Equals(ex.Message, allowedMessage);
                    bool messageIsAllowed2 = string.Equals(ex.InnerException?.Message, allowedMessage);
                    bool mustThrow = !messageIsAllowed && !messageIsAllowed2;
                    
                    if (mustThrow)
                    {
                        throw;
                    }
                }

                return config;
            }
        }
    }
    
    namespace IO
    {
        public static class FileWishes
        {
            
            private const int DEFAULT_MAX_EXTENSION_LENGTH = 8;
            
            /// <summary>
            /// If the originalFilePath already exists,
            /// a higher and higher number is inserted into the file name 
            /// until a file name is encountered that does not exist.
            /// Then that file path is returned.
            /// </summary>
            /// <param name="originalFilePath">
            /// The path to a file name, that does not yet have a number in it.
            /// </param>
            public static string GetNumberedFilePath(
                string originalFilePath,
                string numberPrefix = " (",
                string numberFormatString = "#",
                string numberSuffix = ")",
                bool mustNumberFirstFile = false,
                int maxExtensionLength = DEFAULT_MAX_EXTENSION_LENGTH)
            {
                (string filePathFirstPart, int number, string filePathLastPart) =
                    GetNumberedFilePathParts(originalFilePath, numberPrefix, numberSuffix, mustNumberFirstFile, maxExtensionLength);
            
                if (!mustNumberFirstFile && !File.Exists(originalFilePath))
                {
                    return originalFilePath;
                }
                
                string filePath;
                do
                {
                    filePath = $"{filePathFirstPart}{number.ToString(numberFormatString)}{filePathLastPart}";
                    number++;
                }
                while (File.Exists(filePath));
                
                return filePath;
            }
            
            private static readonly Mutex _createSafeFileStreamMutex = CreateMutex();
            private static Mutex CreateMutex()
                => new Mutex(false, "Global\\SynthWishes_CreateSafeFileStreamMutex_7f64fd76542045bb98c2e28a44d2df25");

            /// <summary>
            /// If the originalFilePath already exists,
            /// a higher and higher number is inserted into the file name 
            /// until a file name is encountered that does not exist.
            /// Then a file stream is returned for writing, so that
            /// the file immediately locks.
            /// Be sure to dispose the stream when you're done,
            /// so the file lock is released.
            /// </summary>
            /// <param name="originalFilePath">
            /// The absolute path to a file name, that does not yet have a number in it.
            /// </param>
            public static (string filePath, FileStream) CreateSafeFileStream(
                string originalFilePath,
                string numberPrefix = " (",
                string numberFormatString = "#",
                string numberSuffix = ")",
                bool mustNumberFirstFile = false,
                int maxExtensionLength = 8)
            {
                (string filePathFirstPart, int number, string filePathLastPart) =
                    GetNumberedFilePathParts(originalFilePath, numberPrefix, numberSuffix, mustNumberFirstFile, maxExtensionLength);
                
                _createSafeFileStreamMutex.WaitOne();
                try
                {
                    string filePath = originalFilePath;
                    
                    if (mustNumberFirstFile || File.Exists(filePath))
                    {
                        do
                        {
                            filePath = $"{filePathFirstPart}{number.ToString(numberFormatString)}{filePathLastPart}";
                            number++;
                        }
                        while (File.Exists(filePath));
                    }
                    
                    return (filePath, new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read));
                }
                finally
                {
                    _createSafeFileStreamMutex.ReleaseMutex();
                }
            }
            
            /// <summary>
            /// Splits the original file path into three parts: the first part of the file path, 
            /// the initial number to be used for numbering, and the last part of the file path.
            /// This method is used to generate a new file path by inserting a number into the file name 
            /// if the original file path already exists.
            /// </summary>
            /// <param name="originalFilePath">The path to a file name that does not yet have a number in it.</param>
            /// <param name="numberPrefix">The prefix to be used before the number in the file name.</param>
            /// <param name="numberSuffix">The suffix to be used after the number in the file name.</param>
            /// <param name="mustNumberFirstFile">
            /// A boolean indicating whether the first file should be numbered. 
            /// If true, numbering starts from 1; otherwise, it starts from 2.
            /// </param>
            /// <returns>
            /// A tuple containing three parts: 
            /// - The first part of the file path, which includes the directory and the file name up to the number prefix.
            /// - The initial number to be used for numbering.
            /// - The last part of the file path, which includes the number suffix and the file extension.
            /// </returns>
            public static (string filePathFirstPart, int number, string filePathLastPart) 
                GetNumberedFilePathParts(
                    string originalFilePath, 
                    string numberPrefix = " (", 
                    string numberSuffix = ")", 
                    bool mustNumberFirstFile = false,
                    int maxExtensionLength = DEFAULT_MAX_EXTENSION_LENGTH)
            {
                if (string.IsNullOrEmpty(originalFilePath)) throw new Exception("originalFilePath is null or empty.");
                
                string folderPath = Path.GetDirectoryName(originalFilePath)?.TrimEnd('\\'); // Remove slash from root (e.g. @"C:\")
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFilePath);
                string fileExtension = GetExtension(originalFilePath, maxExtensionLength);
                string separator = !string.IsNullOrEmpty(folderPath) ? "\\" : "";
                
                string filePathFirstPart = $"{folderPath}{separator}{fileNameWithoutExtension}{numberPrefix}";
                int number = mustNumberFirstFile ? 1 : 2;
                string filePathLastPart = $"{numberSuffix}{fileExtension}";
                return (filePathFirstPart, number, filePathLastPart);
            }
        
            public static string SanitizeFilePath(string filePath, string badCharReplacement = "-")
            {
                // Crashing a sanitize on an empty string seems a bit harsh.
                if (string.IsNullOrWhiteSpace(filePath)) return filePath;

                var forbiddenCharacters = Path.GetInvalidFileNameChars().ToHashSet();
                
                // Allow slash and colon (but not wildcards)
                forbiddenCharacters.Remove('\\');
                forbiddenCharacters.Remove('/');
                forbiddenCharacters.Remove(':');
                
                string sanitizedFilePath = new string(
                    filePath.SelectMany(chr => forbiddenCharacters.Contains(chr) ? badCharReplacement : $"{chr}")
                            .ToArray());
                
                sanitizedFilePath = sanitizedFilePath.Trim(badCharReplacement);
                
                return sanitizedFilePath;
            }

            public static string GetFileNameWithoutExtension(string filePath, int maxExtensionLength)
            {
                if (!Has(filePath)) return filePath;
                string extension = Path.GetExtension(filePath);
                if (extension.Length > maxExtensionLength) return filePath;
                string fileNameWithoutExtension = filePath.CutRight(extension);
                return fileNameWithoutExtension;
            }
            
            public static string GetExtension(string filePath, int maxExtensionLength)
            {
                if (!Has(filePath)) return filePath;
                string extension = Path.GetExtension(filePath);
                if (extension.Length > maxExtensionLength) return "";
                return extension;
            }
            
            public static bool HasExtension(string filePath, int maxExtensionLength)
            {
                if (!Has(filePath)) return false;
                string extension = GetExtension(filePath, maxExtensionLength);
                if (extension.Length > maxExtensionLength) return false;
                return true;
            }
            
            /// <summary>
            /// If the file actually exists, true is returned.
            /// If it exists as a directory, false is returned.
            /// If the value contains invalid path characters, false is returned.
            /// Otherwise, it returns true if the path has an extension.
            /// </summary>
            public static bool IsFile(string path, int maxExtensionLength = DEFAULT_MAX_EXTENSION_LENGTH)
            {
                if (!Has(path)) return false;
                if (File.Exists(path)) return true;
                if (Directory.Exists(path)) return false;
                if (path.Contains(Path.GetInvalidPathChars())) return false;
                string extension = Path.GetExtension(path);
                if (string.IsNullOrEmpty(extension)) return false;
                return extension.Length <= maxExtensionLength;
            }
        }
    }
    
    namespace Mathematics
    {
        public static class RandomizerWishes
        {
            public static T GetRandomItem<T>(params T[] collection) 
                => Randomizer_Copied.GetRandomItem(collection);
        }
    }
    
    namespace Mathematics_Copied
    {
        public static class Randomizer_Copied
        {
            private static readonly Random _random = CreateRandom();

            private static Random CreateRandom()
            {
                int randomSeed = Guid.NewGuid().GetHashCode();

                var random = new Random(randomSeed);

                return random;
            }

            /// <summary>
            /// Gets a random Int32 between Int32.MinValue and Int32.MaxValue - 1.
            /// </summary>
            public static int GetInt32() => GetInt32(int.MinValue, int.MaxValue - 1);

            /// <summary>
            /// Gets a random Int32 between 0 and the specified value.
            /// max must at most be Int32.MaxValue - 1 or an overflow exception could occur.
            /// </summary>
            public static int GetInt32(int max) => GetInt32(0, max);

            /// <summary>
            /// Gets a random Int32 between between a minimum and a maximum.
            /// Both the minimum and the maximum are included.
            /// max must at most be Int32.MaxValue - 1 or an overflow exception could occur.
            /// </summary>
            public static int GetInt32(int min, int max)
            {
                checked
                {
                    int result = _random.Next(min, max + 1);
                    return result;
                }
            }

            public static T GetRandomItem<T>(IEnumerable<T> collection)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                int count = collection.Count();
                if (count == 0)
                {
                    throw new Exception("collection.Count() == 0");
                }

                int index = GetInt32(count - 1);
                // ReSharper disable once PossibleMultipleEnumeration
                return collection.ElementAt(index);
            }

            public static T TryGetRandomItem<T>(IEnumerable<T> collection)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                int count = collection.Count();
                if (count == 0)
                {
                    // Unfortunately, you cannot create overloads that return T? for structs and null for classes.
                    // This is not currently possible in C#. I think they're working on it.
                    return default;
                }

                int index = GetInt32(count - 1);
                // ReSharper disable once PossibleMultipleEnumeration
                return collection.ElementAt(index);
            }

            /// <summary> Returns a random number between 0.0 and 1.0. </summary>
            public static double GetDouble() => _random.NextDouble();

            /// <summary> Returns a random number between 0.0 and 1.0. </summary>
            public static float GetSingle() => (float)_random.NextDouble();

            /// <param name="min">inclusive</param>
            /// <param name="max">exclusive</param>
            public static double GetDouble(double min, double max)
            {
                double between0And1 = GetDouble();
                double range = max - min;
                double value = min + between0And1 * range;
                return value;
            }

            /// <param name="min">inclusive</param>
            /// <param name="max">exclusive</param>
            public static float GetSingle(float min, float max)
            {
                float between0And1 = GetSingle();
                float range = max - min;
                float  value = min + between0And1 * range;
                return value;
            }
         }
    }
    
    namespace Reflection_Copied
    {
        public static class ReflectionHelper_Copied
        {
            public static bool IsProperty(this MethodBase method)
            {
                if (method == null) throw new ArgumentNullException(nameof(method));

                bool isProperty = method.Name.StartsWith("get_") ||
                                  method.Name.StartsWith("set_");

                return isProperty;
            }
        }
            
        /// <summary>
        /// Attempts to make it easier to access members public, private or protected.
        /// To access base class members, a separate Accessor object might be instantiated compared to accessing derived class members.
        /// To access internal classes, maybe use a .NET Type string, GetType / or CreateInstance.
        /// A limitation is that it might not invoke private or internal constructors (yet).
        /// </summary>
        [PublicAPI]
        public partial class Accessor_Copied_Adapted
        {
            //private static readonly ReflectionCache _reflectionCache = new ReflectionCache();

            private readonly object _object;
            private readonly Type _objectType;

            /// <summary> Use this constructor to access instance members of internal classes. </summary>
            public Accessor_Copied_Adapted(string typeName, params object[] args)
            {
                _objectType = Type.GetType(typeName);

                if (_objectType == null)
                {
                    throw new ArgumentException($"Type '{typeName}' not found.");
                }

                _object = Activator.CreateInstance(_objectType, args);
            }

            /// <summary> Use this constructor to access instance members. </summary>
            public Accessor_Copied_Adapted(object obj)
            {
                _object = obj ?? throw new ArgumentNullException(nameof(obj));
                _objectType = obj.GetType();
            }

            /// <summary> Use this constructor to access static members. </summary>
            public Accessor_Copied_Adapted(Type objectType) => _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));

            /// <summary> Use this constructor to access members of the base class. </summary>
            public Accessor_Copied_Adapted(object obj, Type objectType)
            {
                _object = obj ?? throw new ArgumentNullException(nameof(obj));
                _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
            }

            // Fields

            /// <param name="nameExpression">
            /// An expression from which the member name will be extracted.
            /// Only the last name in the expression might be used and possibly the return type.
            /// </param>
            public T GetFieldValue<T>(Expression<Func<T>> nameExpression)
            {
                string name = ExpressionHelper.GetName(nameExpression);
                return (T)GetFieldValue(name);
            }

            public object GetFieldValue(string name)
            {
                FieldInfo field = StaticReflectionCache.GetField(_objectType, name);
                return field.GetValue(_object);
            }

            /// <param name="nameExpression">
            /// An expression from which the member name will be extracted.
            /// Only the last name in the expression might be used and possibly the return type.
            /// </param>
            public void SetFieldValue<T>(Expression<Func<T>> nameExpression, T value)
            {
                string name = ExpressionHelper.GetName(nameExpression);
                SetFieldValue(name, value);
            }

            public void SetFieldValue(string name, object value)
            {
                FieldInfo field = StaticReflectionCache.GetField(_objectType, name);
                field.SetValue(_object, value);
            }

            // Properties

            /// <param name="nameExpression">
            /// An expression from which the member name will be extracted.
            /// Only the last name in the expression might be used and possibly the return type.
            /// </param>
            public T GetPropertyValue<T>(Expression<Func<T>> nameExpression)
            {
                string name = ExpressionHelper.GetName(nameExpression);
                return (T)GetPropertyValue(name);
            }

            public object GetPropertyValue(string name)
            {
                PropertyInfo property = StaticReflectionCache.GetProperty(_objectType, name);
                return property.GetValue(_object, null);
            }

            /// <param name="nameExpression">
            /// An expression from which the member name will be extracted.
            /// Only the last name in the expression might be used and possibly the return type.
            /// </param>
            public void SetPropertyValue<T>(Expression<Func<T>> nameExpression, T value)
            {
                string name = ExpressionHelper.GetName(nameExpression);
                SetPropertyValue(name, value);
            }

            public void SetPropertyValue(string name, object value)
            {
                PropertyInfo property = StaticReflectionCache.GetProperty(_objectType, name);
                property.SetValue(_object, value, null);
            }

            // Methods

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            /// <param name="callExpression">
            /// An expression from which the member name, parameter types and parameter values might be extracted.
            /// </param>
            public void InvokeMethod(Expression<Action> callExpression) 
                => InvokeMethod((LambdaExpression)callExpression);

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            /// <param name="callExpression">
            /// An expression from which the member name, parameter types and parameter values might be extracted.
            /// </param>
            public T InvokeMethod<T>(Expression<Func<T>> callExpression) 
                => (T)InvokeMethod((LambdaExpression)callExpression);

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            /// <param name="callExpression">
            /// An expression from which the member name, parameter types and parameter values might be extracted.
            /// </param>
            public object InvokeMethod(LambdaExpression callExpression)
            {
                MethodCallInfo methodCallInfo = ExpressionHelper.GetMethodCallInfo(callExpression);

                return InvokeMethod(
                    methodCallInfo.Name,
                    methodCallInfo.Parameters.Select(x => x.Value).ToArray(),
                    methodCallInfo.Parameters.Select(x => x.ParameterType).ToArray());
            }

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            public object InvokeMethod(string name, params object[] parameters)
            {
                MethodInfo method;

                // Try getting parameter types from calling methods
                // (assuming a wrapping accessor class with methods that define the signatures.)
                {
                    Type[] parameterTypes = new StackTrace().GetFrame(1)?.GetMethod().GetParameters().Select(x => x.ParameterType).ToArray();
                    method = StaticReflectionCache.TryGetMethod(_objectType, name, parameterTypes);
                }

                // Try getting parameter types from parameter values.
                if (method == null)
                {
                    Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
                    method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
                }

                return method.Invoke(_object, parameters);
            }

            /// <summary>
            /// <para>
            /// May call a method, that might not be accessible normally,
            /// but can be accessed through this Accessor class anyway.
            /// </para>
            /// 
            /// <para>
            /// The Accessor class may try to find the method to call,
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
            public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes)
            {
                parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
                MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
                return method.Invoke(_object, parameters);
            }

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            public object InvokeMethod<TArg1>(string name, TArg1 parameter)
                => InvokeMethod(name, new object[] { parameter }, new Type[] { typeof(TArg1) });

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            public object InvokeMethod<TArg1, TArg2>(string name, params object[] parameters)
                => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2) });

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            public object InvokeMethod<TArg1, TArg2, TArg3>(string name, params object[] parameters)
                => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) });

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            public object InvokeMethod<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters)
                => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) });

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters)
                => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) });

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters)
                => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) });

            /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters)
                => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) });

            ///// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
            //public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments)
            //{
            //    parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
            //    MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes, typeArguments);
            //    return method.Invoke(_object, parameters);
            //}

            // Indexers

            public object GetIndexerValue(params object[] parameters)
            {
                if (parameters == null) throw new ArgumentNullException(nameof(parameters));
                if (parameters.Length < 1) throw new Exception("parameters.Length must be at least 1.");

                Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
                PropertyInfo property = StaticReflectionCache.GetIndexer(_objectType, parameterTypes);
                return property.GetValue(_object, parameters);
            }

            public void SetIndexerValue(params object[] parametersAndValue)
            {
                if (parametersAndValue == null) throw new ArgumentNullException(nameof(parametersAndValue));
                if (parametersAndValue.Length < 2) throw new Exception("parametersAndValue.Length must be at least 2");
                object[] parameters = parametersAndValue.Take(parametersAndValue.Length - 1).ToArray();
                object value = parametersAndValue.Last();
                Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
                PropertyInfo property = StaticReflectionCache.GetIndexer(_objectType, parameterTypes);
                property.SetValue(_object, value, parameters);
            }

            // Helpers

            /// <summary> Complement null parameter types with types from parameter values (concrete types). </summary>
            private static Type[] ComplementParameterTypes(Type[] parameterTypes, object[] parameters)
            {
                if (parameters == null) throw new ArgumentNullException(nameof(parameters));
                parameterTypes = parameterTypes ?? new Type[0];
                if (parameterTypes.Length > parameters.Length) throw new ArgumentException("parameterTypes.Length is greater than parameters.Length.");

                Type[] parameterTypesFromObjects = ReflectionHelper.TypesFromObjects(parameters);

                // Lenience for missing parameterTypes array elements.
                Array.Resize(ref parameterTypes, parameterTypesFromObjects.Length); 

                parameterTypes = parameterTypes.Zip(parameterTypesFromObjects, (x, y) => x ?? y).ToArray();

                return parameterTypes;
            }
        }
            
            
        
        
    }
    
    namespace Reflection
    {
        public static class ReflectionWishes
        {
            public static string GetAssemblyName<TType>() 
                => typeof(TType).Assembly.GetName().Name;
        }
    }
    
    namespace Testing
    {
        public static class TestWishes
        {
            // ReSharper disable AssignNullToNotNullAttribute
            public static bool CurrentTestIsInCategory(string category)
            {
                var methodQuery = new StackTrace().GetFrames().Select(x => x.GetMethod());
                
                var attributeQuery
                    = methodQuery.SelectMany(method => method.GetCustomAttributes()
                                                             .Union(method.DeclaringType?.GetCustomAttributes()));
                var categoryQuery
                    = attributeQuery.Where(attr => attr.GetType().Name == "TestCategoryAttribute")
                                    .Select(attr => attr.GetType().GetProperty("TestCategories")?.GetValue(attr))
                                    .OfType<IEnumerable<string>>()
                                    .SelectMany(x => x);
                
                bool isInCategory = categoryQuery.Any(x => String.Equals(x, category, StringComparison.OrdinalIgnoreCase));
                
                return isInCategory;
            }
        }
    }
        
    namespace Text
    {
        public static class StringExtensionWishes
        { 
            public static bool StartsWithBlankLine(this string text) => StringWishes.StartsWithBlankLine(text);
            public static bool EndsWithBlankLine(this string text) => StringWishes.EndsWithBlankLine(text);
        }
        
        public static class StringWishes
        { 
            public static int CountLines(this string str)
            {
                // Less efficient:
                //int count = str.Trim().Split(NewLine).Length;
                //int count = 1 + str.Count(c => c == '\n');

                if (str == null) return 0;
                    
                int count = 1; // Start with 1 to account for the first line
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '\n') // Platform safe for '\n' or "\r\n".
                    {
                        count++;
                    }
                }

                if (str.EndsWith(NewLine))
                {
                    count--;
                }

                return count;
            }

            public static bool Contains(this string str, string substring, bool ignoreCase = false)
            {
                if (str == null) throw new ArgumentNullException(nameof(str));
                return str.IndexOf(substring, ToStringComparison(ignoreCase)) >= 0;
            }

            public static bool Contains(this string str, string[] words, bool ignoreCase = false)
            {
                if (str == null) throw new ArgumentNullException(nameof(str));
                return words.Any(x => str.IndexOf(x, ToStringComparison(ignoreCase)) >= 0);
            }

            public static bool Contains(this string str, char[] chars)
            {
                if (str == null) throw new ArgumentNullException(nameof(str));
                return chars.Any(str.Contains);
            }

            public static StringComparison ToStringComparison(this bool ignoreCase) 
                => ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            public static string PrettyDuration(double? durationInSeconds)
            {
                if (!durationInSeconds.HasValue) return default;
                return PrettyDuration(durationInSeconds.Value);
            }
            
            public static string PrettyDuration(double durationInSeconds) => PrettyTimeSpan(TimeSpan.FromSeconds(durationInSeconds));
            
            public static string PrettyTimeSpan(this TimeSpan timeSpan)
            {
                double totalNanoseconds = timeSpan.TotalMilliseconds * 1000;
        
                if (timeSpan.TotalDays >= 1) return $"{timeSpan.TotalDays:0.00} d";
                if (timeSpan.TotalHours >= 1) return $"{timeSpan.TotalHours:0.00} h";
                if (timeSpan.TotalMinutes >= 1) return $"{timeSpan.TotalMinutes:0.00} min";
                if (timeSpan.TotalSeconds >= 1) return $"{timeSpan.TotalSeconds:0.00} s";
                if (timeSpan.TotalMilliseconds >= 1) return $"{timeSpan.TotalMilliseconds:0.00} ms";
        
                return $"{totalNanoseconds:0.00} ns";
            }
            
            public static string PrettyByteCount(long byteCount)
            {
                const double kB = 1024;
                const double MB = kB * 1024;
                const double GB = MB * 1024;

                if (byteCount <= 5 * kB) return $"{byteCount} bytes";
                if (byteCount <= 5 * MB) return $"{byteCount / kB:0} kB";
                if (byteCount <= 5 * GB) return $"{byteCount / MB:0} MB";
                
                return $"{byteCount / GB:0} GB";
            }
            
            public static string WithShortGuids(this string input, int length)
            {
                // Regular expression to match GUID-like sequences with or without dashes
                var guidPattern = new Regex(@"\b[a-fA-F0-9]{4,32}\b(-?[a-fA-F0-9]{4,32})*\b", RegexOptions.IgnoreCase);

                // Replace each matched GUID-like sequence with a truncated version
                string output = guidPattern.Replace(input, match =>
                {
                    // Remove dashes from the matched sequence
                    string guid = match.Value.Replace("-", "");

                    // Shorten the GUID to the desired length, ensuring it doesn't exceed the original length
                    return guid.Substring(0, Math.Min(length, guid.Length));
                });

                return output;
            }
            
            public static string PrettyTime() => PrettyTime(DateTime.Now);
            
            public static string PrettyTime(DateTime dateTime) => $"{dateTime:HH:mm:ss.fff}";
            
            public static string Trim(this string text, string trim)
            {
                if (text == null) throw new ArgumentNullException(nameof(text));
                return text.TrimStart(trim).TrimEnd(trim);
            }

            /// <summary>
            /// Determines whether the given string ends with a punctuation character,
            /// optionally ignoring trailing whitespace.
            /// This method is helpful when building strings with multiple optional elements,
            /// ensuring proper punctuation is applied only when necessary.
            /// 
            /// If the string is <c>null</c> or empty, it is treated as the beginning of a line,
            /// where no punctuation is required. In this case, the method returns <c>true</c>,
            /// indicating no additional punctuation is needed.
            /// </summary>
            /// <param name="text">
            /// The string to evaluate. This parameter can be <c>null</c> or empty.
            /// </param>
            /// <param name="ignoreWhiteSpace">
            /// If set to <c>true</c>, trailing whitespace in the string is ignored before evaluating for punctuation.
            /// Defaults to <c>true</c>.
            /// </param>
            /// <returns>
            /// <c>true</c> if the string ends with a punctuation character,
            /// or if the string is <c>null</c> or empty (considered as starting a new line).<br/>
            /// <c>false</c> if the string does not end with a punctuation character
            /// after accounting for <paramref name="ignoreWhiteSpace"/>.
            /// </returns>
            public static bool EndsWithPunctuation(this string text, bool ignoreWhiteSpace = true)
            {
                if (ignoreWhiteSpace) text = text?.TrimEnd();
                
                if (!FilledIn(text)) 
                { 
                    // Start of string is good enough for punctuation.
                    return true;
                }
                
                // ReSharper disable once PossibleNullReferenceException
                return char.IsPunctuation(text[text.Length - 1]);
            }
            
            public static bool StartsWithBlankLine(string text)
            {
                if (!Has(text)) return true;
                
                for (int i = 0; i < text.Length; i++)
                {
                    char chr = text[i];
                    
                    bool isWhiteSpace = char.IsWhiteSpace(chr);
                    if (!isWhiteSpace) return false;
                    
                    bool isNewLine = chr == '\n';
                    if (isNewLine) return true;
                    
                    bool isLastChar = i == text.Length - 1;
                    if (isLastChar) return false;
                }
                
                return false;
            }
                
            public static bool EndsWithBlankLine(string text)
            {
                if (!Has(text)) return true;
                
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    char chr = text[i];
                    
                    bool isWhiteSpace = char.IsWhiteSpace(chr);
                    if (!isWhiteSpace) return false;
                    
                    bool isNewLine = chr == '\n';
                    if (isNewLine) return true;
                    
                    bool isFirstChar = i == 0;
                    if (isFirstChar) return false;
                }
                
                return false;
            }
        }
    }
    
    namespace Text_Copied
    {
        public class StringBuilderWithIndentation_AdaptedFromFramework
        {
            public StringBuilderWithIndentation_AdaptedFromFramework()
                : this("  ")
            { }

            public StringBuilderWithIndentation_AdaptedFromFramework(string tabString)
                : this(tabString, NewLine)
            { }

            public StringBuilderWithIndentation_AdaptedFromFramework(string tabString , string enter)
            {
                _tabString = tabString;
                _enter = enter;
            }
            
            private readonly string _tabString;
            private readonly string _enter;
            
            private readonly StringBuilder _sb = new StringBuilder();

            public override string ToString() => _sb.ToString();
            public void Indent() => IndentLevel++;
            public void Unindent() => IndentLevel--;
            public void AppendEnter() => Append(_enter);
            public void AppendLine() => AppendLine("");
            public void Append(object x) => _sb.Append(x);

            public void AppendLine(string value)
            {
                AppendTabs();

                _sb.Append(value);

                _sb.Append(_enter);
            }

            public void AppendFormat(string format, params object[] args) => _sb.AppendFormat(format, args);

            private int _indentLevel;
            public int IndentLevel
            {
                get => _indentLevel;
                set
                {
                    if (value < 0) throw new Exception("value cannot be less than 0.");
                    _indentLevel = value;
                }
            }

            public void AppendTabs()
            {
                string tabs = GetTabs();
                _sb.Append(tabs);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public string GetTabs()
            {
                string tabs = _tabString?.Repeat(_indentLevel);
                return tabs;
            }
        }

        public static class StringExtensions_Copied
        {
            /// <summary>
            /// Will trim off repetitions of the same value from the given string.
            /// These are variations of the standard .NET methods that instead of just taking char[] can take a string or a length.
            /// </summary>
            public static string TrimEnd(this string input, string end)
            {
                if (string.IsNullOrEmpty(end)) throw new Exception($"{nameof(end)} is null or empty.");

                string temp = input;

                while (temp.EndsWith(end))
                {
                    temp = temp.TrimEnd(end.Length);
                }

                return temp;
            }
            
            /// <summary>
            /// Will trim off repetitions of the same value from the given string.
            /// These are variations of the standard .NET methods that instead of just taking char[] can take a string or a length.
            /// </summary>
            public static string TrimEnd(this string input, int length) => input.Left(input.Length - length);
            
            /// <summary>
            /// Will trim off repetitions of the same value from the given string.
            /// These are variations of the standard .NET methods that instead of just taking char[] can take a string or a length.
            /// </summary>
            public static string TrimStart(this string input, string start)
            {
                if (string.IsNullOrEmpty(start)) throw new Exception($"{nameof(start)} is null or empty.");

                string temp = input;

                while (temp.StartsWith(start))
                {
                    temp = temp.TrimStart(start.Length);
                }

                return temp;
            }

            /// <summary>
            /// Will trim off repetitions of the same value from the given string.
            /// These are variations of the standard .NET methods that instead of just taking char[] can take a string or a length.
            /// </summary>
            public static string TrimStart(this string input, int length) => input.Right(input.Length - length);
            
            /// <summary>
            /// Repeat a string a number of times, returning a single string.
            /// </summary>
            public static string Repeat(this string stringToRepeat, int repeatCount)
            {
                if (stringToRepeat == null) throw new ArgumentNullException(nameof(stringToRepeat));

                char[] sourceChars = stringToRepeat.ToCharArray();
                int sourceLength = sourceChars.Length;

                int destLength = sourceLength * repeatCount;
                var destChars = new char[destLength];

                for (var i = 0; i < destLength; i += sourceLength)
                {
                    Array.Copy(sourceChars, 0, destChars, i, sourceLength);
                }

                var destString = new string(destChars);
                return destString;
            }
        
            /// <summary>
            /// Takes the part of a string until the specified delimiter. Excludes the delimiter itself.
            /// </summary>
            public static string TakeEndUntil(this string input, string until)
            {
                if (until == null) throw new ArgumentNullException(nameof(until));
                int index = input.LastIndexOf(until, StringComparison.Ordinal);
                if (index == -1) return "";
                int length = input.Length - index - 1;
                string output = input.Right(length);
                return output;
            }
            
            /// <summary>
            /// Returns the left part of a string.
            /// Can return less characters than the length provided if string is shorter.
            /// </summary>
            public static string TakeStart(this string input, int length)
            {
                if (length > input.Length) length = input.Length;

                return input.Left(length);
            }
        }
    }
}
