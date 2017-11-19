using KD.Converters.Json;
using System;
using System.Runtime.Serialization;

namespace Tests
{
    [DataContract]
    class Person
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Id = 1, Name = "Krzysztof" };
            string json = p.ToJson();
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
