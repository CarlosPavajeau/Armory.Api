using MediatR;

namespace Armory.Shared.Domain.Bus.Query
{
    public abstract class Query
    {
    }

    public abstract class Query<TResponse> : IRequest<TResponse>
    {
    }
}
