namespace LinqExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PersonsDatabase.SaveToXml("Persons.xml");
            PersonsDatabase.ReadFromXml("Persons.xml");

            /*
            IEnumerable<Person> query = PersonsDatabase
                .AllPersons
                .Where(person => person.Age >= 14 && person.FullName.StartsWith("D", StringComparison.OrdinalIgnoreCase));
            */

            IEnumerable<Person> query = from person in PersonsDatabase.AllPersons
                                        where person.Age >= 14 && person.FullName.StartsWith("D", StringComparison.OrdinalIgnoreCase)
                                        select person;

            foreach (Person p in query)
            {
                p.Print();
            }
        }
    }
}