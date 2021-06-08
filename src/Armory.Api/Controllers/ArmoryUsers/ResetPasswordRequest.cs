namespace Armory.Api.Controllers.ArmoryUsers
{
    public class ResetPasswordRequest
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
