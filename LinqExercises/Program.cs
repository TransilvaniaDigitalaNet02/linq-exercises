namespace LinqExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PersonsDatabase.SaveToXml("Persons.xml");

            PersonsDatabase.ReadFromXml("Persons.xml");

            IEnumerable<string> query = PersonsDatabase.AllPersons.Select(person => person.FullName);
            foreach (string fullName in query)
            {
                Console.WriteLine(fullName);
            }


            //foreach (Person p in query)
            //{
            //    p.Print();
            //}
        }
    }

    public class PersonWithIndex
    {
        public Person Person { get; set; }

        public int Index { get; set; }
    }
}