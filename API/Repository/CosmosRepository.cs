using System.Net;
using Microsoft.Azure.Cosmos;

namespace API.Repository;

public class CosmosRepository<T>: ICosmosRepository<T>
{
    private readonly Container _container;

    public CosmosRepository(Container container)
    {
        _container = container;
    }
    
    public async IAsyncEnumerable<T> GetAll()
    {
        var query = new QueryDefinition("SELECT * FROM c");

        var iterator = _container.GetItemQueryIterator<T>(query);
        while (iterator.HasMoreResults)
        {
            foreach (var item in await iterator.ReadNextAsync())
            {
                yield return item;
            }
        }
    }

    public async Task<T> Add(T item)
    {
        try
        {
            var taskResponse = await _container.CreateItemAsync(item);
            return taskResponse.Resource;
        }
        catch(CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
        {
            Console.Write(ex);
            throw new ArgumentException("Database already contains item with given id");
        }
    }

    public async Task<T> Update(Guid id, T item)
    {
        try
        {
            var taskResponse = await _container.ReplaceItemAsync(item, id.ToString());
            return taskResponse.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            throw new ArgumentException("Database doesn't contain item with given id");
        }
    }

    public async Task<T> Delete(Guid id)
    {
        try
        {
            var x = id.ToString();
            var taskResponse = await _container.DeleteItemAsync<T>(x, new PartitionKey(x));
            return taskResponse.Resource;
        }
        catch(CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            throw new ArgumentException("Database doesn't contain item with given id");
        }
    }
}