using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;
using PhoneBook.Persistence;

namespace PhoneBook.Tests.Common
{
    public class PersonsContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid PersonIdForDelete = Guid.NewGuid();
        public static Guid PersonIdForUpdate = Guid.NewGuid();

        public static PersonsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PersonsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PersonsDbContext(options);
            context.Database.EnsureCreated();

            #region Adding Persons to Db

            context.Persons.AddRange(
                new Person
                {
                    Name = "Name1",
                    PhoneNumber = "+79635241402",
                    Id = Guid.Parse("321c107a-4d7e-43c9-a521-6d48515c3400"),
                    UserId = UserAId
                },
                new Person
                {
                    Name = "Name2",
                    PhoneNumber = "012345678901",
                    Id = Guid.Parse("e806686d-5e79-4bf5-b10a-8efffe849d5f"),
                    UserId = UserBId
                },
                new Person
                {
                    Name = "Name3",
                    PhoneNumber = "012345678902",
                    Id = PersonIdForDelete,
                    UserId = UserAId
                },
                new Person
                {
                    Name = "Name4",
                    PhoneNumber = "012345678903",
                    Id = PersonIdForUpdate,
                    UserId = UserBId
                }
            );

            #endregion

            context.SaveChanges();
            return context;
        }

        public static void Destroy(PersonsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
