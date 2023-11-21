namespace LinqExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Person> persons1 = PersonsDatabase.AllPersons;
            IEnumerable<Person> persons2 = PersonsDatabase.AllPersons;
            IEnumerable<Person> persons3 = PersonsDatabase.AllPersons;
            Console.WriteLine("Accessed list of persons");
        }
    }
}