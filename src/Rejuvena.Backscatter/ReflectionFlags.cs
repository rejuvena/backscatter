using System.Reflection;

namespace Rejuvena.Backscatter
{
    /// <summary>
    ///     Utility <see cref="BindingFlags"/> combinations.
    /// </summary>
    public static class ReflectionFlags
    {
        public const BindingFlags PublicityFlags = BindingFlags.Public | BindingFlags.NonPublic;
        public const BindingFlags InstanceFlags = BindingFlags.Instance | BindingFlags.Static;
        public static readonly BindingFlags UniversalFlags = PublicityFlags | InstanceFlags;
    }
}