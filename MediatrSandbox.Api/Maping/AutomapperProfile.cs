using AutoMapper;

using MediatrSandbox.Api.Commands;
using MediatrSandbox.Api.Dtos;
using MediatrSandbox.Api.Entities;

namespace MediatrSandbox.Api.Maping;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ReverseMap();

        CreateMap<Item, ItemDto>()
           .ReverseMap();

        CreateMap<CreateItemCommand, Item>();
    }
}
