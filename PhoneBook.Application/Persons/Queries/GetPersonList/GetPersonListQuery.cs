using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PhoneBook.Application.Persons.Queries.GetPersonList
{
    public class GetPersonListQuery : IRequest<PersonListVm>
    {
        public Guid UserId { get; set; }
    }
}
