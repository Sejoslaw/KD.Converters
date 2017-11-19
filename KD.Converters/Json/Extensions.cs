using System.IO;
using System.Runtime.Serialization.Json;

namespace KD.Converters.Json
{
    /// <summary>
    /// Extension methods used to convert to / from JSON.
    /// </summary>
    public static class Extensions
    {
        public static string ToJson<TSource>(this TSource source)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TSource));
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, source);
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                return json;
            }
        }
    }
}