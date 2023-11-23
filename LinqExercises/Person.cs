namespace LinqExercises
{
    public class Person : IComparable<Person>
    {
        public Person(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get;
        }

        public string LastName
        {
            get;
        }

        public string FullName
            => $"{FirstName} {LastName}";

        public Gender Gender
        {
            get;
        }

        public DateTime DateOfBirth
        {
            get;
        }

        public int Age
            => DateTime.Today.Year - DateOfBirth.Year;

        public int CompareTo(Person? other)
        {
            if (other is null)
            {
                return 1;
            }

            return DateOfBirth.CompareTo(other.DateOfBirth);
        }

        public void Print()
        {
            Console.WriteLine($"{FullName} date of birth: {DateOfBirth:yyyy-MM-dd}, age: {Age}");
        }
    }
}
