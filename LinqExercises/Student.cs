namespace LinqExercises
{
    public class Student : Person
    {
        public Student(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            Gender gender,
            string university)
            : base(firstName, lastName, dateOfBirth, gender)
        {
            University = university ?? throw new ArgumentNullException(nameof(university));
        }



        public string University { get; }
    }
}
