using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using PhoneBook.Persistence.EntityTypeConfigurations;

namespace PhoneBook.Persistence
{
    public sealed class PersonsDbContext : DbContext, IPersonsDbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) 
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
