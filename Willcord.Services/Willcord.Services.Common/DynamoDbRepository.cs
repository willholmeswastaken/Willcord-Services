using System.Collections.Generic;
using System.Threading.Tasks;
using EfficientDynamoDb;
using EfficientDynamoDb.Configs;
using EfficientDynamoDb.FluentCondition.Core;
using Newtonsoft.Json;

namespace Willcord.Services.Common
{
    public abstract class DynamoDbRepository
    {
        protected readonly IDynamoDbContext DynamoDbContext;

        protected DynamoDbRepository(IDynamoDbContextFactory dynamoDbContextFactory, string awsConfigFile)
        {
            var serverConfig = JsonConvert.DeserializeObject<AwsConfig>(awsConfigFile);
            DynamoDbContext = dynamoDbContextFactory.Create(RegionEndpoint.EUWest1, serverConfig.AccessKey, serverConfig.SecretKey);    
        }
    }
}