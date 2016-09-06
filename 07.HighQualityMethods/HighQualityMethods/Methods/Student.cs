using System;
using System.Globalization;

namespace Methods
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            string firstDateAsString = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            string secondDateAsString = other.OtherInfo.Substring(other.OtherInfo.Length - 10);
            
            DateTime firstDate = DateTime.ParseExact(firstDateAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(secondDateAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return firstDate > secondDate;
        }
    }
}
