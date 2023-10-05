using Junior_ptmk.DB.DbContexts;
using Junior_ptmk.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior_ptmk.DB.Repo
{
    internal class Repository
    {
        /// <summary>
        /// Добавление человека в бд
        /// </summary>
        /// <param name="person"></param>

        public void DbCreate()
        {
            using (var MydbContext = new MyDbContext())
            {
                MydbContext.Database.EnsureCreated();
                Console.WriteLine("База данных создана.");
            }
        }
        public void DbAdd(Person person)
        {

            using (MyDbContext db = new MyDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                // создаем объект Person
                Person user1 = new Person { Name = person.Name, LastName = person.LastName, FatherName = person.FatherName, Gender = person.Gender, DateOfBirth = person.DateOfBirth };
                // добавляем в бд
                db.Persons.AddRange(user1);
                Console.WriteLine($"{person.LastName} {person.Name} {person.FatherName} добавлен в базу данных");
                db.SaveChanges();
            }
        }
        public void DbAdd(List<Person> PersonLst)
        {
            // TODO: передалать на отправку Json формата
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // добавляем в бд список людей
                foreach (Person person in PersonLst)
                {
                    Person user1 = new Person { LastName = person.LastName, Name = person.Name, FatherName = person.FatherName, Gender = person.Gender, DateOfBirth = person.DateOfBirth };
                    db.Persons.AddRange(user1);
                }
                db.SaveChanges();
                DbRead();
            }

        }
        public void DbRead()
        {
            using (MyDbContext db = new MyDbContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Persons.ToList();
                Console.WriteLine("Users list:");
                foreach (Person u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.LastName} {u.Name} {u.FatherName}, Полных лет: {u.YearsOld(u)}");
                }
            }
        }
        
        public void DbSearch()
        {
            var sw = new Stopwatch();
            sw.Start();

            #region SQL Raw
            //using (var db = new MyDbContext())
            //{
            //    var comps = db.Persons.FromSqlRaw("SELECT \"Id\", \"Name\", \"LastName\", \"FatherName\", \"DateOfBirth\", \"Gender\"\r\n\tFROM public.\"Persons\" WHERE \"Gender\"=1 AND \"LastName\" LIKE 'F%';").ToList();
            //    foreach (var u in comps)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.LastName} {u.Name} {u.FatherName}, Полных лет: {u.YearsOld(u)}");
            //    }
            //}
            #endregion

            #region LINQ Full
            using (MyDbContext db = new MyDbContext())
            {
                var persons = (from person in db.Persons
                               where person.Gender == PersonGender.Male && person.LastName.StartsWith("F")
                               select person).ToList();
                foreach (Person u in persons)
                {
                    {
                        Console.WriteLine($"{u.Id}.{u.LastName} {u.Name} {u.FatherName}, Полных лет: {u.YearsOld(u)}");
                    }
                }
            }
            #endregion

            #region All persons
            using (MyDbContext db = new MyDbContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Persons.ToList();
                foreach (Person u in users)
                {
                    if (u.LastName.StartsWith("F") && u.Gender == PersonGender.Male)
                    {


                        Console.WriteLine($"{u.Id}.{u.LastName} {u.Name} {u.FatherName}, Полных лет: {u.YearsOld(u)}");
                    }
                }
            }
            #endregion


            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Время работы программы:" + sw.Elapsed);
        }
    }
}
