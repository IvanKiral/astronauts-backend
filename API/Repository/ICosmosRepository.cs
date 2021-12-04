namespace API.Repository;

public interface ICosmosRepository<T>
{
    public IAsyncEnumerable<T> GetAll();
    public Task<T> Add(T item);
    public Task<T> Update(Guid id, T item);
    public Task<T> Delete(Guid id);
}