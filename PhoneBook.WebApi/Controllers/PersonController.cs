using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Persons.Commands.CreatePerson;
using PhoneBook.Application.Persons.Commands.DeletePerson;
using PhoneBook.Application.Persons.Commands.UpdatePerson;
using PhoneBook.Application.Persons.Queries.GetPersonDetails;
using PhoneBook.Application.Persons.Queries.GetPersonList;
using PhoneBook.WebApi.Models;

namespace PhoneBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        private readonly IMapper _mapper;

        public PersonController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListVm>> GetAll()
        {
            var query = new GetPersonListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDetailsVm>> Get(Guid id)
        {
            var query = new GetPersonDetailsQuery
            {
                Id = id,
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePersonDto createPersonDto)
        {
            var command = _mapper.Map<CreatePersonCommand>(createPersonDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePersonDto updatePersonDto)
        {
            var command = _mapper.Map<UpdatePersonCommand>(updatePersonDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePersonCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
