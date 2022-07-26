using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Basics
{
    public abstract class Identity
    {
        public Guid Id { get; set; }
    }
}
