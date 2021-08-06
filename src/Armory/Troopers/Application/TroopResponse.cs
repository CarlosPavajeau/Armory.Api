using Armory.Troopers.Domain;

namespace Armory.Troopers.Application
{
    public class TroopResponse
    {
        public TroopResponse(string id, string firstName, string secondName, string lastName, string secondLastName,
            string squadCode, int degreeId)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            SquadCode = squadCode;
            DegreeId = degreeId;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public string LastName { get; }
        public string SecondLastName { get; }
        public string SquadCode { get; }
        public int DegreeId { get; }

        public static TroopResponse FromAggregate(Troop troop)
        {
            return new TroopResponse(troop.Id, troop.FirstName, troop.SecondName, troop.LastName, troop.SecondLastName,
                troop.SquadCode, troop.DegreeId);
        }
    }
}
