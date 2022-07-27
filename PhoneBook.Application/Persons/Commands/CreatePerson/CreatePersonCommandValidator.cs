using FluentValidation;

namespace PhoneBook.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(createPersonCommand =>
                createPersonCommand.PhoneNumber).NotEmpty().MaximumLength(12);
            RuleFor(createPersonCommand =>
                createPersonCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createPersonCommand =>
                createPersonCommand.Name).NotEmpty().MaximumLength(512);
        }
    }
}
