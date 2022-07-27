using AutoMapper;
using PhoneBook.Application.Persons.Queries.GetPersonDetails;
using PhoneBook.Application.Persons.Queries.GetPersonList;
using PhoneBook.Persistence;
using PhoneBook.Tests.Common;
using Shouldly;

namespace PhoneBook.Tests.Persons.Queries
{
    [Collection("QueryCollection")]
    public class GetPersonDetailsQueryHandlerTests
    {
        private readonly PersonsDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPersonDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPersonDetailsQueryHandler(_context, _mapper);

            // Act
            var result = await handler.Handle(
                new GetPersonDetailsQuery
                {
                    UserId = PersonsContextFactory.UserBId,
                    Id = Guid.Parse("e806686d-5e79-4bf5-b10a-8efffe849d5f")
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonDetailsVm>();
            result.Name.ShouldBe("Name2");
            result.PhoneNumber.ShouldBe("012345678901");
        }
    }
}
