using Microsoft.Azure.Cosmos;
using API.Repository;

namespace API.Configuration;

public static class DatabaseConnector
{
    private static CosmosClient _cosmosClient;
    private static Container _container;
    private const string DatabaseId = "ToDoList";
    private const string ContainerId = "Items";
        
    public static Container GetNotesContainer()
    {
        _cosmosClient = CosmosDbClientFactory.GetClient();
        _container =  _cosmosClient.GetContainer(DatabaseId, ContainerId);
        return _container;
    }
}