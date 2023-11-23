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

            var query = PersonsDatabase.AllPersons
                .Where(person => person.Age >= 50)
                .Select(person => new
                {
                    FullName = person.FullName,
                    DateOfBirth = person.DateOfBirth
                });

            foreach (var obj in query)
            {
                Console.WriteLine($"{obj.FullName} - {obj.DateOfBirth:yyyy-MM-dd}");
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