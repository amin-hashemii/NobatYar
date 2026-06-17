using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Domain;

namespace Infra.Repository;

public class Repository<TEntity, TContext> : Domain.Repository.IRepository<TEntity>
        where TEntity : class, IAggregateRoot
        where TContext : DbContext, IUnitOfWork
{
        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(TContext db)
        {
                Db = db;
                DbSet = db.Set<TEntity>(); 
        }
        public void Dispose()
        {
                Db.Dispose();
        }

        public IUnitOfWork UnitOfWork => Db;
        
        public Task AddAsync(TEntity entity)
        {
                return DbSet.AddAsync(entity).AsTask();
        }

        public void Remove(TEntity entity)
        {
                DbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
                DbSet.Update(entity);
        }

        public TEntity Get(int id)
        {
                return DbSet.Find(id);
        }

        public ValueTask<TEntity> GetAsync(int id)
        {
                return DbSet.FindAsync(id);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
                return DbSet.AsQueryable().ToListAsync();
        }
}