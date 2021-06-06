namespace Armory.Api.Controllers.ArmoryUsers.Authentication
{
    public class AuthenticationRequest
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
