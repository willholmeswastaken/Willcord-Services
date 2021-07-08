namespace Willcord.Services.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        void Delete(string id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(string id);
    }
}