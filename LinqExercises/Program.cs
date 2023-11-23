namespace LinqExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PersonsDatabase.SaveToXml("Persons.xml");

            // PersonsDatabase.ReadFromXml("Persons.xml");

            /*
            var query = from person in PersonsDatabase.AllPersons
                        where person.Age >= 50
                        select new
                        {
                            FullName = person.FullName,
                            DateOfBirth = person.DateOfBirth
                        };
            */

            int[] set1 = { 1, 2, 3, 4, 5 };
            int[] set2 = { 9, 8, 7, 6, 5 };
            // (1, 9), (1, 8), (1, 7), (1, 6), (1, 5)
            // (2, 9), (2, 8), (2, 7), (2, 6), (2, 5)
            // (3, 9), (3, 8), (3, 7), (3, 6), (3, 5)
            // (4, 9), (4, 8), (4, 7), (4, 6), (4, 5)

            IEnumerable<string> query = from elem1 in set1
                                        from elem2 in set2
                                        where Math.Abs(elem2 - elem1) == 1
                                        select $"({elem1},{elem2})";

            IEnumerable<string> query2 = set1.SelectMany(
                elem1 => set2,
                (elem1, elem2) => new
                {
                    Elem1 = elem1,
                    Elem2 = elem2
                })
                .Where(pair => Math.Abs(pair.Elem2 - pair.Elem1) == 1)
                .Select(pair => $"({pair.Elem1},{pair.Elem2})");


            foreach (string pairs in query) { Console.Write(pairs + ", "); }

            Console.WriteLine();
            Console.WriteLine();

            foreach (string pairs in query2) { Console.Write(pairs + ", "); }

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