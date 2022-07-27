using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Persistence;

namespace PhoneBook.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly PersonsDbContext Context;

        protected TestCommandBase()
        {
            Context = PersonsContextFactory.Create();
        }

        public void Dispose()
        {
            PersonsContextFactory.Destroy(Context);
        }
    }
}
