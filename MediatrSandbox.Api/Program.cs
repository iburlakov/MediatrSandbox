using MediatR;

using MediatrSandbox.Api.Entities;
using MediatrSandbox.Api.Maping;
using MediatrSandbox.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddSingleton(typeof(IRepository<>), typeof(InMemoryRepository<>));

builder.Services.AddMediatR(typeof(AutomapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// seed
var itemsRepo = app.Services.GetService<IRepository<Item>>();
Enumerable.Range(1, 5).ToList().ForEach(i => itemsRepo.Create(new Item { Id = i, Title = $"item {i}", Description = "description" }));


app.Run();
