using Armory.Shared.Domain.Bus.Command;

namespace Armory.Troopers.Application.Create
{
    public class CreateTroopCommand : Command
    {
        public string Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public string LastName { get; }
        public string SecondLastName { get; }
        public string SquadCode { get; }
        public int DegreeId { get; }

        public CreateTroopCommand(string id, string firstName, string secondName, string lastName,
            string secondLastName, string squadCode, int degreeId)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            SquadCode = squadCode;
            DegreeId = degreeId;
        }
    }
}
