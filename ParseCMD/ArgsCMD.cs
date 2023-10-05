using Junior_ptmk.DB.Model;
using Junior_ptmk.DB.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior_ptmk.ParseCMD
{
    internal class ArgsCMD
    {
        Repository repo = new Repository();
        public Person ParsePerson(string[] args)
        {
           
            try
            {
                var person = new Person();
                var FullName = args[1].Split(' ');
                person.Name = FullName[0];
                person.LastName = FullName[1];
                person.FatherName = FullName[2];
                person.DateOfBirth = args[2];
                if (args[3].ToLower().Contains("male"))
                {
                    person.Gender = PersonGender.Male;
                }
                if (args[3].ToLower().Contains("female"))
                {

                    person.Gender = PersonGender.Female;
                }
                repo.DbAdd(person);
                return person;
            }
            catch
            {
                throw new Exception("Ошибка входных данных.");
            }
        }
        public void EnableProgram(string[] args)
        {
            var program = Convert.ToInt32(args[0]);
            switch (program)
            {
                case 1:
                    repo.DbCreate();
                    break;
                case 2:
                    ParsePerson(args);
                    break;
                case 3:
                    repo.DbRead();
                    break;
                case 4:
                    var rndPers = new RndPerson();
                    var personLst =rndPers.GeneratePersons(100000);
                    repo.DbAdd(personLst);
                    break;
                case 5:
                    repo.DbSearch();
                    break;
                default:
                    Console.WriteLine("Ошибка при запуске программы.");
                    break;

            }
        }
    }
}
