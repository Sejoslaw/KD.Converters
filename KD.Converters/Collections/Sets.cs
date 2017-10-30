using System.Collections.Generic;
using System.Linq;

namespace KD.Converters.Collections
{
    /// <summary>
    /// Provides extension methods to convert any <see cref="IEnumerable{T}"/> to <see cref="ISet{T}"/>.
    /// </summary>
    public static class Sets
    {
        public static SortedSet<TValue> ToSortedSet<TValue>(this IEnumerable<TValue> source)
        {
            return (SortedSet<TValue>)ToSet<TValue, SortedSet<TValue>>(source);
        }

        // By default LINQ adds method called ToHashSet
        public static HashSet<TValue> ToSet<TValue>(this IEnumerable<TValue> source)
        {
            return (HashSet<TValue>)ToSet<TValue, HashSet<TValue>>(source);
        }

        public static ISet<TValue> ToSet<TValue, TSetType>(this IEnumerable<TValue> source, object[] newSetArgs = null)
            where TSetType : ISet<TValue>
        {
            TSetType set = source.Clone(newSetArgs).Parse<TSetType>();
            source.ToList().ForEach(model => set.Add(model));
            return set;
        }
    }
}