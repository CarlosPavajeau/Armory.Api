namespace Armory.Users.Application.GenerateEmailConfirmationToken
{
    public class GenerateConfirmationTokenResponse
    {
        public string Token { get; }
        public bool TokenGenerated { get; }

        public GenerateConfirmationTokenResponse(string token)
        {
            Token = token;
            TokenGenerated = true;
        }

        public GenerateConfirmationTokenResponse()
        {
            Token = string.Empty;
            TokenGenerated = false;
        }
    }
}
