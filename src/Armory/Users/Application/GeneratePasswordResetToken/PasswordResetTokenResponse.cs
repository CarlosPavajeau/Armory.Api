namespace Armory.Users.Application.GeneratePasswordResetToken
{
    public class PasswordResetTokenResponse
    {
        public PasswordResetTokenResponse(string token)
        {
            Token = token;
            TokenGenerated = true;
        }

        public PasswordResetTokenResponse()
        {
            Token = string.Empty;
            TokenGenerated = false;
        }

        public string Token { get; }
        public bool TokenGenerated { get; }
    }
}
