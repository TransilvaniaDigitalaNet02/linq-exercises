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

            
            IEnumerable<IGrouping<int, Person>> query = PersonsDatabase.AllPersons
                .GroupBy(person => person.DateOfBirth.Year)
                .OrderBy(group => group.Key);
            
            
            /*
            IEnumerable<IGrouping<int, Person>> query = from person in PersonsDatabase.AllPersons
                                                        orderby person.DateOfBirth.Year
                                                        group person by person.DateOfBirth.Year;
            */

            foreach (IGrouping<int, Person> group in query)
            {
                Console.WriteLine($"People born in {group.Key}");
                foreach (Person p in group)
                {
                    p.Print();
                }
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