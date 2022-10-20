using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleCRM
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Assembly.GetExecutingAssembly().Location
                          .Replace(Assembly.GetExecutingAssembly().ManifestModule.Name, "") +
                          "People.xml");

            List<Person> PeopleGenerated = GeneratePeople();

            SavePeopleToXml(PeopleGenerated, path);

            var people = GetPeopleFromXml(path);
        }

        private static List<Person> GeneratePeople()
        {
            var person1 = new NaturalPerson()
            {
                LastName = "Смит",
                FirstName = "Бабиджон",
                FatherName = "Бабиджонович",
            };
            var person2 = new NaturalPerson()
            {
                LastName = "Смит",
                FirstName = "Джон",
                FatherName = "Бабиджонович",
            };
            var person3 = new NaturalPerson()
            {
                LastName = "Смит",
                FirstName = "Джон",
                FatherName = "Лунтикович",
            };
            var person4 = new NaturalPerson()
            {
                LastName = "Джоли",
                FirstName = "Анджелика",
                FatherName = "Бредовна",
            };
            var person5 = new NaturalPerson()
            {
                LastName = "Питт",
                FirstName = "Бред",
                FatherName = "Анджеликович",
            };

            var PeopleGenerated = new List<Person> {
                new JuridicalPerson()
                {
                    CompanyName = "Рога и Копыта",
                    AffiliatedPeople = new List<NaturalPerson>(){person1,person2,person3}
                },
                new JuridicalPerson()
                {
                    CompanyName = "Rogue and Copeta",
                    AffiliatedPeople = new List<NaturalPerson>(){person4,person5}
                }
            };

            PeopleGenerated.AddRange(new NaturalPerson[] { person1, person2, person3, person4, person5 });

            foreach (var person in PeopleGenerated)
            {
                person.GUID = Guid.NewGuid();
                person.DateCreated = new DateTime();
                person.DateModified = DateTime.Now;
                person.InitialCreator = "Администратор";
                person.LastEditor = "Джон";
                person.INN = "12345678901";
                person.BIN = "12345678901";
            }

            return PeopleGenerated;
        }

        static IEnumerable<Person> GetPeopleFromXml(string path)
        {
            XDocument doc = XDocument.Load(path);

            var people = doc.Descendants(nameof(Person));

            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            foreach (var person in people)
            {
                var c = (Person)serializer.Deserialize(person.CreateReader());
                yield return c;
            }
        }

        public static void SavePeopleToXml(List<Person> xd,string path)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, xd);
            }
        }
    }

    [XmlInclude(typeof(NaturalPerson))]
    [XmlInclude(typeof(JuridicalPerson))]
    public abstract class Person
    {
        public Guid GUID;
        public string BIN;
        public string INN;
        public DateTime DateCreated;
        public DateTime DateModified;
        public string InitialCreator;
        public string LastEditor;
    }

    public class NaturalPerson : Person
    {
        public string FirstName;
        public string LastName;
        public string FatherName;
    }

    public class JuridicalPerson : Person
    {
        public string CompanyName;
        public List<NaturalPerson> AffiliatedPeople = new List<NaturalPerson>();
    }
}
