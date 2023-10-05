using Junior_ptmk.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior_ptmk.DB.DbContexts
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();
        public MyDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=clarke12324231");
        }
    }
}
