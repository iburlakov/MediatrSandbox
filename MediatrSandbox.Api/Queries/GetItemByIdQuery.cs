using MediatR;

using MediatrSandbox.Api.Dtos;

namespace MediatrSandbox.Api.Queries;

public class GetItemByIdQuery : IRequest<ItemDto>
{
    public int OrderId { get; }

    public GetItemByIdQuery(int id)
    {
        OrderId = id;
    }
}