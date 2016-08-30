namespace ToStringConverter
{
    public class Printer
    {
        public static void Main()
        {
            Converter converter = new Converter();

            converter.Convert(true);
            converter.Convert(false);
        }
    }
}
