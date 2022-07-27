using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PhoneBook.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(updatePersonCommand =>
                updatePersonCommand.Name).NotEmpty().MaximumLength(512);
            RuleFor(updatePersonCommand =>
                updatePersonCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updatePersonCommand =>
                updatePersonCommand.PhoneNumber).NotEmpty().MaximumLength(12);
            RuleFor(updatePersonCommand =>
                updatePersonCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
