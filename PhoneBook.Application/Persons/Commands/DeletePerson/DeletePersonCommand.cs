using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PhoneBook.Domain;

namespace PhoneBook.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
