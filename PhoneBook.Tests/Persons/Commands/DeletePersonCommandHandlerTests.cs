using PhoneBook.Application.Common.Exceptions;
using PhoneBook.Application.Persons.Commands.CreatePerson;
using PhoneBook.Application.Persons.Commands.DeletePerson;
using PhoneBook.Tests.Common;

namespace PhoneBook.Tests.Persons.Commands
{
    public class DeletePersonCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeletePersonCommandHandler_Success()
        {
            // Arrange
            var handler = new DeletePersonCommandHandler(Context);

            // Act 
            await handler.Handle(new DeletePersonCommand
            {
                Id = PersonsContextFactory.PersonIdForDelete,
                UserId = PersonsContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Persons.SingleOrDefault(person =>
                person.Id == PersonsContextFactory.PersonIdForDelete));
        }

        [Fact]
        public async Task DeletePersonCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeletePersonCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new DeletePersonCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = PersonsContextFactory.UserAId
                }, CancellationToken.None));
        }

        [Fact]
        public async Task DeletePersonCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeletePersonCommandHandler(Context);
            var createHandler = new CreatePersonCommandHandler(Context);
            var personId = await createHandler.Handle(new CreatePersonCommand
            {
                Name = "Name1",
                PhoneNumber = "012345678903",
                UserId = PersonsContextFactory.UserAId
            }, CancellationToken.None);
            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(new DeletePersonCommand
                {
                    Id = personId,
                    UserId = PersonsContextFactory.UserBId
                }, CancellationToken.None));
        }
    }
}
