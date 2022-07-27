using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Common.Exceptions;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Application.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler 
        : IRequestHandler<GetPersonDetailsQuery, PersonDetailsVm>
    {
        private readonly IPersonsDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonDetailsQueryHandler(IPersonsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonDetailsVm> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons
                .FirstOrDefaultAsync(person => person.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            return _mapper.Map<PersonDetailsVm>(entity);
        }
    }
}
