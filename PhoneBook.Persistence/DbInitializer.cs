using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PersonsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
