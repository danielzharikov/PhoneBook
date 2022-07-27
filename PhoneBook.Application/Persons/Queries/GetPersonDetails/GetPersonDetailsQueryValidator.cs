using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PhoneBook.Application.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryValidator : AbstractValidator<GetPersonDetailsQuery>
    {
        public GetPersonDetailsQueryValidator()
        {
            RuleFor(person => person.Id).NotEqual(Guid.Empty);
            RuleFor(person => person.UserId).NotEqual(Guid.Empty);
        }
    }
}
