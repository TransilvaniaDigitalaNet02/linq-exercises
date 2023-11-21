namespace LinqExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PersonsDatabase.SaveToXml("Persons.xml");
            PersonsDatabase.ReadFromXml("Persons.xml");
            foreach (Person p in PersonsDatabase.AllPersons)
            {
                p.Print();
            }
        }
    }
}