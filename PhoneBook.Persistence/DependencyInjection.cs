using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Interfaces;

namespace PhoneBook.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonsDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString(nameof(PersonsDbContext)));
            });
            services.AddScoped<IPersonsDbContext>(provider =>
                provider.GetService<PersonsDbContext>());
            return services;
        }
    }
}
