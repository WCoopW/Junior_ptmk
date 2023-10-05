using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior_ptmk.DB.Model
{
    internal class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string DateOfBirth { get; set; }

        public PersonGender Gender { get; set; }

        public int YearsOld(Person person)
        {
            DateTime now = DateTime.Today;
            var DoB = DateTime.Parse(person.DateOfBirth);
            int age = now.Year - DoB.Year;
            if (DoB > now.AddYears(-age)) age--;
            return age;
        }
      
    }
   
    public enum PersonGender
    {
        Male,
        Female
    }

}
