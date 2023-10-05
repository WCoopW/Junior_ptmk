using Junior_ptmk.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior_ptmk.DB.Repo
{
    internal class RndPerson
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        public List<Person> GeneratePersons(int count)
        {
            List<Person> Persons = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var person = GenerateRandomPerson(i);
                Persons.Add(person);
            }
            return Persons;
        }
        public Person GenerateRandomPerson(int j)
        {
            var num = rnd.Next(0,2);
            var person = new Person();
            person.Name = GenerateRandomName();
            if (j < 100)
            {
                person.LastName = GenerateRandomName('F');
            }
            else
            {
                person.LastName = GenerateRandomName();
            }
            person.FatherName = GenerateRandomName();
            person.Gender = num == 0? PersonGender.Male : PersonGender.Female;
            person.DateOfBirth = Convert.ToString(RandomDay());
            return person;
        }
        private string GenerateRandomName(char? first = null)
        {
            var maxLetter = rnd.Next(5, 15);
            string Name = "";
            if ( first != null)
            {
                Name = Name + first;
            }
            
            for (int i = 0; i < maxLetter; i++)
            {
                int num = rnd.Next(0, 26); // 26 букв в алфавите
                char letter = (char)('A' + num); // Начало алфавита
                Name = Name + letter;
            }
            return Name;
        }
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1970, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }

    }
}