namespace MediatrSandbox.Api.Repositories;

public interface IRepository<T>  where T : class
{
    Task<T> Get(int id);
    IAsyncEnumerable<T> GetAll();
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
