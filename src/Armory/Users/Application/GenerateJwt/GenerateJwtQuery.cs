using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.GenerateJwt
{
    public class GenerateJwtQuery : Query<string>
    {
        public GenerateJwtQuery(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
