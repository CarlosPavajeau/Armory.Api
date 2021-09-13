using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Create
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(string id, string firstName, string secondName, string lastName,
            string secondLastName, string email, string phoneNumber, string roleName, int degreeId)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            Email = email;
            PhoneNumber = phoneNumber;
            RoleName = roleName;
            DegreeId = degreeId;
        }

        public string Id { get; }

        public string FirstName { get; }
        public string SecondName { get; }
        public string LastName { get; }
        public string SecondLastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }

        public string RoleName { get; }
        public int DegreeId { get; }
    }
}
