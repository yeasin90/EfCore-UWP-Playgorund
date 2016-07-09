using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGenericRepository
{
    public interface IRepository<TEntity>
    {
        Task Insert(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
    }

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public async virtual Task Delete(TEntity entity)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async virtual Task<TEntity> Get(int id)
        {
            using (var context = new MyDbContext())
            {
                var entity = await context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
                return entity;
            }
        }

        public async virtual Task<List<TEntity>> GetAll()
        {
            using (var context = new MyDbContext())
            {
                var entities = await context.Set<TEntity>().ToListAsync();
                return entities;
            }
        }

        public async virtual Task Insert(TEntity entity)
        {
            using (var context = new MyDbContext())
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
