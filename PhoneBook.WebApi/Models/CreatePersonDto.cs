using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Application.Common.Mappings;
using PhoneBook.Application.Persons.Commands.CreatePerson;

namespace PhoneBook.WebApi.Models
{
    public class CreatePersonDto : IMapWith<CreatePersonCommand>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonDto, CreatePersonCommand>()
                .ForMember(personDto => personDto.Name,
                    options => options.MapFrom(command => command.Name))
                .ForMember(personDto => personDto.PhoneNumber,
                    options => options.MapFrom(command => command.PhoneNumber));
        }
    }
}
