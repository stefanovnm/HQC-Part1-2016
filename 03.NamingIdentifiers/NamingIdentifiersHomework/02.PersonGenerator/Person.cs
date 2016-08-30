namespace _02.PersonGenerator
{
    public class Person
    {
        public Person(int age)
        {
            this.Age = age;

            if (this.Age % 2 == 0)
            {
                this.Name = "Батката";
                this.Gender = Gender.Man;
            }
            else
            {
                this.Name = "Мацето";
                this.Gender = Gender.Woman;
            }
        }

        public Person(Gender gender, string name, int age)
        {
            this.Gender = gender;
            this.Name = name;
            this.Age = age;
        }

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("{1} is {0}. Age: {2}", this.Gender, this.Name, this.Age);
        }
    }
}