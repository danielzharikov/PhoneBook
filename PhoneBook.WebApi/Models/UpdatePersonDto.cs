using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Application.Common.Mappings;
using PhoneBook.Application.Persons.Commands.UpdatePerson;

namespace PhoneBook.WebApi.Models
{
    public class UpdatePersonDto : IMapWith<UpdatePersonCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonDto, UpdatePersonCommand>()
                .ForMember(updateDto => updateDto.Id,
                    options => options.MapFrom(command => command.Id))
                .ForMember(updateDto => updateDto.Name,
                    options => options.MapFrom(command => command.Name))
                .ForMember(updateDto => updateDto.PhoneNumber,
                    options => options.MapFrom(command => command.PhoneNumber));
        }
    }
}
