using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Common.Exceptions;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler
        : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IPersonsDbContext _context;

        public UpdatePersonCommandHandler(IPersonsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Persons.FirstOrDefaultAsync(person =>
                    person.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            entity.Name = request.Name;
            entity.PhoneNumber = request.PhoneNumber;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
