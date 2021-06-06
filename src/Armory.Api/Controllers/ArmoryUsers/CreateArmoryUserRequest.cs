namespace Armory.Api.Controllers.ArmoryUsers
{
    public class CreateArmoryUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
