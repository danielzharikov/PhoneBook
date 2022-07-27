using MediatR;

namespace PhoneBook.Application.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQuery : IRequest<PersonDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
