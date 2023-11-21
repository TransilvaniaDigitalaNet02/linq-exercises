﻿namespace LinqExercises
{
    public static class PersonsDatabase
    {
        private readonly static string[] CommonMaleFirstNames = { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Charles", "Joseph", "Thomas", "Christopher", "Daniel", "Paul", "Mark", "Donald", "Kenneth", "Steven", "Edward", "Brian", "Ronald", "Anthony", "Kevin", "Jason", "Jeff" };
        private readonly static string[] CommonFemaleFirstNames = { "Mary", "Patricia", "Maria", "Nancy", "Donna", "Laura", "Linda", "Susan", "Karen", "Carol", "Sarah", "Barbara", "Margaret", "Betty", "Ruth", "Kimberly", "Elizabeth", "Dorothy", "Helen", "Sharon", "Deborah" };
        private readonly static string[] CommonLastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker", "Young", "Allen", "King", "Wright", "Scott" };

        private static Lazy<List<Person>> persons = new Lazy<List<Person>>(
            () => GeneratePersons().ToList());

        public static IEnumerable<Person> AllPersons
        {
            get
            {
                return persons.Value;
            }
        }

        private static DateTime GenerateDateOfBirth(DateTime fromDate, Random randomizer)
        {
            var years = randomizer.Next(1, 70);
            var months = randomizer.Next(1, 12);
            var days = randomizer.Next(1, 100);

            var dateOfBirth = fromDate.AddYears(years).AddMonths(months).AddDays(days);
            return dateOfBirth;
        }

        private static IEnumerable<Person> GeneratePersons()
        {
            Console.WriteLine("Start GeneratePersons");

            var random = new Random();
            var startDate = new DateTime(1950, 1, 1);
            var idxLastNames = 0;

            foreach (var firstNames in CommonMaleFirstNames)
            {
                var birthDate = GenerateDateOfBirth(startDate, random);
                if (idxLastNames >= CommonLastNames.Length)
                {
                    idxLastNames = 0;
                }

                yield return new Person(firstNames, CommonLastNames[idxLastNames], birthDate, Gender.Male);
                idxLastNames++;
            }

            foreach (var firstNames in CommonFemaleFirstNames)
            {
                var birthDate = GenerateDateOfBirth(startDate, random);
                if (idxLastNames >= CommonLastNames.Length)
                {
                    idxLastNames = 0;
                }

                yield return new Person(firstNames, CommonLastNames[idxLastNames], birthDate, Gender.Female);
                idxLastNames++;
            }
        }
    }
}
