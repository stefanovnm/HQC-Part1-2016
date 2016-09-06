using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);
            Console.WriteLine();

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);
            Console.WriteLine();

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);
            Console.WriteLine();

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", 
                "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" }, 
                "Sofia");
            Console.WriteLine(offsiteCourse);
        }
    }
}
