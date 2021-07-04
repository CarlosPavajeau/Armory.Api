namespace Armory.Api.Controllers.People.Requests
{
    public class CreatePersonRequest
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
    }
}
