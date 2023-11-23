namespace LinqExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many even numbers to display?=");
            int n = Convert.ToInt32(Console.ReadLine());

            IEnumerable<int> query = from number in NumbersGenerator.AllNumbers()
                                     where number % 2 == 0
                                     select number;
            
            int i = 0;
            foreach (int number in query)
            {
                Console.Write($"{number}, ");
                i++;
                if (i >= n)
                {
                    break;
                }
            }

            Console.WriteLine();

            i = 0;
            foreach (int number in NumbersGenerator.AllNumbers().WhereIsEven())
            {
                Console.Write($"{number}, ");
                i++;
                if (i >= n)
                {
                    break;
                }
            }

            //PersonsDatabase.SaveToXml("Persons.xml");
            /*
            PersonsDatabase.ReadFromXml("Persons.xml");
            foreach (Person p in PersonsDatabase.AllPersons)
            {
                p.Print();
            }
            */
        }
    }
}