using Armory.Shared.Domain.Bus.Command;

namespace Armory.Troopers.Application.Create
{
    public class CreateTroopCommand : Command
    {
        public CreateTroopCommand(string id, string firstName, string secondName, string lastName,
            string secondLastName, string fireteamCode, int degreeId)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            FireteamCode = fireteamCode;
            DegreeId = degreeId;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public string LastName { get; }
        public string SecondLastName { get; }
        public string FireteamCode { get; }
        public int DegreeId { get; }
    }
}
