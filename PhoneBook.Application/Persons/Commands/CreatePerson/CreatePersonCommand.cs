using MediatR;

namespace PhoneBook.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
