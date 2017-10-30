using System;

namespace KD.Converters
{
    /// <summary>
    /// Provides extension methods <see cref="object"/>
    /// </summary>
    public static class Objects
    {
        public static object Clone(this object source, object[] args = null)
        {
            return Clone<object>(source, args);
        }

        public static T Clone<T>(this T source, object[] args = null)
        {
            var sourceType = source.GetType();
            // Create new instance
            T instance;
            if (args == null)
            {
                instance = Activator.CreateInstance<T>();
            }
            else
            {
                instance = (T)Activator.CreateInstance(sourceType, args);
            }
            // Copy all fields
            foreach (var field in sourceType.GetFields())
            {
                var value = field.GetValue(source);
                field.SetValue(instance, value);
            }
            return instance;
        }

        public static T Parse<T>(this object source)
        {
            return (T)source;
        }
    }
}