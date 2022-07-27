using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Persons.Commands.CreatePerson;
using PhoneBook.Tests.Common;

namespace PhoneBook.Tests.Persons.Commands
{
    public class CreatePersonCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreatePersonCommandHandler_Success()
        {
            // Arrange
            var handler = new CreatePersonCommandHandler(Context);
            var personName = "person name";
            var personPhoneNumber = "+79130263558";

            // Act 
            var personId = await handler.Handle(
                new CreatePersonCommand
                {
                    Name = personName,
                    PhoneNumber = personPhoneNumber,
                    UserId = PersonsContextFactory.UserAId
                }, CancellationToken.None);

            // Assert 
            Assert.NotNull(
                await Context.Persons
                    .SingleOrDefaultAsync(person
                        => person.Id == personId
                           && person.UserId == PersonsContextFactory.UserAId
                           && person.Name == personName
                           && person.PhoneNumber == personPhoneNumber));
        }
    }
}