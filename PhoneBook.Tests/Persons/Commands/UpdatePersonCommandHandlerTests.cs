using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Common.Exceptions;
using PhoneBook.Application.Persons.Commands.UpdatePerson;
using PhoneBook.Tests.Common;

namespace PhoneBook.Tests.Persons.Commands
{
    public class UpdatePersonCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdatePersonCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdatePersonCommandHandler(Context);
            var updatedName = "neww Name";

            // Act
            await handler.Handle(new UpdatePersonCommand
            {
                Id = PersonsContextFactory.PersonIdForUpdate,
                UserId = PersonsContextFactory.UserBId,
                Name = updatedName,
                PhoneNumber = "012345678905"
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Persons.SingleOrDefaultAsync(person =>
                    person.Id == PersonsContextFactory.PersonIdForUpdate && person.Name == updatedName));
        }

        [Fact]
        public async Task UpdatePersonCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdatePersonCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new UpdatePersonCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = PersonsContextFactory.UserAId
                }, CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePersonCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdatePersonCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new UpdatePersonCommand
                {
                    Id = PersonsContextFactory.PersonIdForUpdate,
                    UserId = Guid.NewGuid()
                }, CancellationToken.None));
        }
    }
}
