using System;

namespace Armory.Users.Application.GeneratePasswordResetToken
{
    public class PasswordResetTokenResponse
    {
        public string Token { get; }
        public bool TokenGenerated { get; }

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
    }
}
