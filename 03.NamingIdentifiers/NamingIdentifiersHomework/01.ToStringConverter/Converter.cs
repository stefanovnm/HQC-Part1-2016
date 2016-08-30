using System;

namespace ToStringConverter
{
    public class Converter
    {
        public Converter()
        { 
        }

        public void Convert(bool value)
        {
            string valueAsString = value.ToString();
            Console.WriteLine(valueAsString);
        }
    }
}
