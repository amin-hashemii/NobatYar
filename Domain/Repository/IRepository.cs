using NetDevPack.Domain;

namespace Domain.Repository;

public interface IRepository<TEntity> : NetDevPack.Data.IRepository<TEntity> where TEntity : class, IAggregateRoot
{
    Task AddAsync(TEntity entity);
    void Remove(TEntity entity);
    void Update(TEntity entity);
    TEntity Get(int id);
    ValueTask<TEntity> GetAsync(int id);
    Task<List<TEntity>> GetAllAsync();
}