using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Options;

namespace API.Repository;

public static class CosmosDbClientFactory
{
    public static CosmosClient GetClient(string dbContext)
    {
        return new CosmosClientBuilder(dbContext).Build();
    }
}