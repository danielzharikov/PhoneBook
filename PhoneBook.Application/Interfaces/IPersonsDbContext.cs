using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;

namespace PhoneBook.Application.Interfaces
{
    public interface IPersonsDbContext
    {
        DbSet<Person> Persons { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
