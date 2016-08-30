using System;
using System.Net.Http.Headers;

namespace _02.PersonGenerator
{
    public class GeneratePerson
    {
        public static void Main()
        {
            var person = new Person(20);
            var secondPerson = new Person(21);

            Console.WriteLine(person);
            Console.WriteLine(secondPerson);
        }
    }
}
