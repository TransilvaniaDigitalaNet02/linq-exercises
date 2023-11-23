namespace LinqExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PersonsDatabase.SaveToXml("Persons.xml");

            PersonsDatabase.ReadFromXml("Persons.xml");

            /*
            var query = from person in PersonsDatabase.AllPersons
                        where person.Age >= 50
                        select new
                        {
                            FullName = person.FullName,
                            DateOfBirth = person.DateOfBirth
                        };
            */

            var query = PersonsDatabase.AllPersons.OrderByDescending(person => person);
            
            foreach (Person p in query)
            {
                p.Print();
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