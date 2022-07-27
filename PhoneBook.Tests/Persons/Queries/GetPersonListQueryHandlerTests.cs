using AutoMapper;
using PhoneBook.Application.Persons.Queries.GetPersonList;
using PhoneBook.Persistence;
using PhoneBook.Tests.Common;
using Shouldly;

namespace PhoneBook.Tests.Persons.Queries
{
    [Collection("QueryCollection")]
    public class GetPersonListQueryHandlerTests : TestCommandBase
    {
        private readonly PersonsDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPersonListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPersonListQueryHandler(_context, _mapper);

            // Act
            var result = await handler.Handle(
                new GetPersonListQuery
                {
                    UserId = PersonsContextFactory.UserBId
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonListVm>();
            result.Persons.Count.ShouldBe(2);
        }
    }
}
