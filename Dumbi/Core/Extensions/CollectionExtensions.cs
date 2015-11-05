namespace Dumbi.Core.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions for collections
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Determines whether the given collection is null / empty or not.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Returns a non-nullable collection, if the input collection is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToSafe<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                source = new List<T>();
            }

            return source;
        }
    }
}
