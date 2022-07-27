using MediatR;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler
        : IRequestHandler<CreatePersonCommand, Guid>
    {
        private readonly IPersonsDbContext _context;

        public CreatePersonCommandHandler(IPersonsDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                UserId = request.UserId,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Id = Guid.NewGuid()
            };

            await _context.Persons.AddAsync(person, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return person.Id;
        }
    }
}
