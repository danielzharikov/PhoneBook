using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PhoneBook.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(deletePersonCommand =>
                deletePersonCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deletePersonCommand =>
                deletePersonCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
