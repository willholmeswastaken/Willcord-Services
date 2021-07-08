using EfficientDynamoDb;
using EfficientDynamoDb.Configs;
using Microsoft.Toolkit.Diagnostics;

namespace Willcord.Services.Common
{
    public class DynamoDbContextFactory : IDynamoDbContextFactory
    {
        public DynamoDbContext Create(RegionEndpoint region, string accessKey, string secretKey)
        {
            Guard.IsNotNullOrWhiteSpace(accessKey, nameof(accessKey));
            Guard.IsNotNullOrWhiteSpace(secretKey, nameof(secretKey));
            
            var credentials = new AwsCredentials(accessKey, secretKey);

            return new DynamoDbContext(new DynamoDbContextConfig(region, credentials));
        }
    }
}