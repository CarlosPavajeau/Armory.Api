using Armory.Shared.Domain.Bus.Command;

namespace Armory.Troopers.Application.Update
{
    public class UpdateTroopCommand : Command
    {
        public UpdateTroopCommand(string id, string firstName, string secondName, string lastName,
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
