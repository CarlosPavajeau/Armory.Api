using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Create
{
    public class CreatePersonCommand : Command
    {
        public string Id { get; }

        public string FirstName { get; }
        public string SecondName { get; }
        public string LastName { get; }
        public string SecondLastName { get; }

        public string ArmoryUserId { get; }

        public CreatePersonCommand(string id, string firstName, string secondName, string lastName,
            string secondLastName, string armoryUserId)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            ArmoryUserId = armoryUserId;
        }
    }
}
