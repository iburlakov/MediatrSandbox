using AutoMapper;

using MediatR;

using MediatrSandbox.Api.Commands;
using MediatrSandbox.Api.Dtos;
using MediatrSandbox.Api.Entities;
using MediatrSandbox.Api.Repositories;

namespace MediatrSandbox.Api.Handlers;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ItemDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Item> _itemRepository;

    public CreateItemCommandHandler(IMapper mapper, IRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<ItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _itemRepository.Create(_mapper.Map<Item>(request));
        var dto = _mapper.Map<ItemDto>(entity);

        return dto;
    }
}
