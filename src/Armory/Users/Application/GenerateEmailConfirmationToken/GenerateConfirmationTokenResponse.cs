namespace Armory.Users.Application.GenerateEmailConfirmationToken
{
    public class GenerateConfirmationTokenResponse
    {
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

        public string Token { get; }
        public bool TokenGenerated { get; }
    }
}
