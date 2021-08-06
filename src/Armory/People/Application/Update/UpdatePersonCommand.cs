using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Update
{
    public class UpdatePersonCommand : Command
    {
        public UpdatePersonCommand(string id, string firstName, string secondName, string lastName,
            string secondLastName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public string LastName { get; }
        public string SecondLastName { get; }
    }
}
