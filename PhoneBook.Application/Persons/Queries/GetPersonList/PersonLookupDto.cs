using AutoMapper;
using PhoneBook.Application.Common.Mappings;
using PhoneBook.Domain;

namespace PhoneBook.Application.Persons.Queries.GetPersonList
{
    public class PersonLookupDto : IMapWith<Person>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonLookupDto>()
                .ForMember(personDto => personDto.Id,
                    option => option.MapFrom(person => person.Id))
                .ForMember(personDto => personDto.Name,
                    option => option.MapFrom(person => person.Name));
        }
    }
}
