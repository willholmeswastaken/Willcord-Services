using System.Collections.Generic;
using System.Threading.Tasks;
using EfficientDynamoDb;
using EfficientDynamoDb.Configs;
using EfficientDynamoDb.FluentCondition.Core;
using Microsoft.Toolkit.Diagnostics;
using Willcord.Services.Common;
using Willcord.Services.Servers.Models;

namespace Willcord.Services.Servers.Data
{
    public class ServerDynamoDbRepository : IRepository<Server>
    {
        private readonly IDynamoDbContext _dynamoDbContext;
        public ServerDynamoDbRepository(IDynamoDbContextFactory dynamoDbContextFactory)
        {
            _dynamoDbContext = dynamoDbContextFactory.Create(RegionEndpoint.EUWest1, "", "");
        }
        
        public Task Delete(Server entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Insert(Server entity)
        {
            await _dynamoDbContext.PutItemAsync(entity);
        }

        public Task Update(Server entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Server> GetById(string id)
        {
            Guard.IsNotNullOrWhiteSpace(id, nameof(id));
            return await _dynamoDbContext.GetItemAsync<Server>(id);
        }

        public async Task<IEnumerable<Server>> GetFilteredAsync(FilterBase filter)
        {
            return await _dynamoDbContext.Query<Server>()
                .WithKeyExpression(filter)
                .ToListAsync();
        }
    }
}