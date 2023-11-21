using System.Globalization;
using System.Xml.Linq;

namespace LinqExercises
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public static void SaveToXml(string fileName)
        {
            // <Persons>
            //   <Person firstName="John" lastName="Doe" gender="Male" dateOfBirth="1970-11-21"></Person>
            // </Persons>

            XElement persons = new XElement("Persons");
            foreach (var p in PersonsDatabase.AllPersons)
            {
                XElement person = new XElement("Person");
                person.Add(new XAttribute("firstName", p.FirstName));
                person.Add(new XAttribute("lastName", p.LastName));
                person.Add(new XAttribute("gender", Enum.Format(typeof(Gender), p.Gender, "G")));
                person.Add(new XAttribute("dateOfBirth", p.DateOfBirth.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));

                persons.Add(person);
            }

            persons.Save(fileName);
        }

        public static void ReadFromXml(string filePath)
        {
            XElement persons = XElement.Load(filePath);

            List<Person> xmlPersons = new List<Person>();
            foreach (XElement personElement in persons.Descendants("Person"))
            {
                string firstName = personElement.Attribute("firstName")?.Value;
                if (string.IsNullOrEmpty(firstName))
                {
                    continue;
                }

                string lastName = personElement.Attribute("lastName")?.Value;
                if (string.IsNullOrEmpty(lastName))
                {
                    continue;
                }

                string genderString = personElement.Attribute("gender")?.Value;
                if (string.IsNullOrEmpty(genderString) ||
                    !Enum.TryParse(genderString, out Gender parsedGender))
                {
                    continue;
                }

                string dateOfBirthString = personElement.Attribute("dateOfBirth")?.Value;
                if (string.IsNullOrEmpty(dateOfBirthString) ||
                    !DateTime.TryParseExact(
                        dateOfBirthString,
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime parsedDateOfBirth))
                {
                    continue;
                }

                Person p = new Person(firstName, lastName, parsedDateOfBirth, parsedGender);
                xmlPersons.Add(p);
            }

            PersonsDatabase.persons = new Lazy<List<Person>>(
                () => xmlPersons);
        }
    }
}
