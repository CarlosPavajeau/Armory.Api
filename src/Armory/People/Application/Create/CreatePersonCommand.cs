using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Create
{
    public class CreatePersonCommand : Command
    {
        public string Id { get; init; }

        public string FirstName { get; init; }
        public string SecondName { get; init; }
        public string LastName { get; init; }
        public string SecondLastName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public int DegreeId { get; init; }
    }
}
