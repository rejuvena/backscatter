using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rejuvena.Backscatter.Cache
{
    /// <summary>
    ///     Static reflection cache for quick retrieval.
    /// </summary>
    public static class ReflectionCache
    {
        /// <summary>
        ///     The core cache.
        /// </summary>
        /// <remarks>
        ///     This dictionary should not be directly modified. Instead, use the provided methods.
        /// </remarks>
        public static readonly Dictionary<ReflectionType, Dictionary<string, object>> Cache = new()
        {
            {ReflectionType.Field, new Dictionary<string, object>()},
            {ReflectionType.Property, new Dictionary<string, object>()},
            {ReflectionType.Method, new Dictionary<string, object>()},
            {ReflectionType.Constructor, new Dictionary<string, object>()},
            {ReflectionType.Type, new Dictionary<string, object>()},
            {ReflectionType.NestedType, new Dictionary<string, object>()}
        };

        #region Cache Retrieval

        /// <summary>
        ///     Retrieves an object from the reflection cache.
        /// </summary>
        /// <param name="refType">The reflected object type.</param>
        /// <param name="key">The object's unique key.</param>
        /// <param name="fallback">The value that will be used to populate the dictionary if a value is not already present.</param>
        public static T? RetrieveFromCache<T>(ReflectionType refType, string key, Func<T?> fallback) where T : class
        {
            if (Cache[refType].TryGetValue(key, out object found))
                return (T) found;

            T? value = fallback();

            if (value is null)
                return null;

            return (T) (Cache[refType][key] = value);
        }

        private static string GetSignature(IEnumerable<Type> signature) =>
            $"({signature.Aggregate("", (current, type) => current + type.FullName)})";

        public static FieldInfo? GetCachedField(Type type, string key) => RetrieveFromCache(
            ReflectionType.Field,
            type.FullName + "." + key,
            () => type.GetField(key, ReflectionFlags.UniversalFlags)
        );

        public static PropertyInfo? GetCachedProperty(Type type, string key) => RetrieveFromCache(
            ReflectionType.Property,
            type.FullName + "." + key,
            () => type.GetProperty(key, ReflectionFlags.UniversalFlags)
        );

        public static MethodInfo? GetCachedMethod(Type type, string key, Type[] signature) => RetrieveFromCache(
            ReflectionType.Method,
            type.FullName + "." + key + GetSignature(signature),
            () => type.GetMethod(
                key,
                ReflectionFlags.UniversalFlags, 
                null,
                CallingConventions.Any,
                signature,
                null
            )
        );

        public static MethodInfo? GetCachedMethod(Type type, string key) => GetCachedMethod(
            type,
            key,
            Array.Empty<Type>()
        );

        public static ConstructorInfo? GetCachedConstructor(Type type, Type[] signature) => RetrieveFromCache(
            ReflectionType.Constructor,
            type.FullName + ".ctor" + GetSignature(signature),
            () => type.GetConstructor(
                ReflectionFlags.UniversalFlags,
                null,
                CallingConventions.Any,
                signature,
                null
            )
        );

        public static ConstructorInfo? GetCachedStaticConstructor(Type type) => RetrieveFromCache(
            ReflectionType.Constructor,
            type.FullName + ".cctor",
            () => type.TypeInitializer
        );

        public static Type? GetCachedType(Assembly assembly, string key) => RetrieveFromCache(
            ReflectionType.Type,
            assembly.FullName + "::" + key,
            () => assembly.GetType(key)
        );
        
        public static Type? GetCachedNestedType(Type type, string key) => RetrieveFromCache(
            ReflectionType.NestedType,
            type.FullName + "/" + key,
            () => type.GetNestedType(key)
        );

        #endregion
    }
}