using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Interfaces;

namespace PhoneBook.Application.Persons.Queries.GetPersonList
{
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, PersonListVm>
    {
        private readonly IPersonsDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandler(IPersonsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonListVm> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var personQuery = await _context.Persons
                .Where(person => person.UserId == request.UserId)
                .ProjectTo<PersonLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new PersonListVm { Persons = personQuery };
        }
    }
}
