using System.Collections.Generic;
using System.Linq;

namespace KD.Converters.Collections
{
    /// <summary>
    /// Provides extension methods to convert any <see cref="IEnumerable{T}"/> to <see cref="Queue{T}"/>.
    /// </summary>
    public static class Queues
    {
        public static Queue<T> ToQueue<T>(this IEnumerable<T> source)
        {
            var queue = new Queue<T>();
            source.ToList().ForEach(model => queue.Enqueue(model));
            return queue;
        }
    }
}