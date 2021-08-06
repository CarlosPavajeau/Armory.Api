using Armory.People.Domain;

namespace Armory.People.Application
{
    public class PersonResponse
    {
        public PersonResponse(string id, string firstName, string secondName, string lastName, string secondLastName)
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

        public static PersonResponse FromAggregate(Person person)
        {
            return new PersonResponse(person.Id, person.FirstName, person.SecondName, person.LastName,
                person.SecondLastName);
        }
    }
}
