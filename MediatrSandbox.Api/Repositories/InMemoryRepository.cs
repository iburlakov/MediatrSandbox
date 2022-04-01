using MediatrSandbox.Api.Entities;

namespace MediatrSandbox.Api.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : EntityBase
{
    private readonly IDictionary<int, T> _entities = new Dictionary<int, T>();

    public Task<T> Create(T entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = _entities.Keys.Max() + 1;
        }

        if (!_entities.TryAdd(entity.Id, entity))
        {
            throw new ArgumentException($"The {typeof(T).Name} with the given Id already exists: {entity.Id}");
        }

        return Task.FromResult(entity);
    }

    public Task Delete(T entity)
    {
        _entities.Remove(entity.Id);

        return Task.CompletedTask;
    }

    public Task<T> Get(int id)
    {
        _entities.TryGetValue(id, out var entity);
       
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<T>> GetAll()
    {
        return Task.FromResult(_entities.Values.AsEnumerable());
    }

    public Task Update(T entity)
    {
        if (_entities.TryGetValue(entity.Id, out var existing))
        {
            _entities[entity.Id] = entity;
        }
        else
        {
            throw new ArgumentException($"The {typeof(T).Name} with the given Id not found: {entity.Id}");
        }

        return Task.CompletedTask;
    }
}
