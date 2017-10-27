using System.Collections.Generic;
using System.Linq;

namespace KD.Converters.Collections
{
    /// <summary>
    /// Provides extension methods to convert any <see cref="IEnumerable{T}"/> to <see cref="Stack{T}"/>.
    /// </summary>
    public static class Stacks
    {
        public static Stack<T> ToStack<T>(this IEnumerable<T> source)
        {
            var stack = new Stack<T>();
            source.ToList().ForEach(model => stack.Push(model));
            return stack;
        }
    }
}