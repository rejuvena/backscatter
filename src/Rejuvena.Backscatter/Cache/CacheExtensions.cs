using System;
using System.Reflection;

namespace Rejuvena.Backscatter.Cache
{
    /// <summary>
    ///     Provides extensions from <see cref="ReflectionCache"/>.
    /// </summary>
    public static class CacheExtensions
    {
        #region Cache Retrieval

        public static FieldInfo? GetCachedField(this Type type, string key) => ReflectionCache.GetCachedField(type, key);

        public static PropertyInfo? GetCachedProperty(this Type type, string key) => ReflectionCache.GetCachedProperty(type, key);

        public static MethodInfo? GetCachedMethod(this Type type, string key, Type[] signature) => ReflectionCache.GetCachedMethod(type, key, signature);

        public static MethodInfo? GetCachedMethod(this Type type, string key) => ReflectionCache.GetCachedMethod(type, key);

        public static ConstructorInfo? GetCachedConstructor(this Type type, Type[] signature) => ReflectionCache.GetCachedConstructor(type, signature);

        public static ConstructorInfo? GetCachedStaticConstructor(this Type type) => ReflectionCache.GetCachedStaticConstructor(type);

        public static Type? GetCachedType(this Assembly assembly, string key) => ReflectionCache.GetCachedType(assembly, key);

        public static Type? GetCachedNestedType(this Type type, string key) => ReflectionCache.GetCachedNestedType(type, key);

        #endregion

        #region Null-Intolerant Retrieval

        public static FieldInfo GetCachedFieldNotNull(this Type type, string key) => ReflectionCache.GetCachedFieldNotNull(type, key);

        public static PropertyInfo GetCachedPropertyNotNull(this Type type, string key) => ReflectionCache.GetCachedPropertyNotNull(type, key);

        public static MethodInfo GetCachedMethodNotNull(this Type type, string key, Type[] signature) => ReflectionCache.GetCachedMethodNotNull(type, key, signature);

        public static MethodInfo GetCachedMethodNotNull(this Type type, string key) => ReflectionCache.GetCachedMethodNotNull(type, key);

        public static ConstructorInfo GetCachedConstructorNotNull(this Type type, Type[] signature) => ReflectionCache.GetCachedConstructorNotNull(type, signature);

        public static ConstructorInfo GetCachedStaticConstructorNotNull(this Type type) => ReflectionCache.GetCachedStaticConstructorNotNull(type);

        public static Type GetCachedTypeNotNull(this Assembly assembly, string key) => ReflectionCache.GetCachedTypeNotNull(assembly, key);

        public static Type GetCachedNestedTypeNotNull(this Type type, string key) => ReflectionCache.GetCachedNestedTypeNotNull(type, key);

        #endregion

        #region Reflection Utilities

        public static T GetValue<T>(FieldInfo info, object? instance = null) => ReflectionCache.GetValue<T>(info, instance);
        
        public static T GetValue<T>(PropertyInfo info, object? instance = null) => ReflectionCache.GetValue<T>(info, instance);

        public static void SetValue(FieldInfo info, object? instance, object? value) => ReflectionCache.SetValue(info, instance, value);
        
        public static void SetValue(PropertyInfo info, object? instance, object? value) => ReflectionCache.SetValue(info, instance, value);

        #endregion

        #region Instance Utilities

        public static TReturn? GetFieldValue<TType, TReturn>(this TType instance, string member) => ReflectionCache.GetFieldValue<TType, TReturn>(instance, member);

        public static TReturn? GetPropertyValue<TType, TReturn>(this TType instance, string member) => ReflectionCache.GetPropertyValue<TType, TReturn>(instance, member);

        public static void SetFieldValue<TType>(this TType instance, string member, object? value = null) => ReflectionCache.SetFieldValue(instance, member, value);

        public static void SetPropertyValue<TType>(this TType instance, string member, object? value = null) => ReflectionCache.SetPropertyValue(instance, member, value);

        #endregion
    }
}