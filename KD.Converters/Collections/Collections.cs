using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KD.Converters.Collections
{
    /// <summary>
    /// Provides extension methods to convert any <see cref="IEnumerable{T}"/> to <see cref="ICollection{T}"/>.
    /// </summary>
    public static class Collections
    {
        public static Collection<TValue> ToCollection<TValue>(this IEnumerable<TValue> source)
        {
            return (Collection<TValue>)ToCollection<TValue, Collection<TValue>>(source);
        }

        public static ICollection<TValue> ToCollection<TValue, TCollectionType>(this IEnumerable<TValue> source, object[] newCollectionArgs = null)
            where TCollectionType : ICollection<TValue>
        {
            TCollectionType coll;
            if (newCollectionArgs == null)
            {
                coll = Activator.CreateInstance<TCollectionType>();
            }
            else
            {
                coll = (TCollectionType)Activator.CreateInstance(typeof(TCollectionType), newCollectionArgs);
            }
            source.ToList().ForEach(model => coll.Add(model));
            return coll;
        }
    }
}