using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PhoneBook.Application.Persons.Queries.GetPersonList
{
    public class GetPersonListQueryValidator : AbstractValidator<GetPersonListQuery>
    {
        public GetPersonListQueryValidator()
        {
            RuleFor(person => person.UserId).NotEqual(Guid.Empty);
        }
    }
}
