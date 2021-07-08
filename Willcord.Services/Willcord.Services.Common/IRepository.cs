using System.Collections.Generic;
using System.Threading.Tasks;
using EfficientDynamoDb;
using EfficientDynamoDb.FluentCondition.Core;

namespace Willcord.Services.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Delete(TEntity entity);
        Task Delete(string id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetFilteredAsync(FilterBase filter);
    }
}