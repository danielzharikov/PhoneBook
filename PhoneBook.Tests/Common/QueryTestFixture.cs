using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Application.Common.Mappings;
using PhoneBook.Application.Interfaces;
using PhoneBook.Persistence;

namespace PhoneBook.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public PersonsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = PersonsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new AssemblyMappingProfile(typeof(IPersonsDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            PersonsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
