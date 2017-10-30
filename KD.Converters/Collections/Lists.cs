using System.Collections.Generic;
using System.Linq;

namespace KD.Converters.Collections
{
    /// <summary>
    /// Provides extension methods to convert any <see cref="IEnumerable{T}"/> to <see cref="IList{T}"/>.
    /// </summary>
    public static class Lists
    {
        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> source)
        {
            var list = new LinkedList<T>();
            source.ToList().ForEach(model => list.AddLast(new LinkedListNode<T>(model)));
            return list;
        }

        public static IList<TValue> ToList<TValue, TListType>(this IEnumerable<TValue> source, object[] newListArgs = null)
            where TListType : IList<TValue>
        {
            TListType list = source.Clone(newListArgs).Parse<TListType>();
            source.ToList().ForEach(model => list.Add(model));
            return list;
        }
    }
}