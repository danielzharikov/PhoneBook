using AutoMapper;
using PhoneBook.Application.Common.Mappings;
using PhoneBook.Domain;

namespace PhoneBook.Application.Persons.Queries.GetPersonDetails;

public class PersonDetailsVm : IMapWith<Person>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Person, PersonDetailsVm>()
            .ForMember(personVm => personVm.Name,
                option => option.MapFrom(person => person.Name))
            .ForMember(personVm => personVm.PhoneNumber,
                option => option.MapFrom(person => person.PhoneNumber))
            .ForMember(personVm => personVm.Id,
                option => option.MapFrom(person => person.Id));
    }
}