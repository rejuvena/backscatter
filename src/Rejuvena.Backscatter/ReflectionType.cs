namespace Rejuvena.Backscatter
{
    /// <summary>
    ///     Types of expected cache-capable reflectiont ypes.
    /// </summary>
    public enum ReflectionType
    {
        /// <summary>
        ///     Corresponds to <see cref="System.Reflection.FieldInfo"/>.
        /// </summary>
        Field,

        /// <summary>
        ///     Corresponds to <see cref="System.Reflection.PropertyInfo"/>.
        /// </summary>
        Property,

        /// <summary>
        ///     Corresponds to <see cref="System.Reflection.MethodInfo"/>.
        /// </summary>
        Method,

        /// <summary>
        ///     Corresponds to <see cref="System.Reflection.ConstructorInfo"/>.
        /// </summary>
        Constructor,

        /// <summary>
        ///     Corresponds to <see cref="System.Type"/>.
        /// </summary>
        Type,

        /// <summary>
        ///     Corresponds to <see cref="System.Type"/> which are nested.
        /// </summary>
        NestedType
    }
}