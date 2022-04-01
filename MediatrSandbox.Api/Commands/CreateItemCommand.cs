using MediatR;

using MediatrSandbox.Api.Dtos;

namespace MediatrSandbox.Api.Commands;

public class CreateItemCommand : IRequest<ItemDto>
{
    public string Title { get; set; }
    public string Description { get; set; }
}
