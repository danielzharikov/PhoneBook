using PhoneBook.Domain.Basics;

namespace PhoneBook.Domain
{
    public class Person : Identity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
