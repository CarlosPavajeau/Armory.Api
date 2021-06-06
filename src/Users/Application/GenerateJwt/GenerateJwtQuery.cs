using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.GenerateJwt
{
    public class GenerateJwtQuery : Query
    {
        public string Username { get; }

        public GenerateJwtQuery(string username)
        {
            Username = username;
        }
    }
}
