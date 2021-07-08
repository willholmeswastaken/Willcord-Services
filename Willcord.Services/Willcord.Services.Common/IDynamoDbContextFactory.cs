using EfficientDynamoDb;
using EfficientDynamoDb.Configs;

namespace Willcord.Services.Common
{
    public interface IDynamoDbContextFactory
    {
        DynamoDbContext Create(RegionEndpoint region, string accessKey, string secretKey);
    }
}