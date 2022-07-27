using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Common.Exceptions;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandHandler
        : IRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonsDbContext _context;

        public DeletePersonCommandHandler(IPersonsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons
                .FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
