using AutoMapper;

using MediatR;

using MediatrSandbox.Api.Dtos;
using MediatrSandbox.Api.Entities;
using MediatrSandbox.Api.Queries;
using MediatrSandbox.Api.Repositories;

namespace MediatrSandbox.Api.Handlers;

public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Item> _itemRepository;

    public GetAllItemsHandler(IMapper mapper, IRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAll();

        return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemDto>>(items);
    }
}
