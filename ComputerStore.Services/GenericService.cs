using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public class GenericService<TEntity> : IService<TEntity>
        where TEntity : class
    {
        protected readonly ComputerStoreDbContext context;
        protected readonly GenericRepository<TEntity> repo;

        public GenericService(ComputerStoreDbContext context)
        {
            this.context = context;
            this.repo = new GenericRepository<TEntity>(context);
        }

        public virtual IEnumerable<TEntity> All() => this.repo.All();

        public virtual IEnumerable<TEntity> AllAsNoTracking() => this.repo.AllAsNoTracking();

        public virtual async Task<TEntity> GetByID(int id) => await repo.GetByIdAsync(id); 

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await repo.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Update(TEntity entity)
        {
            repo.Update(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            repo.Delete(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteByID(int id)
        {
            var entity = await repo.GetByIdAsync(id);
            repo.Delete(entity);

            await context.SaveChangesAsync();
        }
    }
}
