using System.Collections.Generic;
using System.Threading.Tasks;
using EfficientDynamoDb.FluentCondition.Core;
using Microsoft.Toolkit.Diagnostics;
using Willcord.Services.Common;
using Willcord.Services.Servers.Models;

namespace Willcord.Services.Servers.Data
{
    public class ServerDynamoDbRepository : DynamoDbRepository, IRepository<Server>
    {
        public ServerDynamoDbRepository(IDynamoDbContextFactory dynamoDbContextFactory)
        : base(dynamoDbContextFactory, "serverConfig.json")
        {
        }
        
        public async Task Delete(Server entity)
        {
            Guard.IsNotNull(entity, nameof(entity));
            Guard.IsNotNullOrWhiteSpace(entity.Id, nameof(entity.Id));
            await Delete(entity.Id);
        }

        public async Task Delete(string id)
        {
            Guard.IsNotNullOrWhiteSpace(id, nameof(id));
            await DynamoDbContext.DeleteItemAsync<Server>(id);
        }

        public async Task Insert(Server entity)
        {
            Guard.IsNotNull(entity, nameof(entity));
            Guard.IsNotNullOrWhiteSpace(entity.Name, nameof(entity.Name));
            await DynamoDbContext.PutItemAsync(entity);
        }

        public async Task Update(Server entity)
        {
            Guard.IsNotNull(entity, nameof(entity));
            Guard.IsNotNullOrWhiteSpace(entity.Name, nameof(entity.Name));
            await DynamoDbContext.UpdateItem<Server>()
                .WithPrimaryKey(entity.Id)
                .On(x => x.Name).Assign(entity.Name)
                .On(x => x.DeletedOn).Assign(entity.DeletedOn)
                .On(x => x.DeletedById).Assign(entity.DeletedById)
                .ExecuteAsync();
        }

        public async Task<Server> GetById(string id)
        {
            Guard.IsNotNullOrWhiteSpace(id, nameof(id));
            return await DynamoDbContext.GetItemAsync<Server>(id);
        }

        public async Task<IEnumerable<Server>> GetFilteredAsync(FilterBase filter)
        {
            return await DynamoDbContext.Query<Server>()
                .WithKeyExpression(filter)
                .ToListAsync();
        }
    }
}