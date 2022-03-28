using MediatR;

using MediatrSandbox.Api.Dtos;

namespace MediatrSandbox.Api.Queries;

public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
{

}
