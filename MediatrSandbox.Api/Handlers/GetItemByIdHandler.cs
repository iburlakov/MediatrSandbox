using AutoMapper;

using MediatR;

using MediatrSandbox.Api.Dtos;
using MediatrSandbox.Api.Entities;
using MediatrSandbox.Api.Queries;
using MediatrSandbox.Api.Repositories;

namespace MediatrSandbox.Api.Handlers;

public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, ItemDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Item> _itemRepository;

    public GetItemByIdHandler(IMapper mapper, IRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<ItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.Get(request.OrderId);
        return _mapper.Map<ItemDto>(item);
    }
}
